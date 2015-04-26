//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Aspose.Words;
//using Aspose.Words.Saving;

//namespace Zeje.Core
//{
//    public class DocumentResult : ActionResult
//    {
//        private readonly Document document;
//        private readonly SaveOptions options;
//        private string documentName;

//        public DocumentResult(Document document, SaveOptions options, string documentName)
//        {
//            this.document = document;
//            this.options = options;
//            this.documentName = documentName;
//        }

//        public override void ExecuteResult(ControllerContext context)
//        {
//            if (document != null)
//            {
//                this.document.Save(System.Web.HttpContext.Current.Response, documentName, ContentDisposition.Inline, this.options);
//            }
//        }
//    }
//}
