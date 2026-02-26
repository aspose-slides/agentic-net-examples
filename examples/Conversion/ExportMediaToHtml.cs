using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Configure HTML5 export options to extract media files to a folder
        Aspose.Slides.Export.Html5Options htmlOptions = new Aspose.Slides.Export.Html5Options();
        htmlOptions.OutputPath = "output_media";

        // Export the presentation to HTML5 format (media files are saved to OutputPath)
        presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html5, htmlOptions);

        // Release resources
        presentation.Dispose();
    }
}