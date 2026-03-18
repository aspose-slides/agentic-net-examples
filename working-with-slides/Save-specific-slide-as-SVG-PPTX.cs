using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.pptx";
            string outputSvgPath = "slide_1.svg";
            string outputPresPath = "output.pptx";

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath))
            {
                // Export the first slide as SVG
                using (FileStream svgStream = new FileStream(outputSvgPath, FileMode.Create, FileAccess.Write))
                {
                    pres.Slides[0].WriteAsSvg(svgStream);
                }

                // Save the (unchanged) presentation before exiting
                pres.Save(outputPresPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}