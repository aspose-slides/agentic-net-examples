// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export slide backgrounds to JPEG original resolution using C#

//

// Description:

// Demonstrates how to export each slide background as a JPEG image at the

// original slide resolution using C# and Aspose.Slides for .NET. The example

// loads a PPTX file, iterates through its slides, renders each slide to an

// image with a scale factor of 1.0 to preserve the native size, saves the

// images as JPEG files, and finally saves the presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Export, Slide, 

// Backgrounds, Jpeg, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate extraction of slide backgrounds as high‑resolution JPEGs.

// - Build .NET utilities for PowerPoint content conversion.

// - Integrate slide‑to‑image rendering into reporting or publishing pipelines.

// - Preserve original slide dimensions when generating image assets.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputDir = "output_images";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        if (!Directory.Exists(outputDir))

        {

            Directory.CreateDirectory(outputDir);

        }



        try

        {

            using (Presentation presentation = new Presentation(inputPath))

            {

                foreach (ISlide slide in presentation.Slides)

                {

                    // Preserve original resolution by using scale factor 1.0

                    IImage image = slide.GetImage(1f, 1f);

                    string imagePath = Path.Combine(outputDir, $"Slide_{slide.SlideNumber}.jpg");

                    image.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);

                    image.Dispose();

                }



                // Save presentation before exit

                string savedPath = "saved_output.pptx";

                presentation.Save(savedPath, SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

