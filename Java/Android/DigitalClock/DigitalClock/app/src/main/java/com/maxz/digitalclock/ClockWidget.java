package com.maxz.digitalclock;

import android.app.PendingIntent;
import android.appwidget.AppWidgetManager;
import android.appwidget.AppWidgetProvider;
import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.drawable.BitmapDrawable;
import android.net.Uri;
import android.util.TypedValue;
import android.widget.RemoteViews;
import android.widget.TextView;


/**
 * Implementation of App Widget functionality.
 * App Widget Configuration implemented in {@link ClockWidgetConfigureActivity ClockWidgetConfigureActivity}
 */
public class ClockWidget extends AppWidgetProvider {
    private SettingInfo info;
    @Override
    public void onUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds) {
        // There may be multiple widgets active, so update all of them
        final int N = appWidgetIds.length;
        for (int i = 0; i < N; i++) {
            updateAppWidget(context, appWidgetManager, appWidgetIds[i]);
        }
    }

    @Override
    public void onDeleted(Context context, int[] appWidgetIds) {
        // When the user deletes the widget, delete the preference associated with it.
        final int N = appWidgetIds.length;
        for (int i = 0; i < N; i++) {
            ClockWidgetConfigureActivity.deleteTitlePref(context, appWidgetIds[i]);
        }
    }

    @Override
    public void onEnabled(Context context) {
        // Enter relevant functionality for when the first widget is created
    }

    @Override
    public void onDisabled(Context context) {
        // Enter relevant functionality for when the last widget is disabled
    }

    static void updateAppWidget(Context context, AppWidgetManager appWidgetManager,
                                int appWidgetId) {


        // Construct the RemoteViews object
        RemoteViews views = new RemoteViews(context.getPackageName(), R.layout.clock_widget);
        SettingInfo info = ClockWidgetConfigureActivity.loadPref(context,appWidgetId);
        views.setTextColor(R.id.textWidgetClock, info.getTextColor());
        views.setTextViewTextSize(R.id.textWidgetClock, TypedValue.COMPLEX_UNIT_SP, info.getSize());
        if(info.isUseBgImg()) {
            Uri uri = Uri.parse(info.getBgImgUri());
            ImageDecoder decoder=new ImageDecoder(context);
            //Bitmap bitmap = BitmapFactory.decodeStream(cr.openInputStream(uri));
            Bitmap bitmap = decoder.getBitmap(uri);
            views.setImageViewBitmap(R.id.widgt_imageView,bitmap );
         }else{

            Bitmap bitmap = Bitmap.createBitmap(16,16, Bitmap.Config.ARGB_8888 );
            Canvas canvas=new Canvas();
            canvas.setBitmap(bitmap);
            canvas.drawColor(info.getBgColor());
            views.setImageViewBitmap(R.id.widgt_imageView,bitmap );
         }
        Intent setIntent = new Intent(context,ClockWidgetConfigureActivity.class );
        setIntent.setAction(Intent.ACTION_CONFIGURATION_CHANGED);
        setIntent.putExtra(AppWidgetManager.EXTRA_APPWIDGET_ID, appWidgetId);
        PendingIntent intentAction = PendingIntent.getActivity(context, 0,
                setIntent, 0);
         views.setOnClickPendingIntent(R.id.textWidgetClock,intentAction);
        // Instruct the widget manager to update the widget
        appWidgetManager.updateAppWidget(appWidgetId, views);
    }
}



