/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package digitalclock;

import java.awt.Graphics;
import java.util.Timer;
import java.util.TimerTask;

/**
 *
 * @author macbook
 */
public class PaintTask extends TimerTask{
    
    private ClockMainForm form;
    
    
    PaintTask(ClockMainForm form){
        this.form=form;
    }
    
    @Override
    public void run() {
      form.repaint();
    }
    
}
