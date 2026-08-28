// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set custom slide size and export JPG using C#

//

// Description:

// Demonstrates how to set a custom slide size and export each slide as a JPEG

// image using C# and Aspose.Slides for .NET. The example loads an existing PPTX,

// changes the slide dimensions, saves the modified presentation, and then

// generates JPEG files for all slides in a specified output folder. This pattern

// is useful for automating PowerPoint processing tasks such as resizing and

// image extraction in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Custom Slide Size, Export,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate resizing of PowerPoint slides to custom dimensions.

// - Generate JPEG images from each slide for web preview or documentation.

// - Build C# utilities for batch processing of PPTX files.

// - Integrate slide size adjustment and image export into larger .NET workflows.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideExportApp

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output paths

            string inputPath = "input.pptx";

            string outputPresentationPath = "output.pptx";

            string outputImageFolder = "ExportedImages";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Ensure output folder exists

            if (!Directory.Exists(outputImageFolder))

            {

                Directory.CreateDirectory(outputImageFolder);

            }



            try

            {

                // Load presentation

                Presentation presentation = new Presentation(inputPath);



                // Set custom slide size (example: 800x600 points) and ensure content fits

                presentation.SlideSize.SetSize(800f, 600f, SlideSizeScaleType.EnsureFit);



                // Save the modified presentation before exiting

                presentation.Save(outputPresentationPath, SaveFormat.Pptx);



                // Export each slide as JPEG image

                for (int index = 0; index < presentation.Slides.Count; index++)

                {

                    IImage slideImage = presentation.Slides[index].GetImage(1f, 1f);

                    string imagePath = Path.Combine(outputImageFolder, $"Slide_{index + 1}.jpg");

                    slideImage.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);

                }



                // Clean up

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

