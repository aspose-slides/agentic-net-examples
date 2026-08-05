// -----------------------------------------------------------------------------
// Example: Load pptx bytearray extract shape thumbnail using C#
//
// Description:
// Demonstrates how to load a PPTX file into a byte array, create a presentation
// from the byte array, extract a thumbnail image of the first shape on the first
// slide, and save both the thumbnail and the presentation using Aspose.Slides for .NET.
// The example includes file existence checks and basic exception handling.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Bytearray, Extract, Thumbnail,
// Shape, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate loading PPTX files from byte arrays and extracting shape thumbnails.
// - Build C# utilities for PowerPoint shape image extraction.
// - Integrate slide and shape processing into .NET applications.
// - Validate and preview shape visuals before publishing or further processing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation file
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Path for the output presentation (saved before exit)
            string outputPresentationPath = "output.pptx";

            // Path for the shape thumbnail image
            string outputImagePath = "shape_thumbnail.png";

            try
            {
                // Load the presentation into a byte array
                byte[] presentationData = File.ReadAllBytes(inputPath);

                // Create a memory stream from the byte array
                using (MemoryStream memoryStream = new MemoryStream(presentationData))
                {
                    // Load the presentation from the memory stream
                    using (Presentation pres = new Presentation(memoryStream))
                    {
                        // Ensure there is at least one slide
                        if (pres.Slides.Count == 0)
                        {
                            Console.WriteLine("The presentation contains no slides.");
                            return;
                        }

                        // Access the first slide
                        ISlide slide = pres.Slides[0];

                        // Ensure the slide contains at least one shape
                        if (slide.Shapes.Count == 0)
                        {
                            Console.WriteLine("The first slide contains no shapes.");
                            return;
                        }

                        // Extract the first shape
                        IShape shape = slide.Shapes[0];

                        // Generate the thumbnail image for the shape
                        using (IImage shapeImage = shape.GetImage())
                        {
                            // Save the thumbnail as PNG
                            shapeImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                        }

                        // Save the presentation before exiting
                        pres.Save(outputPresentationPath, SaveFormat.Pptx);
                    }
                }

                Console.WriteLine("Shape thumbnail saved to: " + outputImagePath);
                Console.WriteLine("Presentation saved to: " + outputPresentationPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
