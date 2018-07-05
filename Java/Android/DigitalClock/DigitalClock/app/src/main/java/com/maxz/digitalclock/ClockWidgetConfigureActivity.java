package com.maxz.digitalclock;

import android.app.Activity;
import android.app.AlertDialog;
import android.appwidget.AppWidgetManager;
import android.content.ContentResolver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.graphics.Typeface;
import android.graphics.drawable.BitmapDrawable;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.FrameLayout;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.SeekBar;
import android.widget.Switch;
import android.widget.TextClock;
import android.widget.TextView;


/**
 * The configuration screen for the {@link ClockWidget ClockWidget} AppWidget.
 */
public class ClockWidgetConfigureActivity extends Activity {

    int mAppWidgetId = AppWidgetManager.INVALID_APPWIDGET_ID;
    private static final String PREF_PREFIX_KEY = "appwidget_id";
    private SettingInfo info;
    private final static int RESULT_CODE_SELECT_IMAGE =0;

    public ClockWidgetConfigureActivity() {
        super();
    }

    @Override
    public void onCreate(Bundle icicle) {
        super.onCreate(icicle);

        // Set the result to CANCELED.  This will cause the widget host to cancel
        // out of the widget placement if the user presses the back button.
        setResult(RESULT_CANCELED);

        setContentView(R.layout.activity_setting);


        // Find the widget id from the intent.
        Intent intent = getIntent();
        Bundle extras = intent.getExtras();
        if (extras != null) {
            mAppWidgetId = extras.getInt(
                    AppWidgetManager.EXTRA_APPWIDGET_ID, AppWidgetManager.INVALID_APPWIDGET_ID);

        }

        // If this activity was started with an intent without an app widget ID, finish with an error.
        if (mAppWidgetId == AppWidgetManager.INVALID_APPWIDGET_ID) {
            finish();
            return;
        }
        this.info=loadPref(this,mAppWidgetId);
        this.initView();
    }

    View.OnClickListener mOnClickListener = new View.OnClickListener() {
        public void onClick(View v) {
            final Context context = ClockWidgetConfigureActivity.this;

            // When the button is clicked, store the string locally
            savePref(info, context, mAppWidgetId);

            // It is the responsibility of the configuration activity to update the app widget
            AppWidgetManager appWidgetManager = AppWidgetManager.getInstance(context);
            ClockWidget.updateAppWidget(context, appWidgetManager, mAppWidgetId);

            // Make sure we pass back the original appWidgetId
            Intent resultValue = new Intent();
            resultValue.putExtra(AppWidgetManager.EXTRA_APPWIDGET_ID, mAppWidgetId);
            setResult(RESULT_OK, resultValue);
            finish();
        }
    };

    // Write the prefix to the SharedPreferences object for this widget
    static void savePref(SettingInfo info,Context context, int appWidgetId) {
        SharedPreferences prefs = context.getSharedPreferences(SettingInfo.SAVE_KEY + appWidgetId, MODE_PRIVATE);
        info.putPerf(prefs);
    }

    // Read the prefix from the SharedPreferences object for this widget.
    // If there is no preference saved, get the default from a resource
    static SettingInfo loadPref(Context context, int appWidgetId) {
        SharedPreferences prefs = context.getSharedPreferences(SettingInfo.SAVE_KEY + appWidgetId, MODE_PRIVATE);
        SettingInfo info=new SettingInfo(context,prefs);
        return info;
    }

    static void deleteTitlePref(Context context, int appWidgetId) {
        SharedPreferences.Editor prefs = context.getSharedPreferences(SettingInfo.SAVE_KEY + appWidgetId, 0).edit();
        prefs.clear();
        prefs.commit();
    }


    private void initView(){
        ImageButton backButton=(ImageButton)super.findViewById(R.id.backButton);
        backButton.setOnClickListener(mOnClickListener);
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
                AlertDialog.Builder db = new AlertDialog.Builder(ClockWidgetConfigureActivity.this);
                db.setTitle(getResources().getString(R.string.font_Select));
                db.setIcon(android.R.drawable.ic_dialog_info);
                db.setSingleChoiceItems(fonts, 0, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                        String font = fonts[which];
                        ClockWidgetConfigureActivity.this.info.setFontName(font);
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

}

