// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Save PPTX as PNG thumbnail 200px using C#

//

// Description:

// Demonstrates how to generate 200 px PNG thumbnails for each slide of a PPTX 

// file using C# and Aspose.Slides for .NET. The example loads a presentation, 

// calculates a scaling factor to limit the longest side of each slide to 200 

// pixels, creates thumbnail images for all slides, and saves them to a 

// specified output folder. This pattern can be used in console utilities or 

// automated workflows that require low‑resolution previews of PowerPoint 

// presentations.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Thumbnail, 200Px, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Generate 200 px PNG thumbnails for all slides in a PPTX.

// - Build command‑line tools for previewing PowerPoint presentations.

// - Integrate slide thumbnail creation into .NET applications or CI pipelines.

// - Automate batch processing of PPTX files to produce lightweight image assets.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ThumbnailGenerator

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input PPTX file path

            string inputPath = "input.pptx";

            // Output folder for PNG thumbnails

            string outputFolder = "thumbnails";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Ensure output directory exists

            if (!Directory.Exists(outputFolder))

            {

                Directory.CreateDirectory(outputFolder);

            }



            try

            {

                // Load presentation

                Presentation pres = new Presentation(inputPath);



                // Determine scaling factor to limit max dimension to 200 pixels

                float slideWidth = pres.SlideSize.Size.Width;

                float slideHeight = pres.SlideSize.Size.Height;

                float maxDimension = Math.Max(slideWidth, slideHeight);

                float scale = 200f / maxDimension;



                int slideIndex = 0;

                foreach (ISlide slide in pres.Slides)

                {

                    // Generate thumbnail with calculated scale

                    using (IImage thumbnail = slide.GetImage(scale, scale))

                    {

                        string outputPng = Path.Combine(outputFolder, $"slide_{slideIndex}.png");

                        thumbnail.Save(outputPng, ImageFormat.Png);

                    }

                    slideIndex++;

                }



                // Save presentation before exit (optional)

                pres.Save(inputPath, SaveFormat.Pptx);

                pres.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URLs or web services)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

