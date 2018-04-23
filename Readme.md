# HtmlEditor - How to save an uploaded image to a database


<p><strong>UPDATED:</strong></p>
<p><br>Starting with version 15.1, the HtmlEditor extension has a similar functionality that allows accomplishing a similar task with less effort and does not require so much extra code. See the <a href="http://demos.devexpress.com/MVCxHTMLEditorDemos/Dialogs/UploadProcessing">Image Upload Processing</a> demo to learn more about this new functionality.</p>
<p><br>The example shows how to save an image uploaded via UploadControl to a database. The main idea is to get an uploaded file using the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcUploadControlExtension_GetUploadedFilestopic"><u>UploadControlExtension.GetUploadedFiles</u></a> method in the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcMVCxHtmlEditorImageUploadSettings_UploadCallbackRouteValuestopic"><u>UploadCallbackRouteValues</u></a> Action and execute custom SaveImage code.</p>

<br/>


