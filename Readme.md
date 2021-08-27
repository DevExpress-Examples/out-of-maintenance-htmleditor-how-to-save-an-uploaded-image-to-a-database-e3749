<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128552333/14.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3749)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[HomeController.cs](./CS/SaveImageToDB/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/SaveImageToDB/Controllers/HomeController.vb))**
* [Utils.cs](./CS/SaveImageToDB/Models/Utils.cs) (VB: [Utils.vb](./VB/SaveImageToDB/Models/Utils.vb))
* [HtmlEditorPartial.cshtml](./CS/SaveImageToDB/Views/Home/HtmlEditorPartial.cshtml)
* [Index.cshtml](./CS/SaveImageToDB/Views/Home/Index.cshtml)
<!-- default file list end -->
# HtmlEditor - How to save an uploaded image to a database


<p><strong>UPDATED:</strong></p>
<p><br>Starting with version 15.1, the HtmlEditor extension has a similar functionality that allows accomplishing a similar task with less effort and does not require so much extra code. See the <a href="http://demos.devexpress.com/MVCxHTMLEditorDemos/Dialogs/UploadProcessing">Image Upload Processing</a> demo to learn more about this new functionality.</p>
<p><br>The example shows how to save an image uploaded via UploadControl to a database. The main idea is to get an uploaded file using the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcUploadControlExtension_GetUploadedFilestopic"><u>UploadControlExtension.GetUploadedFiles</u></a> method in the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcMVCxHtmlEditorImageUploadSettings_UploadCallbackRouteValuestopic"><u>UploadCallbackRouteValues</u></a> Action and execute custom SaveImage code.</p>

<br/>


