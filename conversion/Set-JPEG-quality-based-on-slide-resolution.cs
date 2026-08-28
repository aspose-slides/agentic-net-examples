// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set JPEG quality based on slide resolution using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, evaluate each slide's

// width, choose a JPEG compression quality based on that resolution, and

// export the slides as JPEG images using Aspose.Slides for .NET. The example

// also shows basic error handling and saving the original presentation.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, JPEG, Image Export, Slide Resolution,

// Quality, Presentation Processing, .NET

//

// Use Cases:

// - Export slides to JPEG with quality adjusted to slide size.

// - Build automation tools that adapt image compression based on slide dimensions.

// - Integrate conditional image export into .NET PowerPoint processing pipelines.

// - Validate and preview slide images before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SetJpegQualityExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Path to the source presentation

            string sourcePath = "input.pptx";



            // Verify that the source file exists

            if (!File.Exists(sourcePath))

            {

                Console.WriteLine("Source file not found: " + sourcePath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation pres = new Presentation(sourcePath))

                {

                    // Determine slide size to decide quality level

                    ISlideSize slideSize = pres.SlideSize;

                    float slideWidth = slideSize.Size.Width;



                    // Define quality based on resolution threshold (example: width > 720 points)

                    int jpegQuality = (slideWidth > 720f) ? 85 : 60;



                    // Export each slide as JPEG with the selected quality

                    for (int index = 0; index < pres.Slides.Count; index++)

                    {

                        ISlide slide = pres.Slides[index];

                        // Get image at original scale

                        IImage image = slide.GetImage(1f, 1f);

                        string outputFile = $"Slide_{index + 1}.jpg";

                        // Save with JPEG format and specified quality (int cast required)

                        image.Save(outputFile, ImageFormat.Jpeg, jpegQuality);

                        image.Dispose();

                    }



                    // Save the (unchanged) presentation before exiting

                    pres.Save("output.pptx", SaveFormat.Pptx);

                }

            }

            catch (PptxUnsupportedFormatException ex)

            {

                // Handle unsupported file format

                Console.WriteLine("Unsupported file format: " + ex.Message);

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}

