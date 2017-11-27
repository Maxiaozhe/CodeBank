/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package digitalclock;

import java.awt.Color;

/**
 *時計の属性設定情報クラス
 * @author macbook
 */
class ClockSettings {
    /**フォント*/
    String fontName;
    /**文字色*/
    NamedColor color;
    /**フォントサイズ*/
    int fontSize;
    /**背景色*/
    NamedColor backColor;
    /**時間フォマット*/
    String dateFormat;
    
    /**太字か*/
    boolean Bold;
    ClockSettings(){
        this.fontName="Black";
        this.fontSize=48;
        this.color= NamedColor.Green;
        this.backColor=NamedColor.Black;
        this.Bold=true;
        this.dateFormat = "HH:mm:ss";
    }
    
    @Override
    public ClockSettings clone(){
      ClockSettings instanse=new ClockSettings();
      instanse.backColor=this.backColor;
      instanse.color=this.color;
      instanse.fontName=this.fontName;
      instanse.fontSize=this.fontSize;
      instanse.Bold=this.Bold;
      return instanse;
    }
}
