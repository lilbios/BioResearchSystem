using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.ВLL.Third_part.pic
{
    public class ImageConvertor : IImageBuilder
    {
        public string ConvertBytesToImage(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public byte[] ConvertImageToBytes(IFormFile pictureFile)
        {
            throw new NotImplementedException();
        }
    }
}
