// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to BMP preserving theme colors using C#

//

// Description:

// Demonstrates how to export each slide of a PPTX file to BMP images while

// preserving the presentation's theme colors using Aspose.Slides for .NET.

// The example loads a presentation, iterates through its slides, converts each

// slide to a BMP image, and saves the images to an output folder. It also

// shows how to save the presentation after processing.

//

// Keywords:

// C#, PowerPoint, PPTX, BMP, Aspose.Slides for .NET, Export, Theme Colors,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX slides to BMP format while keeping theme colors intact.

// - Automate batch image extraction from PowerPoint presentations.

// - Integrate slide-to-image conversion into .NET applications.

// - Prepare slide images for further processing or publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideExportExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation path

            string inputPath = "input.pptx";

            // Output directory for BMP images

            string outputDir = "output";



            try

            {

                // Verify input file exists

                if (!File.Exists(inputPath))

                {

                    Console.WriteLine("Input file does not exist.");

                    return;

                }



                // Ensure output directory exists

                if (!Directory.Exists(outputDir))

                {

                    Directory.CreateDirectory(outputDir);

                }



                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Export each slide to a BMP image

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        // Get the slide image

                        IImage slideImage = presentation.Slides[i].GetImage();

                        // Build output file name

                        string outputPath = Path.Combine(outputDir, $"slide_{i + 1}.bmp");

                        // Save the image as BMP preserving theme colors

                        slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Bmp);

                        slideImage.Dispose();

                    }



                    // Save the presentation before exiting (as required)

                    presentation.Save("saved_output.pptx", SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Handle unsupported format

                Console.WriteLine("Format not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine($"Error: {ex.Message}");

            }

        }

    }

}

