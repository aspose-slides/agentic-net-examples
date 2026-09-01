// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export presentation to high DPI JPEG using C#

//

// Description:

// Demonstrates how to export each slide of a PowerPoint presentation to a

// high‑resolution JPEG image (300 DPI) using Aspose.Slides for .NET. The example

// loads a PPTX file, calculates the required scaling factor, renders each slide

// to a JPEG image, and saves the images to an output folder. It also shows basic

// error handling and optional saving of the presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Export, Presentation,

// High DPI, Image Export, Slide Rendering, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX slides to high‑resolution JPEG files.

// - Build .NET tools for batch processing of PowerPoint presentations.

// - Generate image assets for web or print from slide decks.

// - Validate slide rendering quality before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace PresentationToJpeg

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation path

            string inputPath = "input.pptx";

            // Output directory for JPEG images

            string outputDir = "output";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Ensure output directory exists

            Directory.CreateDirectory(outputDir);



            try

            {

                // Load presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Calculate scaling factor for 300 DPI (1 point = 1/72 inch)

                    float scaleFactor = 300f / 72f; // 4.1666667



                    // Export each slide to JPEG with the calculated scale

                    foreach (ISlide slide in presentation.Slides)

                    {

                        using (IImage image = slide.GetImage(scaleFactor, scaleFactor))

                        {

                            string outputPath = Path.Combine(outputDir, $"Slide_{slide.SlideNumber}.jpg");

                            image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);

                        }

                    }



                    // Save presentation before exit (optional, can overwrite original)

                    presentation.Save(inputPath, SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported for this operation.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URLs or web services)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

