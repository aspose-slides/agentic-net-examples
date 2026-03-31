using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

namespace ScaleInkShape
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get the first slide (or adjust as needed)
                    ISlide slide = presentation.Slides[0];

                    // Find the first Ink shape on the slide
                    Ink inkShape = null;
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is Ink)
                        {
                            inkShape = (Ink)shape;
                            break;
                        }
                    }

                    if (inkShape == null)
                    {
                        Console.WriteLine("No Ink shape found on the first slide.");
                    }
                    else
                    {
                        // Get container dimensions (slide size)
                        float containerWidth = presentation.SlideSize.Size.Width;
                        float containerHeight = presentation.SlideSize.Size.Height;

                        // Scale the Ink shape to match the container while preserving stroke appearance
                        // Preserve the original brush size (stroke thickness) by not modifying the brush
                        inkShape.Width = containerWidth;
                        inkShape.Height = containerHeight;
                        inkShape.X = 0;
                        inkShape.Y = 0;
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL or other errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}