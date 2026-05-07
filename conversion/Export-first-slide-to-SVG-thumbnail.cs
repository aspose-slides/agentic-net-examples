using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToSvgExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string svgOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "slide1.svg");
            string presentationSavePath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Export the first slide as SVG using the slide's WriteAsSvg method
                Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
                using (FileStream svgStream = File.Create(svgOutputPath))
                {
                    firstSlide.WriteAsSvg(svgStream);
                }

                // Save the presentation before exiting (required by the task)
                presentation.Save(presentationSavePath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}