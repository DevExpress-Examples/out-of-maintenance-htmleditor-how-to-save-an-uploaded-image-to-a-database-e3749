Imports System.Web.Mvc
Imports DevExpress.Web
Imports DevExpress.Web.Mvc

Namespace SaveImageToDB.Controllers
	Public Class HomeController
		Inherits Controller

		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function HtmlEditorPartial() As ActionResult
			Return PartialView()
		End Function

		Public Function ImageUpload() As ActionResult
			Dim fileUploadComplete As FileSavingEventHandler = Sub(s, e) DBUtils.SaveImageToDB(e.UploadedFile.FileBytes)

			HtmlEditorExtension.SaveUploadedFile("htmlEditor", HtmlEditorDemosHelper.ImageUploadValidationSettings, HtmlEditorDemosHelper.UploadDirectory, fileUploadComplete)
			Return Nothing
		End Function
	End Class

	Public Class HtmlEditorDemosHelper
		Public Const ImagesDirectory As String = "~/Content/Images/"
		Public Const ThumbnailsDirectory As String = "~/Content/Thumbnails/"
		Public Const UploadDirectory As String = ImagesDirectory & "Upload/"

		Public Shared ReadOnly ImageUploadValidationSettings As UploadControlValidationSettings = New UploadControlValidationSettings With {.AllowedFileExtensions = New String() { ".jpg", ".jpeg", ".jpe", ".gif" }, .MaxFileSize = 4000000}
	End Class
End Namespace