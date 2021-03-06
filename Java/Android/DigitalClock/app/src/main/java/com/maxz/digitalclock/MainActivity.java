package com.maxz.digitalclock;

import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.util.Log;
import android.util.TypedValue;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.FrameLayout;
import android.widget.ImageButton;
import android.widget.TextClock;
import android.widget.TextView;


public class MainActivity extends ActionBarActivity {

    private SettingInfo info;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        info=new SettingInfo(this,savedInstanceState);
        Log.e("MainActivity", "onCreate Load Info:" + info.toString());
        initView();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
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
           Intent settingIntent=new Intent(this,ActivitySetting.class );
            startActivityForResult(settingIntent,0,info.getBundle());
            Log.e("MainActivity", "onOptionsItemSelected Send Info:" + info.toString());
            return true;
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        Log.e("MainActivity", "onOptionsItemSelected Send Info:" + info.toString());
        if(data!=null && data.getExtras()!=null) {
            info.Reset(data.getExtras());
            Log.e("MainActivity", "onActivityResult get datas : info ="+ info.toString());
            this.initView();
        }
    }

    @Override
    public void onActivityReenter(int resultCode, Intent data) {
        super.onActivityReenter(resultCode, data);
        Log.e("MainActivity", "onOptionsItemSelected Send Info:" + info.toString());
    }

    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        Bundle state = intent.getBundleExtra("info");
        info=new SettingInfo(this,state);
        initView();
        Log.e("MainActivity", "onNewIntent Send Info:" + info.toString());
    }

    private void initView(){
        TextClock clock=(TextClock)findViewById(R.id.textClock);
        clock.setTextSize(TypedValue.COMPLEX_UNIT_DIP,(float)info.getSize());
        clock.setTextColor(info.getTextColor());
        FrameLayout layout=(FrameLayout)findViewById(R.id.frameLayout);
        layout.setBackgroundColor(info.getBgColor());
        Log.e("MainActivity", "initView Info:" + info.toString());
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
