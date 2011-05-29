using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using OpenJPEGNet;

namespace SLeek
{
    public static class ImageHelper
    {
        public static Image Decode(byte[] j2cdata)
        {
            Image image = null;

            try
            {
                image = OpenJPEG.DecodeToImage(j2cdata);
            }
            catch
            {

            }
            
            return image;
        }
    }
}
