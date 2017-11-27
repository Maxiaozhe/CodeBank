/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package interpret;

import java.util.EventListener;
import java.util.EventObject;
import javax.swing.tree.DefaultMutableTreeNode;

/**
 *
 * @author macbook
 */
interface ObjectReferChangedListener extends EventListener {

    void valueChanged(ObjectReferChangedEvent e);
}

public class ObjectReferChangedEvent extends EventObject {

    private final Object obj;
    private final int arrayIndex;

    public int getArrayIndex() {
        return this.arrayIndex;
    }

    public Object getObject() {
        return this.obj;
    }

    public ObjectReferChangedEvent(Object source, Object obj, int index) {
        super(source);
        this.obj = obj;
        this.arrayIndex = index;
    }

}
