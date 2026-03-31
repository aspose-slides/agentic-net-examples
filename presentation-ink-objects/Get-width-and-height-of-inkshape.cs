using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesInkExample
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

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Format not supported comment
                // The file format may not be supported by Aspose.Slides.
                return;
            }

            // Find the first Ink shape on the first slide
            Aspose.Slides.IShape shape = null;
            Aspose.Slides.Ink.Ink inkShape = null;
            if (presentation.Slides.Count > 0)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                for (int i = 0; i < slide.Shapes.Count; i++)
                {
                    shape = slide.Shapes[i];
                    inkShape = shape as Aspose.Slides.Ink.Ink;
                    if (inkShape != null)
                    {
                        break;
                    }
                }
            }

            if (inkShape == null)
            {
                Console.WriteLine("No Ink shape found in the presentation.");
                // Save the (unchanged) presentation before exit
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
                return;
            }

            // Retrieve Width and Height of the Ink shape
            float inkWidth = inkShape.Width;
            float inkHeight = inkShape.Height;

            Console.WriteLine("Ink Shape Width: " + inkWidth);
            Console.WriteLine("Ink Shape Height: " + inkHeight);

            // Save the presentation before exiting
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }
}