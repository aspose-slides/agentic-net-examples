using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PPTXToSVG
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the PPTX presentation
            using (Presentation presentation = new Presentation("input.pptx"))
            {
                // Iterate through each slide and save as SVG
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    // Create a file stream for the SVG output
                    using (FileStream svgStream = File.Create($"slide_{index}.svg"))
                    {
                        // Write the current slide as SVG
                        presentation.Slides[index].WriteAsSvg(svgStream);
                    }
                }

                // Save the presentation (required before exiting)
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
    }
}