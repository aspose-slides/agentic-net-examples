// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX slides as high resolution JPEG using C#

//

// Description:

// Demonstrates how to load a PPTX file, optionally preserve any changes by

// re‑saving it, and export each slide as a high‑resolution JPEG image using a

// scaling factor of 2.0 for both dimensions. The example uses Aspose.Slides for

// .NET in a console application and shows the required steps for presentation

// processing and image generation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Export, High Resolution,

// Slide Image, Presentation Processing, Office Automation

//

// Use Cases:

// - Convert each slide of a PPTX presentation to high‑resolution JPEG files.

// - Automate batch image extraction from PowerPoint decks in .NET.

// - Integrate slide‑to‑image conversion into reporting or publishing pipelines.

// - Validate visual output of presentations before distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportSlidesToJpeg

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input presentation path and output directory

            string inputPath = "input.pptx";

            string outputDirectory = "output";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Ensure the output directory exists

            Directory.CreateDirectory(outputDirectory);



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Save the presentation before exiting (preserves any changes)

                    presentation.Save(inputPath, SaveFormat.Pptx);



                    // Export each slide as a high‑resolution JPEG image

                    for (int index = 0; index < presentation.Slides.Count; index++)

                    {

                        // Get the slide

                        ISlide slide = presentation.Slides[index];



                        // Create a high‑resolution thumbnail (scale factor 2.0 for both axes)

                        IImage image = slide.GetImage(2f, 2f);



                        // Build the output file path

                        string outputPath = Path.Combine(outputDirectory, $"Slide_{index + 1}.jpg");



                        // Save the image as JPEG using fully‑qualified ImageFormat

                        image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);



                        // Release the image resources

                        image.Dispose();

                    }

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Handle unsupported format scenario here

                Console.WriteLine("The presentation format is not supported for this operation.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

