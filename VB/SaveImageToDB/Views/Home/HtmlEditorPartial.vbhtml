@Imports SaveImageToDB.Controllers

@Html.DevExpress().HtmlEditor( _
    Sub(settings)
            settings.Name = "htmlEditor"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "HtmlEditorPartial"}
            settings.SettingsDialogs.InsertImageDialog.SettingsImageUpload.UploadCallbackRouteValues = New With {.Controller = "Home", .Action = "ImageUpload"}
            settings.SettingsDialogs.InsertImageDialog.SettingsImageUpload.UploadFolder = HtmlEditorDemosHelper.UploadDirectory
            settings.SettingsDialogs.InsertImageDialog.SettingsImageUpload.ValidationSettings.Assign(HtmlEditorDemosHelper.ImageUploadValidationSettings)
    End Sub).GetHtml()