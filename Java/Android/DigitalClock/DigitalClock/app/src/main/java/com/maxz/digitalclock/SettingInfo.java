package com.maxz.digitalclock;

import android.content.Context;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;

/**
 * Created by Administrator on 2015/07/29.
 */
public class SettingInfo {
    private int textColor;
    private int bgColor;
    private int size;
    private boolean useBgImg;
    private String bgImgUri=null;
    private String fontName;


    public static final String SAVE_KEY="com.maxz.digitalclock.ClockWidget";
    private  enum Keys{
        size,
        textColor,
        bgColor,
        bgImgUri,
        fontName,
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

    public boolean isUseBgImg(){
        return (this.bgImgUri!=null);
    }
    public String getBgImgUri() {
        return bgImgUri;
    }

    public void setBgImgUri(String bgImgUri) {
        this.bgImgUri = bgImgUri;
    }
    public String getFontName() {
        return fontName;
    }

    public void setFontName(String fontName) {
        this.fontName = fontName;
    }


    public Bundle  getBundle(){
        Bundle state=new Bundle();
        state.putInt(Keys.size.name(),this.size);
        state.putInt(Keys.textColor.name(),this.textColor);
        state.putInt(Keys.bgColor.name(), this.bgColor);
        if(this.isUseBgImg()) {
            state.putString(Keys.bgImgUri.name(), this.bgImgUri);
        }
        state.putString(Keys.fontName.name(),this.fontName);
        return state;
    }
    public void putBundle(Bundle state){
        if(state==null) return;
        state.putInt(Keys.size.name(),this.size);
        state.putInt(Keys.textColor.name(),this.textColor);
        state.putInt(Keys.bgColor.name(), this.bgColor);
        if(this.isUseBgImg()) {
            state.putString(Keys.bgImgUri.name(), this.bgImgUri);
        }
        state.putString(Keys.fontName.name(), this.fontName);

    }

    public void putPerf(SharedPreferences pref){
        SharedPreferences.Editor editor= pref.edit();
        editor.putInt(Keys.size.name(),this.size);
        editor.putInt(Keys.textColor.name(),this.textColor);
        editor.putInt(Keys.bgColor.name(),this.bgColor);
        if(this.isUseBgImg()) {
            editor.putString(Keys.bgImgUri.name(), this.bgImgUri);
        }else{
            editor.putString(Keys.bgImgUri.name(), null);
        }
        editor.putString(Keys.fontName.name(), this.fontName);
        editor.commit();
    }

    public void  Reset(Bundle state){
        if(state!=null) {
            this.size= state.getInt(Keys.size.name(), this.size);
            this.textColor= state.getInt(Keys.textColor.name(), this.textColor);
            this.bgColor=state.getInt(Keys.bgColor.name(), this.bgColor);
            if(state.containsKey(Keys.bgImgUri.name())){
                this.bgImgUri=state.getString(Keys.bgImgUri.name());
            }else{
                this.bgImgUri=null;
            }
            this.fontName=state.getString(Keys.fontName.name(), this.fontName);
            Log.e("SettingInfo", "SettingInfo.Reset Info:" + this.toString());
        }
    }

    public  SettingInfo(Context context,Bundle state){
        this.size=48;
        this.textColor= Color.parseColor("#dedede");
        this.bgColor=Color.parseColor("black");
        this.bgImgUri=null;
        this.fontName=null;
        if(context!=null){
            this.size=context.getResources().getInteger(R.integer.default_text_size_value);
            this.textColor=context.getResources().getColor(R.color.default_clock_color);
            this.bgColor=context.getResources().getColor(R.color.default_background);
            this.fontName=null;
            Log.e("SettingInfo", "New From Context Info:" + this.toString());
        }
        if(state!=null){
            this.size= state.getInt(Keys.size.name(), this.size);
            this.textColor= state.getInt(Keys.textColor.name(), this.textColor);
            this.bgColor=state.getInt(Keys.bgColor.name(), this.bgColor);
            if(state.containsKey(Keys.bgImgUri.name())){
                this.bgImgUri=state.getString(Keys.bgImgUri.name());
            }else{
                this.bgImgUri=null;
            }
            this.fontName=state.getString(Keys.fontName.name());
        } else if(context!=null){
            SharedPreferences perf=context.getSharedPreferences(SAVE_KEY,Context.MODE_PRIVATE);
            this.size=perf.getInt(Keys.size.name(),48);
            this.textColor=perf.getInt(Keys.textColor.name(), this.textColor);
            this.bgColor=perf.getInt(Keys.bgColor.name(),this.bgColor);
            this.bgImgUri=perf.getString(Keys.bgImgUri.name(), null);
            this.fontName=perf.getString(Keys.fontName.name(),null);
            Log.e("SettingInfo", "New From Context Info:" + this.toString());
      }
    }
    public  SettingInfo(Context context,SharedPreferences perf){
        this.size=48;
        this.textColor= Color.parseColor("#dedede");
        this.bgColor=Color.parseColor("black");
        this.bgImgUri=null;
        this.fontName=null;
        if(context!=null){
            this.size=context.getResources().getInteger(R.integer.default_text_size_value);
            this.textColor=context.getResources().getColor(R.color.default_clock_color);
            this.bgColor=context.getResources().getColor(R.color.default_background);
            this.fontName=null;
            Log.e("SettingInfo", "New From Context Info:" + this.toString());
        }
         if(perf!=null){
            this.size=perf.getInt(Keys.size.name(),48);
            this.textColor=perf.getInt(Keys.textColor.name(), this.textColor);
            this.bgColor=perf.getInt(Keys.bgColor.name(),this.bgColor);
            this.bgImgUri=perf.getString(Keys.bgImgUri.name(), null);
             this.fontName=perf.getString(Keys.fontName.name(), null);
             Log.e("SettingInfo", "New From Context Info:" + this.toString());
        }
    }


    @Override
    public String toString() {
        String buffer=String.format("Size:%ddp color:%s bgColor:%s",this.size,getHexColor(this.textColor),getHexColor(this.bgColor));
        if(this.bgImgUri!=null){
            buffer += " BgImgUrl=" + this.bgImgUri;
        }
        return buffer;
    }

    public String getHexColor(int color){
        String hexColor = String.format("#%06X", (0xFFFFFF & color));
        return hexColor;
    }
}
