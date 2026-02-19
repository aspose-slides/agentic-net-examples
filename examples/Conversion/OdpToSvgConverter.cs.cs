using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OdpToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define directories and file names
            string dataDir = @"C:\Data";
            string inputOdpPath = Path.Combine(dataDir, "input.odp");
            string outputSvgPath = Path.Combine(dataDir, "output.svg");
            string outputPresPath = Path.Combine(dataDir, "output.pptx");

            // Load the ODP presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputOdpPath))
            {
                // Ensure there is at least one slide
                if (pres.Slides.Count > 0)
                {
                    // Convert the first slide to SVG
                    using (FileStream svgStream = new FileStream(outputSvgPath, FileMode.Create))
                    {
                        pres.Slides[0].WriteAsSvg(svgStream);
                    }
                }

                // Save the presentation (required before exit)
                pres.Save(outputPresPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}