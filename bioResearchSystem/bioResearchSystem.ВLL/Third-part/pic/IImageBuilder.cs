using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.ВLL.Third_part.pic
{
    public interface IImageBuilder
    {
        public byte[] ConvertImageToBytes(IFormFile pictureFile);
        public string ConvertBytesToImage(byte[] bytes);
    }
}
