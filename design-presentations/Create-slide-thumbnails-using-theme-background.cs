// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create slide thumbnails using theme background using C#

//

// Description:

// Demonstrates how to create slide thumbnails using theme background using C# 

// and Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide, Thumbnails, Theme, 

// Background, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate create slide thumbnails using theme background.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

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

            // Input presentation path

            string inputPath = "input.pptx";



            // Verify that the file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Generate a thumbnail for each slide

                for (int index = 0; index < presentation.Slides.Count; index++)

                {

                    ISlide slide = presentation.Slides[index];

                    // Create a full‑scale image (1f, 1f) which includes the current theme background

                    IImage image = slide.GetImage(1f, 1f);

                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), $"Slide_{index + 1}.jpg");

                    // Save the thumbnail as JPEG

                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);

                    image.Dispose();

                }



                // Save the presentation before exiting (no modifications made)

                presentation.Save(inputPath, SaveFormat.Pptx);

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

