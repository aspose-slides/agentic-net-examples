using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
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
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            // Check if the shape is a connector
                            if (shape is Aspose.Slides.Connector)
                            {
                                Aspose.Slides.Connector connector = (Aspose.Slides.Connector)shape;

                                // Log connectors that have more than two adjustment points
                                if (connector.Adjustments.Count > 2)
                                {
                                    Console.WriteLine($"Connector ID: {connector.OfficeInteropShapeId}");
                                }
                            }
                        }
                    }

                    // Save the presentation before exiting
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine($"Unsupported PPTX format: {ex.Message}");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine($"Unsupported PPT format: {ex.Message}");
            }
            catch (Aspose.Slides.PptCorruptFileException ex)
            {
                Console.WriteLine($"Corrupt presentation file: {ex.Message}");
            }
            catch (Exception ex)
            {
                // General exception handling for unexpected errors (e.g., I/O issues)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}