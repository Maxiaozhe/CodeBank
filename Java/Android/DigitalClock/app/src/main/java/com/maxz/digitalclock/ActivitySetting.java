package com.maxz.digitalclock;

import android.content.ContentResolver;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
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
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.SeekBar;
import android.widget.Switch;
import android.widget.TextView;

import java.io.FileNotFoundException;


public class ActivitySetting extends ActionBarActivity {
    private SettingInfo info;
    private final static int RESULT_CODE_SELECT_IMAGE =0;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_setting);
        Intent intent= this.getIntent();
        if(intent!=null) {
            info = new SettingInfo(this, intent.getExtras());
        }else{
            info = new SettingInfo(this, savedInstanceState);
        }
        Log.e("ActivitySetting", "onCreate Info:" + info.toString());
        initView();
    }

    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        Bundle state = intent.getBundleExtra("info");
        info=new SettingInfo(this,state);
        initView();
        Log.e("ActivitySetting", "onNewIntent Info:" + info.toString());
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
                Intent backIntent = new Intent(ActivitySetting.this, MainActivity.class);
                backIntent.putExtras(info.getBundle()) ;
                Log.e("ActivitySetting", "backButton Click Info:" + info.toString());
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
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {

            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {
                LinearLayout layout;
            }
        });
        final TextView textColor=(TextView)findViewById(R.id.textColor);
        final LineColorPicker colorPicker=(LineColorPicker)findViewById(R.id.textColorPicker);
        colorPicker.setOnColorChangedListener(new OnColorChangedListener() {
            @Override
            public void onColorChanged(int c) {
                setColor(c,textColor);
                info.setTextColor(c);
            }
        });
        final TextView bgColorText=(TextView)findViewById(R.id.backgroundColor);
        final LineColorPicker bgColorPicker=(LineColorPicker)findViewById(R.id.bgColorPicker);
        bgColorPicker.setOnColorChangedListener(new OnColorChangedListener() {
            @Override
            public void onColorChanged(int c) {
                setColor(c, bgColorText);
                info.setBgColor(c);
            }
        });
        Log.e("ActivitySetting", "initView Info:" + info.toString());
        //”wŒi‰æ‘œ
        final Switch bgImgSwitch=(Switch)findViewById(R.id.bgImgSwitch);
        final Button bgImageSelect=(Button)findViewById(R.id.bgImageSelect);
        bgImgSwitch.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                bgImageSelect.setEnabled(isChecked);
            }
        });
        //”wŒi‰æ‘œ‘I‘ð
        bgImageSelect.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent=new Intent();
                intent.setType("image/*");
                intent.setAction(Intent.ACTION_GET_CONTENT);
                startActivityForResult(intent,RESULT_CODE_SELECT_IMAGE );
            }
        });
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        if(info!=null) {
            info.putBundle(outState);
        }
        super.onSaveInstanceState(outState);
        Log.e("ActivitySetting", "onSaveInstanceState Saved Info:" + info.toString());
    }

    @Override
    protected void onRestoreInstanceState(Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);
        if(savedInstanceState!=null){
            info=new SettingInfo(this,savedInstanceState);
        }
        Log.e("ActivitySetting", "onRestoreInstanceState Load Info:" + info.toString());
        initView();
     }

    private void setColor(int color,TextView view){
        String hexColor = String.format("#%06X", (0xFFFFFF & color));
        view.setText(hexColor);
        view.setBackgroundColor(color);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        try{
            switch (requestCode){
                case RESULT_CODE_SELECT_IMAGE:
                    final TextView textImgUrl =(TextView)findViewById(R.id.textImgUrl);
                    Uri uri = data.getData();
                    ContentResolver cr = this.getContentResolver();
                    try {
                        textImgUrl.setText(uri.getPath());
                        Bitmap bitmap = BitmapFactory.decodeStream(cr.openInputStream(uri));
                        final ImageView bgImageView = (ImageView) findViewById(R.id.bgImageView);
                        bgImageView.setImageBitmap(bitmap);
                    }catch (FileNotFoundException ex){
                        Log.e("ActivitySetting",ex.getMessage(),ex);
                        textImgUrl.setText(ex.getMessage());
                    }
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

}
