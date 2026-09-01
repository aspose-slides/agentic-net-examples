// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to JPEG default quality using C#

//

// Description:

// Demonstrates how to export each slide of a PPTX file to JPEG images using

// the default quality settings with Aspose.Slides for .NET. The example loads

// a presentation, iterates through its slides, renders each slide to a JPEG

// image, and saves the images to a specified output folder. It also shows basic

// file existence checks and error handling in a console application.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Export, Default Quality,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX presentations to a series of JPEG images with default settings.

// - Automate slide image extraction in .NET tools or services.

// - Prepare slide thumbnails for web galleries or documentation.

// - Validate slide rendering without custom quality parameters.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Input PPTX file path

        string inputPath = "input.pptx";

        // Output directory for JPEG images

        string outputDir = "output";



        // Check if input file exists

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



        try

        {

            // Load the presentation

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Iterate through slides and save each as JPEG with default quality

                for (int i = 0; i < presentation.Slides.Count; i++)

                {

                    ISlide slide = presentation.Slides[i];

                    IImage image = slide.GetImage(1f, 1f);

                    string outputPath = Path.Combine(outputDir, $"Slide_{i + 1}.jpg");

                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);

                }



                // Save the presentation before exiting (no modifications)

                presentation.Save(inputPath, SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

