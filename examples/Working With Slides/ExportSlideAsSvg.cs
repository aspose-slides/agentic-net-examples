using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Load the existing PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Export the first slide (index 0) to an SVG file
        using (FileStream svgFile = File.Create("slide_1.svg"))
        {
            presentation.Slides[0].WriteAsSvg(svgFile);
        }

        // Save the presentation (required before exiting)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}