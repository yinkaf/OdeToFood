@ModelType AboutModel
@Code
    ViewData("Title") = "About"
End Code

<h2>@ViewData("Title").</h2>
<h3>@ViewData("Message")</h3>

<p>@Model.Name</p>
<p>Use this area to provide additional information.</p>
