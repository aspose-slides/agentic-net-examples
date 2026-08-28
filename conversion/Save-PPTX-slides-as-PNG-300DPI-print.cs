// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Save PPTX slides as PNG 300DPI print using C#

//

// Description:

// Demonstrates how to load a PPTX file, export each slide as a PNG image 

// with approximately 300 DPI resolution, and optionally save a copy of the 

// presentation using Aspose.Slides for .NET. The example includes argument 

// handling, file validation, and basic error handling suitable for console 

// applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Save, Pptx, Slides, 

// 300Dpi, Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX slides to high‑resolution PNG images for printing or web use.

// - Automate batch processing of presentations in .NET tools.

// - Generate image assets from PowerPoint files for documentation or publishing.

// - Validate and copy presentations as part of a workflow.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlidesToPng

{

    class Program

    {

        static void Main(string[] args)

        {

            // Expect input file path and output folder as arguments

            if (args.Length < 2)

            {

                Console.WriteLine("Usage: SlidesToPng <input-pptx> <output-folder>");

                return;

            }



            string inputPath = args[0];

            string outputFolder = args[1];



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Ensure output folder exists

            if (!Directory.Exists(outputFolder))

            {

                Directory.CreateDirectory(outputFolder);

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Scale factor to achieve ~300 DPI (default DPI is 96)

                float scaleFactor = 300f / 96f;



                // Export each slide as PNG with the calculated scale

                for (int index = 0; index < presentation.Slides.Count; index++)

                {

                    ISlide slide = presentation.Slides[index];

                    using (IImage image = slide.GetImage(scaleFactor, scaleFactor))

                    {

                        string outputFile = Path.Combine(outputFolder, $"slide_{index + 1}.png");

                        image.Save(outputFile, Aspose.Slides.ImageFormat.Png);

                    }

                }



                // Save the presentation before exiting (as a copy)

                string savedPresentationPath = Path.Combine(outputFolder, "presentation_copy.pptx");

                presentation.Save(savedPresentationPath, SaveFormat.Pptx);



                // Clean up

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

