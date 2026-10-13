// -----------------------------------------------------------------------------
// Example: Export First Slide to SVG with Vector Preservation using Aspose.Slides
//
// Description:
// This console application loads a PowerPoint PPTX file, exports the first
// slide to an SVG file while preserving all vector data, and then saves the
// presentation back to its original location. It demonstrates how to use
// Aspose.Slides for .NET to generate high‑quality SVG assets from slides.
// The code checks for the existence of the input file and handles any runtime
// exceptions that may occur during processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG export, vector data, slide conversion
//
// Use Cases:
// - Automate conversion of PPTX slides to scalable SVG graphics for web publishing.
// - Generate high‑resolution vector assets from presentations for design workflows.
// - Integrate slide‑to‑SVG conversion into .NET applications or CI pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.10.0.
// -----------------------------------------------------------------------------
using System;

namespace AsposeSlidesSvgExport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputSvgPath = args.Length > 1 ? args[1] : "slide1.svg";

            if (!System.IO.File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

                using (System.IO.FileStream svgStream = new System.IO.FileStream(outputSvgPath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    firstSlide.WriteAsSvg(svgStream);
                }

                // Save the presentation back to its original file (no modifications made, but ensures proper closure)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                Console.WriteLine("First slide exported to SVG successfully: " + outputSvgPath);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
