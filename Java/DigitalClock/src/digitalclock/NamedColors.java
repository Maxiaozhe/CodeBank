/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package digitalclock;

import java.awt.Color;
import java.util.EnumSet;
import java.util.HashMap;

/**
 *
 * @author xma
 */
enum NamedColor {
    Black("Black"){@Override Color color(){ return Color.black;}},
    Blue("Blue"){@Override Color color(){ return  Color.blue;}},
    Cyan("Cyan")    {@Override Color color(){ return  Color.cyan;}},
    DarkGray("DarkGray")  {@Override Color color(){ return  Color.darkGray;}},
    Gray("Gray")  {@Override Color color(){ return Color.gray;}},
    Green("Green")   {@Override Color color(){ return  Color.green;}},
    LightGray("LightGray")  {@Override Color color(){ return  Color.lightGray;}},
    Magenta("Magenta")   {@Override Color color(){ return  Color.magenta;}},
    Orange("Orange")   {@Override Color color(){ return  Color.orange;}},
    Pink("Pink")   {@Override Color color(){ return Color.pink;}},
    Red("Red")   {@Override Color color(){ return  Color.red;}},
    White("White")  {@Override Color color(){ return  Color.white;}},
    Yellow("Yellow")   {@Override Color color(){ return  Color.yellow;}};
    private final String name;
    NamedColor(String name){this.name=name;}
    @Override
    public String toString() { return name; }
    abstract Color color();
    
    
}