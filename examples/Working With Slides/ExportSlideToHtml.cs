using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Define the slide index to export (1‑based)
        int[] slideIndices = new int[] { 1 };

        // Export the specified slide to an HTML file
        presentation.Save("slide1.html", slideIndices, Aspose.Slides.Export.SaveFormat.Html);

        // Ensure the presentation is properly disposed
        presentation.Dispose();
    }
}