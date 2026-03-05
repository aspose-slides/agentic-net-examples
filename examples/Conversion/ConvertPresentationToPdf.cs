using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PowerPoint file path
        System.String inputPath = "input.pptx";
        // Output PDF file path
        System.String outputPath = "output.pdf";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Set a custom slide size (width: 800 points, height: 600 points) and ensure content fits
        presentation.SlideSize.SetSize(800f, 600f, Aspose.Slides.SlideSizeScaleType.EnsureFit);

        // Save the presentation as PDF
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

        // Release resources
        presentation.Dispose();
    }
}