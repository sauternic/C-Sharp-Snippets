using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;

using System.Linq;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitmapSaveTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap myBitmap;
         ImageCodecInfo myImageCodecInfo;
         Encoder myEncoder;
         EncoderParameter myEncoderParameter;
         EncoderParameters myEncoderParameters;

         // Create a Bitmap object based on a BMP file.
         myBitmap = new Bitmap( @"G:\Eigene Bilder\Flugzeuge\Ordner\duck.jpg" );

         // Get an ImageCodecInfo object that represents the JPEG codec.
         myImageCodecInfo = GetEncoderInfo( "image/jpeg" );

         // Create an Encoder object based on the GUID

         // for the Quality parameter category.
         myEncoder = Encoder.Quality;

         // Create an EncoderParameters object.

         // An EncoderParameters object has an array of EncoderParameter

         // objects.  In this case, there is only one

         // EncoderParameter object in the array.
         myEncoderParameters = new EncoderParameters(1);

         // Save the bitmap as a JPEG file with quality level 1.
         myEncoderParameter = new EncoderParameter(myEncoder, 1L);
         myEncoderParameters.Param[0] = myEncoderParameter;
         myBitmap.Save(@"G:\Eigene Bilder\Flugzeuge\Ordner\Shapes02.jpg" , myImageCodecInfo, myEncoderParameters);

         // Save the bitmap as a JPEG file with quality level 50.
         myEncoderParameter = new EncoderParameter(myEncoder, 50L);
         myEncoderParameters.Param[0] = myEncoderParameter;
         myBitmap.Save(@"G:\Eigene Bilder\Flugzeuge\Ordner\Shapes050.jpg", myImageCodecInfo, myEncoderParameters);

         // Save the bitmap as a JPEG file with quality level 75.
         myEncoderParameter = new EncoderParameter(myEncoder, 75L);
         myEncoderParameters.Param[0] = myEncoderParameter;
         myBitmap.Save(@"G:\Eigene Bilder\Flugzeuge\Ordner\Shapes075.jpg", myImageCodecInfo, myEncoderParameters);
     }
     private static ImageCodecInfo GetEncoderInfo(String mimeType)
     {
         int j;
         ImageCodecInfo[] encoders;
         encoders = ImageCodecInfo.GetImageEncoders();
         for (j = 0; j < encoders.Length; ++j)
         {
             if (encoders[j].MimeType == mimeType)
                 return encoders[j];
         }
         return null ;
     }
 }
 
    
}
