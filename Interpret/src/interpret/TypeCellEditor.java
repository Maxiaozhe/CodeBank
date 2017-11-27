/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package interpret;

import java.awt.Component;
import java.awt.Window;
import java.lang.reflect.Array;
import java.lang.reflect.Field;
import java.lang.reflect.Modifier;
import java.util.EventObject;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JOptionPane;
import javax.swing.JTable;
import javax.swing.event.CellEditorListener;
import javax.swing.event.ChangeEvent;
import javax.swing.table.*;

public class TypeCellEditor implements TableCellEditor {

    private ValueCreator editor;
    private CellEditorListener listener;
    private int rowIndex = 0;
    private JTable table = null;
    private Object oldValue = null;

    @Override
    public Component getTableCellEditorComponent(JTable jtable, Object o, boolean bln, int i, int i1) {
        this.rowIndex = i;
        this.table = jtable;
        Class<?> type = (Class<?>) jtable.getModel().getValueAt(i, 1);
        Object paramValue = jtable.getModel().getValueAt(i, 2);
        this.editor = new ValueCreator(type, paramValue);
        this.oldValue = paramValue;
        return this.editor;
    }

    @Override
    public Object getCellEditorValue() {
        //System.out.println("getCellEditorValue");
        Object value = this.editor.getValue();
        TableModel model = this.table.getModel();
        Window parent= Utility.getParentWindow(this.editor);
        if (value != this.oldValue && model instanceof TypeTableModel) {
            try {
                TypeTableModel tModel = (TypeTableModel) model;
                Object col0 = tModel.getValueAt(rowIndex, 0);
                if (col0 instanceof Field) {
                    //Fieldの場合
                    Field fld = (Field) tModel.getValueAt(rowIndex, 0);
                    Object instance = tModel.getInstance();
                    if (!fld.isAccessible()) {
                        fld.setAccessible(true);
                    }
                    int mod = fld.getModifiers();
                    if (Modifier.isStatic(mod)) {
                        if(Modifier.isFinal(mod)){
                            try {
                                Utility.changeStaticFinalValue(fld,value);
                            } catch (NoSuchFieldException ex) {
                                JOptionPane.showMessageDialog(parent, ex.toString());
                            }
                        }else{
                            fld.set(null, value);
                        }
                    } else {
                        fld.set(instance, value);
                    }
                } else if (col0 instanceof Integer) {
                    //配列の値の場合
                    int index = (int) col0;
                    Object instance = tModel.getInstance();
                    if (instance.getClass().isArray()) {
                        Array.set(instance, index, value);
                        if(tModel.getEventListener()!=null){
                            tModel.getEventListener().valueChanged(
                                    new ObjectReferChangedEvent(tModel, instance,index));
                        }
                    }
                }
            } catch (IllegalArgumentException ex) {
                JOptionPane.showMessageDialog(parent, ex.toString());
            } catch (IllegalAccessException ex) {
                JOptionPane.showMessageDialog(parent, ex.toString());
            }
        }
        return value;
    }

    @Override
    public boolean isCellEditable(EventObject eo) {
        //System.out.println("isCellEditable");
        return true;
    }

    @Override
    public boolean shouldSelectCell(EventObject eo) {
        //System.out.println("shouldSelectCell");
        return true;
    }

    @Override
    public boolean stopCellEditing() {
        if (this.listener != null) {
            this.listener.editingStopped(new ChangeEvent(this));
        }
        this.editor.setVisible(false);
        return true;
    }

    @Override
    public void cancelCellEditing() {
       //System.out.println("cancelCellEditing");
        if (this.listener != null) {
            this.listener.editingCanceled(new ChangeEvent(this));
        }
    }

    @Override
    public void addCellEditorListener(CellEditorListener cl) {
        //System.out.println("addCellEditorListener");
        this.listener = cl;
    }

    @Override
    public void removeCellEditorListener(CellEditorListener cl) {
        //System.out.println("removeCellEditorListener");
        this.listener = null;
    }

}

class TypeCellRender extends DefaultTableCellRenderer {

    @Override
    protected void setValue(Object value) {
        Object displayVlaue = value;
        if (value instanceof Field) {
            displayVlaue = ((Field) value).getName();
        } else if (value instanceof Class<?>) {
            Class<?> cls = (Class<?>) value;
            displayVlaue = replacePerfix(cls.getSimpleName());
        } else if (value != null && value.getClass().isArray()) {
            displayVlaue = Utility.arrayToString(value);
        }
        super.setValue(displayVlaue);
    }

    private String replacePerfix(String declareString) {
        String localName = declareString.replace("java.lang.", "");
        return localName;
    }
}
