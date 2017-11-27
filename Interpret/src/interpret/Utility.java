/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package interpret;

import java.awt.*;
import java.lang.reflect.*;
import java.util.*;
import javax.swing.JOptionPane;
import javax.swing.UIManager.LookAndFeelInfo;

/**
 *
 * @author xma
 */
public final class Utility {

    private static TreeMap<String, Class<?>> types = new TreeMap<>();
    private static TreeMap<String, Object> objects = new TreeMap<>();

    /**
     * @return タイプ一覧
     */
    public static TreeMap<String, Class<?>> getTypes() {
        if (types.size() == 0) {
            types.put("java.lang.String", String.class);
            types.put("java.lang.Integer", Integer.class);
            types.put("java.awt.Windows", java.awt.Window.class);
            types.put("java.awt.Button", java.awt.Button.class);
        }
        return types;
    }

    /**
     * @return the objects
     */
    public static TreeMap<String, Object> getObjects() {
        return objects;
    }

    public static boolean isSampleType(String typeName) {
        String localName = typeName.replace("java.lang.", "");
        switch (localName) {
            case "String":
            case "char":
            case "Character":
            case "byte":
            case "Byte":
            case "int":
            case "Integer":
            case "long":
            case "Long":
            case "double":
            case "Double":
            case "float":
            case "Float":
            case "boolean":
            case "Boolean":
                return true;
            default:
                return false;
        }
    }

    public static Class<?> getSampleType(String typeName) {
        String localName = typeName.replace("java.lang.", "");
        switch (localName) {
            case "String":
                return String.class;
            case "char":
                return char.class;
            case "Character":
                return Character.class;
            case "byte":
                return byte.class;
            case "Byte":
                return Byte.class;
            case "int":
                return int.class;
            case "Integer":
                return Integer.class;
            case "long":
                return long.class;
            case "Long":
                return Long.class;
            case "double":
                return double.class;
            case "Double":
                return Double.class;
            case "float":
                return float.class;
            case "Float":
                return Float.class;
            case "boolean":
                return boolean.class;
            case "Boolean":
                return Boolean.class;
            default:
                return null;
        }
    }

    public static Object getSampleTypeInstance(String typeName, String value) {
        String localName = typeName.replace("java.lang.", "");
        switch (localName) {
            case "String":
                return new String(value);
            case "char":
            case "Character":
                return value.trim().toCharArray()[0];
            case "byte":
            case "Byte":
                return Byte.parseByte(value);
            case "int":
            case "Integer":
                return Integer.parseInt(value);
            case "long":
            case "Long":
                return Long.parseLong(value);
            case "double":
            case "Double":
                return Double.parseDouble(value);
            case "float":
            case "Float":
                return Float.parseFloat(value);
            case "boolean":
            case "Boolean":
                return Boolean.parseBoolean(value);
            default:
                return null;
        }
    }

    public static boolean addType(Class<?> cls) {
        if (!types.containsKey(cls.getName())) {
            types.put(cls.getName(), cls);
            return true;
        }
        return false;
    }

    public static String addObjectList(Component parent, String name, Object obj) {
        String keyName = name;
        if (keyName.isEmpty()) {
            String defaultName = getDefaultName(obj.getClass());
            keyName = JOptionPane.showInputDialog("変数名を入力してください。", defaultName);
            if (keyName.isEmpty()) {
                return null;
            }
        }
        if (!objects.containsKey(keyName)) {
            objects.put(keyName, obj);
            return keyName;
        } else {
            JOptionPane.showMessageDialog(parent, "変数名はすでに追加されました。変更してください。");
            keyName = JOptionPane.showInputDialog("変数名を入力してください。", keyName);
            if (keyName == null || keyName.isEmpty()) {
                return null;
            }
            return addObjectList(parent, keyName, obj);
        }
    }

    public static boolean changeKeyName(String oldKey, String newKey) {
        if (!objects.containsKey(oldKey)) {
            return false;
        }
        if (objects.containsKey(newKey)) {
            return false;
        }
        Object obj = objects.get(oldKey);
        objects.put(newKey, obj);
        objects.remove(oldKey);
        return true;
    }

    public static String getDefaultName(Class<?> cls) {
        String clsName = cls.getSimpleName();
        int pos = clsName.lastIndexOf(".");
        String typeName = clsName.substring(pos + 1).toLowerCase();
        typeName = typeName + (objects.size() + 1);
        return getUniqueName(typeName);
    }

    private static String getUniqueName(final String name) {
        String localName = name;
        for (String key : objects.keySet()) {
            if (key.equals(localName)) {
                localName = getUniqueName(localName + "1");
            }
        }
        return localName;
    }

    /**
     * OSによるLookAndFeelを自動設定する
     * @param lookandFeel
     */
    public static void setLookAndFeel(String lookandFeel) {
        String[] faces;
        java.util.Properties props = java.lang.System.getProperties();
        String osName = props.getProperty("os.name");
        String defaultFeel= (lookandFeel!=null)?lookandFeel:"Metal";
        if (osName.equals("Mac OS X")) {
            faces = new String[]{defaultFeel, "Mac OS X"};
        } else {
            faces = new String[]{defaultFeel, "Windows"};
        }
        try {
            for (String name : faces) {
                LookAndFeelInfo info = findLookAndFeelInfo(name);
                if (info != null) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    return;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(MainForm.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(MainForm.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(MainForm.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(MainForm.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
    }

    private static LookAndFeelInfo findLookAndFeelInfo(String infoName) {
        for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
            // System.out.println(info.getName());
            if (infoName.equals(info.getName())) {
                return info;
            }
        }
        return null;
    }

    /**
     * WindowはScreenの中央で表示する
     */
    public static void displayScreenCenter(Window win, int width, int height) {
        GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
        DisplayMode dm = ge.getDefaultScreenDevice().getDisplayMode();
        int screenW = dm.getWidth();
        int screenH = dm.getHeight();
        int x = (int) ((screenW - width) / 2.0);
        int y = (int) ((screenH - height) / 2.0);
        win.setBounds(x, y, width, height);
    }

    public static Object createArray(Component parent, Class<?> cls) {
        String buffer = JOptionPane.showInputDialog(parent, "次元の配列数を入力してください。");
        if (buffer == null || buffer.isEmpty()) {
            return null;
        }
        String dimStrs[] = buffer.split(",");
        Object returnObj;
        if (dimStrs.length > 1) {
            int[] dims = new int[dimStrs.length];
            for (int i = 0; i < dimStrs.length; i++) {
                dims[i] = Integer.parseInt(dimStrs[i]);
            }
            returnObj = Array.newInstance(cls, dims);
        } else {
            int dim = Integer.parseInt(dimStrs[0]);
            returnObj = Array.newInstance(cls, dim);
        }
        return returnObj;

    }

    public static String arrayToString(Object obj) {
        if (obj == null) {
            return "";
        }
        if (obj.getClass().isArray()) {
            Class<?> comType = obj.getClass().getComponentType();
            if (isSampleType(comType.getName())) {
                int length = Array.getLength(obj);
                StringBuilder sb = new StringBuilder();
                sb.append("{");
                for (int i = 0; i < length; i++) {
                    if (i > 0) {
                        sb.append(",");
                    }
                    Object item = Array.get(obj, i);
                    if (item != null) {
                        sb.append(item.toString());
                    }
                }
                sb.append("}");
                return sb.toString();
            }
        }
        return obj.toString();

    }

    /**
     * 指定するコンテナのParnt Window を探します。
     *
     * @param container コンテナ
     */
    public static Window getParentWindow(Container container) {
        if (container == null) {
            return null;
        }
        if (container instanceof Window) {
            return (Window) container;
        }
        Container parent = container.getParent();
        return getParentWindow(parent);
    }

    public static String replacePerfix(String declareString) {
        String localName = declareString.replace("java.lang.", "");
        return localName;
    }

    /**
     * toString()に冗長な文字列を除去する
     */
    public static String replacePerfix(String target, String pkgName) {
        String localName = target;
        if (!pkgName.isEmpty()) {
            localName = target.replace(pkgName + ".", "");
        }
        localName = localName.replace("java.lang.", "");
        return localName;
    }

    /**
     * Simpleメッソド名を取得する
     */
    public static String getMethodSimpleName(Method method) {
        if (method == null) {
            return "";
        }
        Class<?>[] params = method.getParameterTypes();
        Class<?> retType = method.getReturnType();
        StringBuilder sb = new StringBuilder();
        sb.append(method.getName());
        sb.append("(");
        for (int i = 0; i < params.length; i++) {
            if (i > 0) {
                sb.append(",");
            }
            sb.append(params[i].getSimpleName());
        }
        sb.append(")");
        if (retType != Void.class) {
            sb.append(" : ");
            sb.append(retType.getSimpleName());
        }
        return sb.toString();
    }

    /**
     * 静的なFinal値を変更する
     *
     * @param fld
     * @param newValue
     * @throws java.lang.NoSuchFieldException
     * @throws java.lang.IllegalAccessException
     */
    public static void changeStaticFinalValue(Field fld, Object newValue)
            throws NoSuchFieldException, IllegalAccessException {
        if (!fld.isAccessible()) {
            fld.setAccessible(true);
        }
        //final属性を削除
        Field modifiersField = Field.class.getDeclaredField("modifiers");
        modifiersField.setAccessible(true);
        modifiersField.setInt(fld, fld.getModifiers() & ~Modifier.FINAL);
        //値を変更
        setFieldValue(null, fld, newValue);
    }

    public static void setFieldValue(Object instance, Field fld, Object newValue) throws IllegalArgumentException, IllegalAccessException {
        String typeName = fld.getType().getName();
        String localName = typeName.replace("java.lang.", "");
        switch (localName) {
            case "char":
                fld.setChar(instance, (char) newValue);
                break;
            case "byte":
                fld.setByte(instance, (byte) newValue);
                break;
            case "int":
                fld.setInt(instance, (int) newValue);
                break;
            case "long":
                fld.setLong(instance, (long) newValue);
                break;
            case "double":
                fld.setDouble(instance, (double) newValue);
                break;
            case "float":
                fld.setDouble(instance, (float) newValue);
                break;
            case "boolean":
                fld.setBoolean(null, (boolean) newValue);
                break;
            default:
                fld.set(instance, newValue);
        }
    }
}
