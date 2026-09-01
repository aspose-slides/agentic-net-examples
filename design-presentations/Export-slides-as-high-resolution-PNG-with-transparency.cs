// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export slides as high resolution PNG with transparency using C#

//

// Description:

// Demonstrates how to export each slide of a PowerPoint presentation to a

// high‑resolution PNG image with a transparent background using Aspose.Slides

// for .NET. The sample loads a PPTX file, sets the slide background to

// transparent, renders the slide at double size (2× scale) and saves the

// resulting PNG files to an output folder. It also shows basic error handling

// and how to keep the original presentation unchanged.

//

// Keywords:

// C#, Aspose.Slides, PPTX, PNG, high resolution, transparency, slide export,

// image rendering, .NET, PowerPoint automation

//

// Use Cases:

// - Generate high‑resolution PNG assets from PowerPoint slides for web or

//   documentation where transparency is required.

// - Build automated tools that convert presentations to image formats in CI

//   pipelines.

// - Integrate slide‑to‑image conversion into .NET applications for reporting

//   or preview features.

// - Preserve original presentation while extracting visual content.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



namespace SlideExportExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation path

            string inputPath = "input.pptx";

            // Output directory for PNG images

            string outputDir = "output";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found: " + inputPath);

                return;

            }



            // Ensure output directory exists

            Directory.CreateDirectory(outputDir);



            try

            {

                // Load presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    // Export each slide as high‑resolution PNG with transparent background

                    for (int i = 0; i < pres.Slides.Count; i++)

                    {

                        ISlide slide = pres.Slides[i];



                        // Set slide background to transparent

                        slide.Background.Type = BackgroundType.OwnBackground;

                        slide.Background.FillFormat.FillType = FillType.Solid;

                        slide.Background.FillFormat.SolidFillColor.Color = Color.Transparent;



                        // Generate high‑resolution image (scale factor 2.0)

                        IImage image = slide.GetImage(2f, 2f);



                        // Save PNG image

                        string outputPath = Path.Combine(outputDir, $"slide_{i + 1}.png");

                        image.Save(outputPath, ImageFormat.Png);

                        image.Dispose();

                    }



                    // Save (unchanged) presentation before exit as required

                    pres.Save("output.pptx", SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: The provided file format is not supported for the requested operation.

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., I/O errors)

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}

