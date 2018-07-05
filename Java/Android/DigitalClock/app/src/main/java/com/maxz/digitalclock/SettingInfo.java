package com.maxz.digitalclock;

import android.content.Context;
import android.graphics.Color;
import android.os.Bundle;
import android.util.Log;

/**
 * Created by Administrator on 2015/07/29.
 */
public class SettingInfo {
    private int textColor;
    private int bgColor;
    private int size;
    private  enum Keys{
        size,
        textColor,
        bgColor
    }
    public int getTextColor() {
        return this.textColor;
    }

    public void setTextColor(int textColor) {
        this.textColor = textColor;
    }

    public int getBgColor() {
        return this.bgColor;
    }

    public void setBgColor(int bgColor) {
        this.bgColor = bgColor;
    }

    public int getSize() {
        return this.size;
    }

    public void setSize(int size) {
        this.size = size;
    }

    public Bundle  getBundle(){
        Bundle state=new Bundle();
        state.putInt(Keys.size.name(),this.size);
        state.putInt(Keys.textColor.name(),this.textColor);
        state.putInt(Keys.bgColor.name(),this.bgColor);
        return state;
    }
    public void putBundle(Bundle state){
        if(state==null) return;
        state.putInt(Keys.size.name(),this.size);
        state.putInt(Keys.textColor.name(),this.textColor);
        state.putInt(Keys.bgColor.name(),this.bgColor);
    }
    public void  Reset(Bundle state){
        if(state!=null) {
            this.size= state.getInt(Keys.size.name(), this.size);
            this.textColor= state.getInt(Keys.textColor.name(), this.textColor);
            this.bgColor=state.getInt(Keys.bgColor.name(), this.bgColor);
            Log.e("SettingInfo", "SettingInfo.Reset Info:" + this.toString());
        }
    }

    public  SettingInfo(Context context,Bundle state){

        if(context!=null){
            this.size=context.getResources().getInteger(R.integer.default_text_size_value);
            this.textColor=context.getResources().getColor(R.color.default_clock_color);
            this.bgColor=context.getResources().getColor(R.color.default_background);
            Log.e("SettingInfo", "New From Context Info:" + this.toString());
        }else{
            this.size=48;
            this.textColor= Color.parseColor("#dedede");
            this.bgColor=Color.parseColor("#aaa");
        }
        if(state!=null){
            this.size= state.getInt(Keys.size.name(), this.size);
            this.textColor= state.getInt(Keys.textColor.name(), this.textColor);
            this.bgColor=state.getInt(Keys.bgColor.name(), this.bgColor);
            Log.e("SettingInfo", "New From Bundle Info:" + this.toString());
        }
    }

    @Override
    public String toString() {
        String buffer=String.format("Size:%ddp color:%s bgColor:%s",this.size,getHexColor(this.textColor),getHexColor(this.bgColor));
        return buffer;
    }

    public String getHexColor(int color){
        String hexColor = String.format("#%06X", (0xFFFFFF & color));
        return hexColor;
    }
}
