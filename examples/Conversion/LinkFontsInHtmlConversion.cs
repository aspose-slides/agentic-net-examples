using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Presentation presentation = new Presentation("input.pptx");

        // Create HTML export options
        HtmlOptions htmlOptions = new HtmlOptions();

        // Use a custom HTML formatter that embeds all fonts in WOFF format
        HtmlFormatter formatter = HtmlFormatter.CreateCustomFormatter(new EmbedAllFontsHtmlController());
        htmlOptions.HtmlFormatter = formatter;

        // Save the presentation as a single HTML file with all fonts linked
        presentation.Save("output.html", SaveFormat.Html, htmlOptions);
    }
}