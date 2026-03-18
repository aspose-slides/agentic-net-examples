using System;
using System.IO;
using Aspose.Slides.Export;

namespace ExportSlideAsSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input PowerPoint file
                string inputPath = "input.pptx";
                // Output SVG file for the selected slide
                string outputSvgPath = "slide_1.svg";
                // Path to save the (potentially modified) presentation
                string savedPresentationPath = "output.pptx";

                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Index of the slide to export (0‑based)
                    int slideIndex = 0;

                    if (slideIndex < 0 || slideIndex >= pres.Slides.Count)
                    {
                        throw new ArgumentOutOfRangeException("slideIndex", "Slide index is out of range.");
                    }

                    // Export the selected slide as SVG
                    using (FileStream svgStream = new FileStream(outputSvgPath, FileMode.Create, FileAccess.Write))
                    {
                        pres.Slides[slideIndex].WriteAsSvg(svgStream);
                    }

                    // Save the presentation before exiting (optional if no changes were made)
                    pres.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}