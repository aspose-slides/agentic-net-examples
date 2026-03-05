using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Specify the slide(s) to export (1‑based index)
        int[] slideIndices = new int[] { 1 };

        // Export the selected slide to a PDF file
        presentation.Save("slide1.pdf", slideIndices, Aspose.Slides.Export.SaveFormat.Pdf);

        // Release resources
        presentation.Dispose();
    }
}