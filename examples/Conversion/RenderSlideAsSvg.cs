using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");
        // Create a file stream to write the SVG output
        Stream svgStream = File.Create("slide_1.svg");
        // Render the first slide as SVG
        pres.Slides[0].WriteAsSvg(svgStream);
        // Close the SVG stream
        svgStream.Close();
        // Save the (potentially modified) presentation before exiting
        pres.Save("output.pptx", SaveFormat.Pptx);
        // Release resources
        pres.Dispose();
    }
}