using System.Web.Mvc;
using DevExpress.Web;
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
            FileSavingEventHandler fileUploadComplete = (s, e) => {
                DBUtils.SaveImageToDB(e.UploadedFile.FileBytes);
            };

            HtmlEditorExtension.SaveUploadedFile("htmlEditor", HtmlEditorDemosHelper.ImageUploadValidationSettings, HtmlEditorDemosHelper.UploadDirectory, fileUploadComplete);
            return null;
        }
    }

    public class HtmlEditorDemosHelper {
        public const string ImagesDirectory = "~/Content/Images/";
        public const string ThumbnailsDirectory = "~/Content/Thumbnails/";
        public const string UploadDirectory = ImagesDirectory + "Upload/";

        public static readonly UploadControlValidationSettings ImageUploadValidationSettings = new UploadControlValidationSettings {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif" },
            MaxFileSize = 4000000
        };
    }
}