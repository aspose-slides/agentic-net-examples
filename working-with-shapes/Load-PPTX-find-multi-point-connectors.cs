using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesConnectorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation with proper exception handling
            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is a connector
                            Connector connector = shape as Connector;
                            if (connector != null)
                            {
                                // Check the number of adjustment points
                                if (connector.Adjustments.Count > 2)
                                {
                                    // Log the unique identifier of the connector
                                    Console.WriteLine("Connector with more than two adjustment points found. UniqueId: " + connector.UniqueId);
                                }
                            }
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptUnsupportedFormatException)
            {
                Console.WriteLine("The presentation file format is not supported (PPT).");
            }
            catch (PptxUnsupportedFormatException)
            {
                Console.WriteLine("The presentation file format is not supported (PPTX).");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The operation is not supported for the given file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}