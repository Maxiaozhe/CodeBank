/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package interpret;

import java.awt.Component;
import java.lang.reflect.*;
import java.util.Comparator;
import javax.swing.*;
import javax.swing.tree.*;

/**
 *
 * @author xma
 */
class TypeTreeNode extends DefaultMutableTreeNode {

    private static final long serialVersionUID = 1L;

    public enum NodeType {

        Class,
        Interface,
        Field,
        Constructor,
        Method,
        Folder,
        Other
    }

    private TypeTreeNode() {
    }

    public TypeTreeNode(Object o) {
        super(o, true);
    }

    public Field getField() {
        if (this.getNodeType() == NodeType.Field) {
            return (Field) super.getUserObject();
        }
        return null;
    }

    public Method getMethod() {
        if (this.getNodeType() == NodeType.Method) {
            return (Method) super.getUserObject();
        }
        return null;
    }

    public Constructor<?> getConstructor() {
        if (this.getNodeType() == NodeType.Constructor) {
            return (Constructor) super.getUserObject();
        }
        return null;
    }

    public boolean isStatic() {
        if (this.getNodeType() == NodeType.Field || this.getNodeType() == NodeType.Method) {
            int mod = ((Member) super.getUserObject()).getModifiers();
            return Modifier.isStatic(mod);
        } else {
            return false;
        }
    }

    /**
     * Fieldの値を取得する
     */
    public Object getFieldValue() throws IllegalAccessException {
        if (this.getNodeType() != NodeType.Field) {
            return null;
        }
        if (!this.isStatic()) {
            return null;
        }
        Field fld = this.getField();
        if (!fld.isAccessible()) {
            fld.setAccessible(true);
        }
        return fld.get(null);
    }

    public NodeType getNodeType() {
        if (super.userObject instanceof Class<?>) {
            if (((Class<?>) super.userObject).isInterface()) {
                return NodeType.Interface;
            } else {
                return NodeType.Class;
            }
        } else if (super.userObject instanceof Field) {
            return NodeType.Field;
        } else if (super.userObject instanceof Method) {
            return NodeType.Method;
        } else if (super.userObject instanceof Constructor<?>) {
            return NodeType.Constructor;
        } else if (super.userObject instanceof String) {
            return NodeType.Folder;
        }
        return NodeType.Other;
    }

    @Override
    public String toString() {
        //return super.toString(); //To change body of generated methods, choose Tools | Templates.
        if (super.userObject instanceof Class<?>) {
            return ((Class<?>) super.userObject).getName();
        } else if (super.userObject instanceof Field) {
           // Class<?> cls = ((Field) super.userObject).getDeclaringClass();
           // return replacePerfix(cls.getName(), ((Field) super.userObject).toString());
            return this.getField().getName() + " : " + this.getField().getType().getSimpleName();
        } else if (super.userObject instanceof Method) {
            //Class<?> cls = ((Method) super.userObject).getDeclaringClass();
            //return replacePerfix(cls.getName(), ((Method) super.userObject).toString());
            return Utility.getMethodSimpleName(this.getMethod());
        } else if (super.userObject instanceof Constructor<?>) {
            Constructor<?> constr = this.getConstructor();
            String pkgName = constr.getDeclaringClass().getPackage().getName();
            return replacePerfix(pkgName, constr.toString());
        }
        return super.toString();
    }

    /**
     *
     */
    private String replacePerfix(String className, String declareString) {
        String localName = declareString.replace(className + ".", "");
        localName = localName.replace("java.lang.", "");
        return localName;
    }
}

class TypeTreeCellRenderer extends DefaultTreeCellRenderer {

    private final static String src = "icons/";

    public TypeTreeCellRenderer() {
    }

    @Override
    public Component getTreeCellRendererComponent(JTree tree, Object value, boolean sel, boolean expanded, boolean leaf, int row, boolean hasFocus) {
        super.getTreeCellRendererComponent(tree, value, sel, expanded, leaf, row, hasFocus);
        MutableTreeNode node = (MutableTreeNode) value;
        if (node instanceof TypeTreeNode) {
            TypeTreeNode typeNode = (TypeTreeNode) node;
            Icon nodeicon = null;
            int mod;
            String tooltip="";
            switch (typeNode.getNodeType()) {
                case Class:
                    mod = ((Class<?>) typeNode.getUserObject()).getModifiers();
                    if (Modifier.isAbstract(mod)) {
                        nodeicon = new ImageIcon(src + "class_abs.gif");
                    } else {
                        nodeicon = new ImageIcon(src + "class.gif");
                    }
                    break;
                case Interface:
                    nodeicon = new ImageIcon(src + "interface.gif");
                    break;
                case Field:
                    Field fld = (Field) typeNode.getUserObject();
                    nodeicon = new ImageIcon(this.getFieldIconName(fld));
                    tooltip=Utility.replacePerfix(fld.toString(),fld.getDeclaringClass().getName());
                    this.setToolTipText(tooltip);
                    break;
                case Constructor:
                    nodeicon = new ImageIcon(src + "constructor.gif");
                    break;
                case Method:
                    Method mt = (Method) typeNode.getUserObject();
                    nodeicon = new ImageIcon(this.getMethodIconName(mt));
                    tooltip=Utility.replacePerfix(mt.toString(),mt.getDeclaringClass().getName());
                    this.setToolTipText(tooltip);
                    break;
                default:
                    break;
            }
            if (nodeicon != null) {
                this.setIcon(nodeicon);
            }
        }
        return this;
    }

    private String getFieldIconName(Field fld) {
        int mod = fld.getModifiers();
        if (Modifier.isStatic(mod)) {
            if (Modifier.isFinal(mod)) {
                return src + "final_static_field.gif";
            } else {
                if (Modifier.isPrivate(mod)) {
                    return src + "private_static_field.gif";
                } else {
                    return src + "static_field.gif";
                }
            }
        } else {
            if (Modifier.isFinal(mod)) {
                return src + "final_field.gif";
            } else {
                if (Modifier.isPrivate(mod)) {
                    return src + "private_field.gif";
                } else {
                    return src + "public_field.gif";
                }
            }
        }
    }

    private String getMethodIconName(Method mt) {
        int mod = mt.getModifiers();
        if (Modifier.isStatic(mod)) {
            if (Modifier.isPrivate(mod)) {
                return src + "private_static_method.gif";
            } else {
                return src + "public_static_method.gif";
            }
        } else {
            if (Modifier.isPrivate(mod)) {
                return src + "private_method.gif";
            } else {
                return src + "public_method.gif";
            }
        }
    }

}

class TypeTree extends JTree {

    private DynamicUtilTreeNode root = null;

    public TypeTree(String rootName) {
        super(new DynamicUtilTreeNode("root", "root"));
        this.root = (DynamicUtilTreeNode) super.getModel().getRoot();
        this.root.setUserObject(rootName);
        this.root.setAllowsChildren(true);
        this.setCellRenderer(new TypeTreeCellRenderer());
        ToolTipManager.sharedInstance().registerComponent(this);
    }

    private TypeTree() {
    }

    public TypeTreeNode AddNode(TypeTreeNode node) {
        try {
            this.root.add(node);
            return node;
        } finally {
            super.updateUI();
        }
    }

    public void clear() {
        this.root.removeAllChildren();
    }

    public DynamicUtilTreeNode getRoot() {
        return this.root;
    }

    public TypeTreeNode addType(Class<?> cls) {
        TypeTreeNode typeRoot = new TypeTreeNode(cls);
        addType(typeRoot, cls);
        this.AddNode(typeRoot);
        return typeRoot;
    }

    /**
     * @throws ClassNotFoundException
     */
    public TypeTreeNode addType(String className) throws ClassNotFoundException {
        Class<?> cls = Class.forName(className);
        TypeTreeNode typeRoot = new TypeTreeNode(cls);
        addType(typeRoot, cls);
        this.AddNode(typeRoot);
        return typeRoot;
    }

    /**
     * @throws ClassNotFoundException
     */
    private void addType(TypeTreeNode parent, Class<?> cls) {
        TypeTreeNode Inherits = new TypeTreeNode("Inherits");
        Class<?> superCls = cls.getSuperclass();
        if (superCls != null && superCls != Object.class) {
            TypeTreeNode superNode = new TypeTreeNode(superCls);
            addType(superNode, superCls);
            Inherits.add(superNode);
        }
        Class<?>[] interfaces = cls.getInterfaces();
        if (interfaces != null && interfaces.length > 0) {
            for (Class<?> imp : interfaces) {
                TypeTreeNode impNode = new TypeTreeNode(imp);
                addType(impNode, imp);
                Inherits.add(impNode);
            }
        }
        if (Inherits.getChildCount() > 0) {
            parent.add(Inherits);
        }
        TypeTreeNode constructors = new TypeTreeNode("Constructors");
        Constructor<?>[] consts = cls.getDeclaredConstructors();
        if (consts != null && consts.length > 0) {
            for (Constructor<?> cons : consts) {
                constructors.add(new TypeTreeNode(cons));
            }
        }
        if (constructors.getChildCount() > 0) {
            parent.add(constructors);
        }
        TypeTreeNode fields = new TypeTreeNode("Fields");
        for (Field fld : cls.getDeclaredFields()) {
            fields.add(new TypeTreeNode(fld));
        }
        if (fields.getChildCount() > 0) {
            parent.add(fields);
        }
        TypeTreeNode Methods = new TypeTreeNode("Methods");
        Method[] ms = cls.getDeclaredMethods();
        java.util.Arrays.sort(ms, new Comparator<Method>() {
            @Override
            public int compare(Method m1, Method m2) {
                if (Modifier.isPublic(m1.getModifiers()) && !Modifier.isPublic(m2.getModifiers())) {
                    return -1;
                } else if (!Modifier.isPublic(m1.getModifiers()) && Modifier.isPublic(m2.getModifiers())) {
                    return 1;
                }
                return m1.getName().compareTo(m2.getName());
            }
        });
        for (Method m : ms) {
            Methods.add(new TypeTreeNode(m));
        }
        if (Methods.getChildCount() > 0) {
            parent.add(Methods);
        }
    }

    public void expandRoot() {
        this.expandRow(0);
    }

}
