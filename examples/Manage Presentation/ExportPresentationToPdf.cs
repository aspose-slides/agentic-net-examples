using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
        // Export the presentation to PDF format
        presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf);
        // Release resources
        presentation.Dispose();
    }
}