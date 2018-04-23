@imports SaveImageToDB.Controllers

@Html.DevExpress().HtmlEditor( _
    Sub(settings)
        settings.Name = "htmlEditor"
        settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "HtmlEditorPartial"}
        settings.SettingsImageUpload.UploadCallbackRouteValues = New With {.Controller = "Home", .Action = "ImageUpload"}
        settings.SettingsImageUpload.UploadImageFolder = HtmlEditorDemosHelper.UploadDirectory
        settings.SettingsImageUpload.ValidationSettings.Assign(HtmlEditorDemosHelper.ImageUploadValidationSettings)
    End Sub).GetHtml()