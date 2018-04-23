Imports System.IO
Imports System.Web.Mvc
Imports DevExpress.Web.ASPxUploadControl
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
            HtmlEditorDemosHelper.SaveUploadedImage(HtmlEditorDemosHelper.ImageUploadValidationSettings)
            Return Nothing
        End Function
    End Class

    Public Class HtmlEditorDemosHelper
        Public Const ImagesDirectory As String = "~/Content/Images/"
        Public Const ThumbnailsDirectory As String = "~/Content/Thumbnails/"
        Public Const UploadDirectory As String = ImagesDirectory & "Upload/"

        Public Shared Sub SaveUploadedImage(ByVal validationSettings As ValidationSettings)
            Dim fileUploadComplete As EventHandler(Of FileUploadCompleteEventArgs) = Sub(sender As Object, e As FileUploadCompleteEventArgs)
                                                                                         DBUtils.SaveImageToDB(e.UploadedFile.FileBytes)

                                                                                         Dim fileName As String = e.UploadedFile.FileName
                                                                                         Dim filePath As String = HttpContext.Current.Request.MapPath(Path.Combine(UploadDirectory, fileName))
                                                                                         e.UploadedFile.SaveAs(filePath)
                                                                                         e.CallbackData = fileName
                                                                                     End Sub
            UploadControlExtension.GetUploadedFiles(GetUploadControlID(), validationSettings, fileUploadComplete)
        End Sub

        Protected Shared Function GetUploadControlID() As String
            Dim helperParamName As String = DevExpress.Web.ASPxClasses.Internal.RenderUtils.HelperUploadingCallbackQueryParamName
            Dim uploadParamName As String = DevExpress.Web.ASPxClasses.Internal.RenderUtils.UploadingCallbackQueryParamName

            Return If(HttpContext.Current.Request.Params(helperParamName), HttpContext.Current.Request.Params(uploadParamName))
        End Function

        Public Shared ReadOnly ImageUploadValidationSettings As ValidationSettings = New ValidationSettings With {.AllowedFileExtensions = New String() {".jpg", ".jpeg", ".jpe", ".gif"}, .MaxFileSize = 4000000}
    End Class
End Namespace