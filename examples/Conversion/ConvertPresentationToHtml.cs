using System;

class Program
{
    static void Main(string[] args)
    {
        // Input PowerPoint file path
        string inputPath = "input.pptx";
        // Output HTML file path
        string outputPath = "output.html";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Set HTML export options to remove cropped picture areas
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
            htmlOptions.DeletePicturesCroppedAreas = true;

            // Save the presentation as HTML with the specified options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
        }
    }
}