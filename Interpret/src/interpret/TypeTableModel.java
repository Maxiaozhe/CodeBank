/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package interpret;

import java.util.EventListener;
import javax.swing.table.DefaultTableModel;
/**
 *
 * @author macbook
 */
public class TypeTableModel extends DefaultTableModel{
    private Object instance = null;
    private ObjectReferChangedListener eventListener;

    public ObjectReferChangedListener getEventListener() {
        return eventListener;
    }
    
    
    public TypeTableModel(Object obj, Object[][] data, Object[] columnNames) {
        super(data, columnNames);
        this.instance=obj;
    }

    public void addReferChangeListener(ObjectReferChangedListener listener){
        this.eventListener=listener;
    }
    
    Class[] types = new Class[]{
        java.lang.String.class, java.lang.Object.class, java.lang.Object.class
    };
    
    boolean[] canEdit = new boolean[]{
        false, false, true
    };

    @Override
    public Class getColumnClass(int columnIndex) {
        return types[columnIndex];
    }

    @Override
    public boolean isCellEditable(int rowIndex, int columnIndex) {
        return canEdit[columnIndex];
    }

    /**
     * @return the instance
     */
    public Object getInstance() {
        return instance;
    }
            
}
