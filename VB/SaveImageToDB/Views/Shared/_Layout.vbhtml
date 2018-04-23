<!DOCTYPE HTML>

<html>
<head>
    <title>@ViewBag.Title</title>
    @Html.DevExpress().GetStyleSheets(
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors},
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.HtmlEditor},
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}
) 
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
    @Html.DevExpress().GetScripts( 
        new Script With { .ExtensionSuite = ExtensionSuite.Editors }, 
        new Script With { .ExtensionSuite = ExtensionSuite.HtmlEditor },
        new Script With { .ExtensionSuite = ExtensionSuite.NavigationAndLayout }
) 
</head>

<body>
    @RenderBody()
</body>
</html>
