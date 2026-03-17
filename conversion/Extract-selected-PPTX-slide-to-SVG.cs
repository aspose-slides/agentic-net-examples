using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Path to the source PPTX file
            string sourcePath = "input.pptx";
            // Path where the SVG of the chosen slide will be saved
            string outputSvgPath = "slide_1.svg";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath);
            // Get the first slide (index 0). Change the index to select a different slide.
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Save the slide as an SVG file
            using (FileStream svgStream = new FileStream(outputSvgPath, FileMode.Create, FileAccess.Write))
            {
                slide.WriteAsSvg(svgStream);
            }

            // Save the presentation before exiting (optional, ensures any changes are persisted)
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}