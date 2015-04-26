using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zeje.Core
{
    public class ImageResult : ActionResult
    {
        public ImageResult() { }

        public byte[] byteStream;

        /// <summary>主要需要重写的方法
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            HttpResponseBase response = context.HttpContext.Response;
            // 设置 HTTP Header
            response.ContentType = "image/jpeg";
            response.Cache.SetCacheability(HttpCacheability.Public);
            response.BufferOutput = false;

            // 将图像流写入响应流中
            context.HttpContext.Response.OutputStream.Write(byteStream, 0, byteStream.Count());
        }

        //public ActionResult ProductShow(int PictureID)
        //{
        //    return new ImageResult() {
        //        byteStream = PictureRepository.Get(PictureID) .ImageOriginal;
        //    };
        //}
    }
}