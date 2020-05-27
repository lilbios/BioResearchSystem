using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace bioResearchSystem.ВLL.Third_part.pic
{
    public static  class ImageConvertor
    {
        public  static string ConvertBytesToImage(byte[] bytes)
        {
            var base64 = Convert.ToBase64String(bytes);
            var imagesrc = string.Format("data:image/jpeg;base64,{0}", base64);
            return imagesrc;
        }

        public static byte[] ConvertImageToBytes(IFormFile pictureFile)
        {
            byte[] bytes = new byte[0];
            using (var fs1 = pictureFile.OpenReadStream())
            using (var ms1 = new MemoryStream())
            {
                fs1.CopyTo(ms1);
                bytes = ms1.ToArray();
            }
            return bytes;
        }
    }
}
