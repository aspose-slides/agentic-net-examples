using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyDecorativeFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides
                    foreach (Aspose.Slides.ISlide slide in pres.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            // Mark the shape as decorative (non‑interactive visual element)
                            shape.IsDecorative = true;
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            // Handle specific format‑unsupported exceptions
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                Console.WriteLine("The PPT format is not supported.");
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                Console.WriteLine("The PPTX format is not supported.");
            }
            // Handle generic unsupported format exception
            catch (NotSupportedException)
            {
                Console.WriteLine("The file format is not supported.");
            }
            // Handle any other unexpected errors
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}