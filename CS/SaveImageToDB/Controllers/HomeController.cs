using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.Mvc;

namespace SaveImageToDB.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult HtmlEditorPartial() {
            return PartialView();
        }

        public ActionResult ImageUpload() {
            HtmlEditorDemosHelper.SaveUploadedImage(HtmlEditorDemosHelper.ImageUploadValidationSettings);
            return null;
        }
    }

    public class HtmlEditorDemosHelper {
        public const string ImagesDirectory = "~/Content/Images/";
        public const string ThumbnailsDirectory = "~/Content/Thumbnails/";
        public const string UploadDirectory = ImagesDirectory + "Upload/";

        public static void SaveUploadedImage(ValidationSettings validationSettings) {
            EventHandler<FileUploadCompleteEventArgs> fileUploadComplete = (object sender, FileUploadCompleteEventArgs e) => {
                DBUtils.SaveImageToDB(e.UploadedFile.FileBytes);

                string fileName = e.UploadedFile.FileName;
                string filePath = HttpContext.Current.Request.MapPath(Path.Combine(UploadDirectory, fileName));
                e.UploadedFile.SaveAs(filePath);
                e.CallbackData = fileName;
            };
            UploadControlExtension.GetUploadedFiles(GetUploadControlID(), validationSettings, fileUploadComplete);
        }

        protected static string GetUploadControlID() {
            string helperParamName = DevExpress.Web.ASPxClasses.Internal.RenderUtils.HelperUploadingCallbackQueryParamName;
            string uploadParamName = DevExpress.Web.ASPxClasses.Internal.RenderUtils.UploadingCallbackQueryParamName;
            
            return HttpContext.Current.Request.Params[helperParamName] ?? HttpContext.Current.Request.Params[uploadParamName];
        }

        public static readonly ValidationSettings ImageUploadValidationSettings = new ValidationSettings {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif" },
            MaxFileSize = 4000000
        };
    }
}