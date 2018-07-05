package com.maxz.digitalclock;

import android.app.AlertDialog;
import android.content.ContentResolver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.ColorFilter;
import android.graphics.Typeface;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.net.Uri;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.text.Html;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.CompoundButton;
import android.widget.FrameLayout;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.SeekBar;
import android.widget.Switch;
import android.widget.TextClock;
import android.widget.TextView;

import java.io.FileNotFoundException;


public class ActivitySetting extends ActionBarActivity {
    private SettingInfo info;
    private final static int RESULT_CODE_SELECT_IMAGE =0;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_setting);
        info = new SettingInfo(this,savedInstanceState);
        Log.e("ActivitySetting", "onCreate Info:" + info.toString());
        initView();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        // getMenuInflater().inflate(R.menu.menu_activity_setting, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }


    private void initView(){
        ImageButton backButton=(ImageButton)super.findViewById(R.id.backButton);
        backButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                saveSetting();
                Intent backIntent = new Intent(ActivitySetting.this, MainActivity.class);
                backIntent.putExtras(info.getBundle()) ;
                ActivitySetting.this.setResult(0, backIntent);
                ActivitySetting.this.finish();
            }
        });
        SeekBar sizeBar=(SeekBar)findViewById(R.id.sizeBar);
        final TextView textSize=(TextView)findViewById(R.id.textSize);
        sizeBar.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                textSize.setText(String.format("%ddp", progress));
                info.setSize(progress);
                initSample();
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {

            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {
                LinearLayout layout;
            }
        });
        sizeBar.setProgress(info.getSize());
        final TextView textColor=(TextView)findViewById(R.id.textColor);
        final LineColorPicker colorPicker=(LineColorPicker)findViewById(R.id.textColorPicker);
        colorPicker.setOnColorChangedListener(new OnColorChangedListener() {
            @Override
            public void onColorChanged(int c) {
                setColor(c,textColor);
                info.setTextColor(c);
                initSample();
            }
        });
        setColor(info.getTextColor(), textColor);
        colorPicker.setSelectedColor(info.getTextColor());
        final TextView bgColorText=(TextView)findViewById(R.id.backgroundColor);
        final LineColorPicker bgColorPicker=(LineColorPicker)findViewById(R.id.bgColorPicker);
        bgColorPicker.setOnColorChangedListener(new OnColorChangedListener() {
            @Override
            public void onColorChanged(int c) {
                setColor(c, bgColorText);
                info.setBgColor(c);
                initSample();
            }
        });
        setColor(info.getBgColor(), bgColorText);
        bgColorPicker.setSelectedColor(info.getBgColor());
        Log.e("ActivitySetting", "initView Info:" + info.toString());
        //background Image
        final Switch bgImgSwitch=(Switch)findViewById(R.id.bgImgSwitch);
        final Button bgImageSelect=(Button)findViewById(R.id.bgImageSelect);
        bgImageSelect.setEnabled(info.isUseBgImg());
        bgImgSwitch.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                bgImageSelect.setEnabled(isChecked);
                if (!isChecked) {
                    info.setBgImgUri(null);
                    initSample();
                }
            }
        });
        bgImgSwitch.setChecked(info.isUseBgImg());
        //Open Image Galley
        bgImageSelect.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent();
                intent.setType("image/*");
                intent.setAction(Intent.ACTION_GET_CONTENT);
                startActivityForResult(intent, RESULT_CODE_SELECT_IMAGE);
            }
        });
        final TextView selectedFontName=(TextView)findViewById(R.id.selectedFontName);
        final Button fontSelectButton = (Button)findViewById(R.id.fontSelectButton);
        final String[] fonts=getResources().getStringArray(R.array.font_familys);
        fontSelectButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                AlertDialog.Builder db = new AlertDialog.Builder(ActivitySetting.this);
                db.setTitle(getResources().getString(R.string.font_Select));
                db.setIcon(android.R.drawable.ic_dialog_info);
                db.setSingleChoiceItems(fonts, 0, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                        String font = fonts[which];
                        ActivitySetting.this.info.setFontName(font);
                        selectedFontName.setText(font);
                        selectedFontName.setTypeface(getTypeFace(font));
                        initSample();
                    }
                });
                db.show();

            }
        });

        initSample();
    }

    private Typeface getTypeFace(String fontName){
        switch (fontName){
            case "normal":
               return Typeface.DEFAULT;
            case "sans":
                return  Typeface.SANS_SERIF;
            case "serif":
                return  Typeface.SERIF;
            case "monospace":
                return  Typeface.MONOSPACE;
            default:
                return Typeface.DEFAULT;
        }
    }

    private void setColor(int color,TextView view){
        String hexColor = String.format("#%06X", (0xFFFFFF & color));
        view.setText(hexColor);
        view.setBackgroundColor(color);
    }

    private void initSample(){

        TextClock sampleClock=(TextClock)findViewById(R.id.sampleClock);
        sampleClock.setTextColor(info.getTextColor());
        sampleClock.setTextSize(info.getSize());
        final FrameLayout sampleLayout = (FrameLayout) findViewById(R.id.sampleLayout);
        sampleLayout.setBackgroundColor(info.getBgColor());
        ContentResolver cr = this.getContentResolver();
        if(info.isUseBgImg()) {
            Uri uri = Uri.parse(info.getBgImgUri());
            ImageDecoder decoder=new ImageDecoder(this);
            //Bitmap bitmap = BitmapFactory.decodeStream(cr.openInputStream(uri));
            Bitmap bitmap = decoder.getBitmap(uri);
            sampleLayout.setBackground(new BitmapDrawable(getResources(), bitmap));
        }
        if( info.getFontName()!=null){
            sampleClock.setTypeface(getTypeFace(info.getFontName()));
        }
    }
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        try{
            if(resultCode!= RESULT_OK) return;
            switch (requestCode){
                case RESULT_CODE_SELECT_IMAGE:
                    Uri uri = data.getData();
                    info.setBgImgUri(uri.toString());
                    initSample();
                    break;
                default:
                    break;
            }
        }catch (Exception ex){
            Log.e("ActivitySetting",ex.getMessage(),ex);
        }
        super.onActivityResult(requestCode, resultCode, data);
        Log.e("ActivitySetting", "onActivityResult");
    }

    @Override
    public void onActivityReenter(int resultCode, Intent data) {
        super.onActivityReenter(resultCode, data);
        Log.e("ActivitySetting", "onActivityReenter");
    }

    private void saveSetting(){
        SharedPreferences perf= this.getSharedPreferences(SettingInfo.SAVE_KEY, Context.MODE_PRIVATE);
        info.putPerf(perf);
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        if(info!=null) {
            info.putBundle(outState);
        }
        super.onSaveInstanceState(outState);
        Log.e("MainActivity", "onSaveInstanceState Saved Info:" + info.toString());
    }

    @Override
    protected void onRestoreInstanceState(Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);
        if(savedInstanceState!=null){
            info=new SettingInfo(this,savedInstanceState);
        }
        Log.e("MainActivity", "onRestoreInstanceState Load Info:" + info.toString());
        initView();
    }
}
