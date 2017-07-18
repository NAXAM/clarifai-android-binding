using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Android.App;
using Android.Content;
using System.IO;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Android.Graphics;

namespace clarifi
{
   public class ClarifaiUtil
    {
        public static byte[] retrieveSelectedImage(Context context,  Intent data)
        {
            Stream inStream = null;
            Bitmap bitmap = null;
            try
            {
                inStream = context.ContentResolver.OpenInputStream(data.Data);
                using (MemoryStream ms = new MemoryStream())
                {
                    inStream.CopyTo(ms);
                    return ms.ToArray();
                }
            }
            catch (System.IO.FileNotFoundException e)
            {
                return null;
            }
            finally
            {
                if (inStream != null)
                {
                    try
                    {
                        inStream.Close();
                    }
                    catch (System.IO.IOException ignored)
                    {
                    }
                }
                if (bitmap != null)
                {
                    bitmap.Recycle();
                }
            }
        }
    }
}