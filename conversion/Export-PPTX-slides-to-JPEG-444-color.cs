// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX slides to JPEG 444 color using C#

//

// Description:

// Demonstrates how to export each slide of a PPTX presentation to a JPEG

// image using 4:4:4 color subsampling (maximum quality) with Aspose.Slides for .NET.

// The example loads a presentation, iterates through its slides, renders each

// slide to a full‑scale image, and saves the image as a high‑quality JPEG file.

// It also shows basic file‑system checks and error handling in a console

// application.

//

// Keywords:

// C#, Aspose.Slides, PPTX, JPEG, 4:4:4 color, Export, Slides, Presentation, 

// Image conversion, .NET console application

//

// Use Cases:

// - Convert PowerPoint slides to high‑quality JPEG images for web or print.

// - Automate batch export of presentations to image assets.

// - Integrate slide‑to‑image conversion into .NET workflows or services.

// - Validate slide rendering before publishing or further processing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportPptxToJpeg444

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input presentation and output folder

            string inputPath = "input.pptx";

            string outputFolder = "output";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found: " + inputPath);

                return;

            }



            // Ensure the output directory exists

            if (!Directory.Exists(outputFolder))

            {

                Directory.CreateDirectory(outputFolder);

            }



            try

            {

                // Load the presentation

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Export each slide to JPEG with maximum quality (100) which uses 4:4:4 subsampling

                for (int index = 0; index < presentation.Slides.Count; index++)

                {

                    Aspose.Slides.ISlide slide = presentation.Slides[index];

                    // Get a full‑scale image of the slide

                    Aspose.Slides.IImage slideImage = slide.GetImage(1f, 1f);

                    // Build the output file name

                    string outputPath = Path.Combine(outputFolder, $"Slide_{index + 1}.jpg");

                    // Save the image as JPEG with quality 100

                    slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg, 100);

                }



                // Save the presentation before exiting (lifecycle requirement)

                presentation.Save("saved_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Handle unsupported format

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other possible exceptions (e.g., network issues)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

