/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package interpret;

import java.awt.Component;
import java.awt.Window;
import java.lang.reflect.*;
import java.util.Comparator;
import javax.swing.*;
import javax.swing.tree.*;

class ObjectTypeTreeNode extends DefaultMutableTreeNode {

    private static final long serialVersionUID = 1L;

    public enum ObjNodeType {

        Object,
        ArrayItem,
        Field,
        Method
    }
    private String name = "";
    private Object instance = null;
    private Member member = null;
    private ObjNodeType nodeType;
    private int index = -1;

    public int getArrayIndex() {
        if (this.nodeType != ObjNodeType.ArrayItem) {
            return -1;
        }
        return index;
    }

    /**
     * @return the instance
     */
    public String getName() {
        return this.name;
    }

    public ObjNodeType getNodeType() {
        return this.nodeType;
    }

    public Object getInstance() {
        return this.instance;
    }

    public Member getMember() {
        return this.member;
    }

    public Field getField() {
        if (this.nodeType == ObjNodeType.Field) {
            return (Field) this.member;
        }
        return null;
    }

    public Method getMethod() {
        if (this.nodeType == ObjNodeType.Method) {
            return (Method) this.member;
        }
        return null;
    }

    public boolean isStatic() {
        if (this.nodeType == ObjNodeType.Field || this.nodeType == ObjNodeType.Method) {
            int mod = this.member.getModifiers();
            return Modifier.isStrict(mod);
        } else {
            return false;
        }
    }

    /**
     * Fieldの値を取得する
     */
    public Object getFieldValue() throws IllegalAccessException {
        if (this.nodeType != ObjNodeType.Field) {
            return null;
        }
        Field fld = this.getField();
        if (!fld.isAccessible()) {
            fld.setAccessible(true);
        }
        if (this.isStatic()) {
            return fld.get(null);
        } else {
            return fld.get(this.instance);
        }
    }

    public Object getArrayItem() {
        if (this.nodeType != ObjNodeType.ArrayItem) {
            return null;
        }
        return Array.get(this.instance, index);
    }

    /**
     * メッソドよびだし
     */
    public Object invoke(Object... args) throws IllegalAccessException, InvocationTargetException {
        if (this.nodeType != ObjNodeType.Method) {
            return null;
        }
        Object result = null;
        Method method = this.getMethod();
        if (!method.isAccessible()) {
            method.setAccessible(true);
        }
        if (this.isStatic()) {
            result = method.invoke(null, args);
        } else {
            result = method.invoke(this.instance, args);
        }
        return result;
    }

    /**
     * @param name the name to set
     */
    public void setName(String name) {
        this.name = name;
    }

    public ObjectTypeTreeNode(String name, Object obj) {
        super(obj);
        this.name = name;
        this.member = null;
        this.instance = obj;
        this.nodeType = ObjNodeType.Object;
    }

    public ObjectTypeTreeNode(String name, Object obj, Field fld) {
        super(fld);
        this.name = name;
        this.instance = obj;
        this.member = fld;
        this.nodeType = ObjNodeType.Field;
    }

    public ObjectTypeTreeNode(String name, Object obj, Method method) {
        super(method);
        this.name = name;
        this.instance = obj;
        this.member = method;
        this.nodeType = ObjNodeType.Method;
    }

    public ObjectTypeTreeNode(Object obj, int index) {
        super(index);
        this.name = name;
        this.instance = obj;
        this.member = null;
        this.index = index;
        this.nodeType = ObjNodeType.ArrayItem;
    }

    @Override
    public String toString() {

        String clsName = this.instance.getClass().getSimpleName();
        switch (this.nodeType) {
            case Field:
                return this.getField().getName() + " : " + this.getField().getType().getSimpleName();
            case Method:
                //return replacePerfix(clsName, this.getMethod().toString());
                return Utility.getMethodSimpleName(this.getMethod());
            case Object:
                int pos = clsName.lastIndexOf(".");
                String typeName = clsName.substring(pos + 1);
                return typeName + " " + this.name;
            case ArrayItem:
                return "[" + index + "]";
            default:
                return super.toString();
        }
    }
}

class ObjectTree extends JTree {

    private boolean publicMemberOnly = true;
    private JTree.DynamicUtilTreeNode root = null;

    /**
     * @return the publicMemberOnly
     */
    public boolean isPublicMemberOnly() {
        return this.publicMemberOnly;
    }

    /**
     * @param publicMemberOnly the publicMemberOnly to set
     */
    public void setPublicMemberOnly(boolean publicMemberOnly) {
        this.publicMemberOnly = publicMemberOnly;
    }

    public ObjectTree() {
        super(new JTree.DynamicUtilTreeNode("インスタンス", "インスタンス"));
        this.root = (JTree.DynamicUtilTreeNode) super.getModel().getRoot();
        this.root.setAllowsChildren(true);
        this.setCellRenderer(new ObjTreeCellRenderer());
        ToolTipManager.sharedInstance().registerComponent(this);
    }

    public void clear() {
        this.root.removeAllChildren();
    }

    public ObjectTypeTreeNode AddNode(ObjectTypeTreeNode node) {
        try {
            this.root.add(node);
            return node;
        } finally {
            super.updateUI();
        }
    }

    public JTree.DynamicUtilTreeNode getRoot() {
        return this.root;
    }

    public ObjectTypeTreeNode addObject(String name, Object obj) {
        if (obj == null) {
            return null;
        }
        ObjectTypeTreeNode objNode = new ObjectTypeTreeNode(name, obj);
        //Array
        if (obj.getClass().isArray()) {
            this.addArrayItem(objNode, obj);
        }
        //Field
        TypeTreeNode fields = new TypeTreeNode("Fields");
        this.addFields(name, fields, obj);
        if (fields.getChildCount() > 0) {
            objNode.add(fields);
        }
        //Methods
        TypeTreeNode Methods = new TypeTreeNode("Methods");
        this.addMethods(name, Methods, obj);
        if (Methods.getChildCount() > 0) {
            objNode.add(Methods);
        }
        this.AddNode(objNode);
        return objNode;
    }

    public void addArrayItem(DefaultMutableTreeNode parent, Object obj) {
        if (obj == null) {
            return;
        }
        if (obj.getClass().isArray()) {
            int length = Array.getLength(obj);
            for (int i = 0; i < length; i++) {
                ObjectTypeTreeNode arrItemNode = new ObjectTypeTreeNode(obj, i);
                Object arrObj = Array.get(obj, i);
                addArrayItem(arrItemNode, arrObj);
                parent.add(arrItemNode);
                if (arrObj != null && !arrObj.getClass().isArray()) {
                    //Field
                    TypeTreeNode fields = new TypeTreeNode("Fields");
                    this.addFields("", fields, arrObj);
                    if (fields.getChildCount() > 0) {
                        arrItemNode.add(fields);
                    }
                    //Methods
                    TypeTreeNode Methods = new TypeTreeNode("Methods");
                    this.addMethods("", Methods, arrObj);
                    if (Methods.getChildCount() > 0) {
                        arrItemNode.add(Methods);
                    }
                }

            }
        }
    }

    private void addFields(String name, DefaultMutableTreeNode fieldNode, Object obj) {
        Field[] flds;
        if (this.publicMemberOnly) {
            flds = obj.getClass().getFields();
        } else {
            flds = obj.getClass().getDeclaredFields();
        }
        java.util.Arrays.sort(flds, new Comparator<Field>() {
            @Override
            public int compare(Field m1, Field m2) {
                return m1.getName().compareTo(m2.getName());
            }
        });
        for (Field fld : flds) {
            fieldNode.add(new ObjectTypeTreeNode(name, obj, fld));
        }
    }

    private void addMethods(String name, DefaultMutableTreeNode methodNode, Object obj) {
        Method[] ms;
        if (this.publicMemberOnly) {
            ms = obj.getClass().getMethods();
        } else {
            ms = obj.getClass().getDeclaredMethods();
        }
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
            methodNode.add(new ObjectTypeTreeNode(name, obj, m));
        }
    }

    public void expandRoot() {
        this.expandRow(0);
    }

}

class ObjTreeCellRenderer extends DefaultTreeCellRenderer {

    private final static String src = "icons/";

    public ObjTreeCellRenderer() {
    }

    @Override
    public Component getTreeCellRendererComponent(JTree tree, Object value, boolean sel, boolean expanded, boolean leaf, int row, boolean hasFocus) {
        super.getTreeCellRendererComponent(tree, value, sel, expanded, leaf, row, hasFocus);
        MutableTreeNode node = (MutableTreeNode) value;
        if (node instanceof ObjectTypeTreeNode) {
            ObjectTypeTreeNode objNode = (ObjectTypeTreeNode) node;
            Icon nodeicon = null;
            int mod;
            String tooltip="";
            switch (objNode.getNodeType()) {
                case Object:
                    nodeicon = new ImageIcon(src + "object.gif");
                    this.setToolTipText(objNode.getInstance().toString());
                    break;
                case Field:
                    Field fld = objNode.getField();
                    nodeicon = new ImageIcon(this.getFieldIconName(fld));
                    tooltip=Utility.replacePerfix(fld.toString(),fld.getDeclaringClass().getName());
                    this.setToolTipText(tooltip);
                    break;
                case Method:
                    Method mt = objNode.getMethod();
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
