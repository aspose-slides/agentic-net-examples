using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set the first slide number to start numbering at five
        presentation.FirstSlideNumber = 5;

        // Output file path
        string outputPath = "CustomSlideNumberPresentation.pptx";

        // Save the presentation before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}