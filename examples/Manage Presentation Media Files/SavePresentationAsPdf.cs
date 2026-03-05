using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation instance
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Save the presentation in PPTX format
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Save the presentation in PDF format
        presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf);

        // Release resources
        presentation.Dispose();
    }
}