package com.maxz.digitalclock;

import android.content.ContentResolver;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Rect;
import android.net.Uri;
import android.util.DisplayMetrics;
import android.util.Log;

import java.io.FileNotFoundException;

/**
 * Created by macbook on 2015/08/03.
 */
public class ImageDecoder {
    private final Context context;

    public ImageDecoder(Context contxt){
        this.context =contxt;
    }

    private DisplayMetrics getDisplay()
    {
        DisplayMetrics dm=  context.getResources().getDisplayMetrics();
        return dm;
    }

    public Bitmap getBitmap(Uri uri){
        try {
            BitmapFactory.Options options = new BitmapFactory.Options();
            options.inJustDecodeBounds = true;
            ContentResolver cr = this.context.getContentResolver();
            Rect padding=new Rect();
            BitmapFactory.decodeStream(cr.openInputStream(uri),padding,options);
            DisplayMetrics dm=getDisplay();
            int sampleSize =calculateInSampleSize(options, dm.widthPixels, dm.heightPixels);
            options=new BitmapFactory.Options();
            options.inSampleSize =sampleSize;
            return  BitmapFactory.decodeStream(cr.openInputStream(uri),padding,options);
        } catch (Exception e) {
           Log.d("ImageDecoder" ,e.getMessage(),e   );
            return null;
        }
    }

    private  int calculateInSampleSize(BitmapFactory.Options options,
                                            int reqWidth, int reqHeight) {
        final int height = options.outHeight;
        final int width = options.outWidth;
        int inSampleSize = 4;
        if (height > reqHeight || width > reqWidth) {
          return 4;
        }
        return 1;
    }
}
