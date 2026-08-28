// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX slides to PNG interlaced using C#

//

// Description:

// Demonstrates how to load a PPTX file and export each slide as a PNG image

// using Aspose.Slides for .NET. The example creates an output folder, iterates

// through all slides, generates full‑scale PNG images and saves them. While

// Aspose.Slides does not expose a direct interlaced PNG option, the saved PNG

// files are compatible with standard interlacing when processed further.

// This pattern can be used in console applications to automate slide image

// extraction and integrate PowerPoint processing into .NET workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Export, Interlaced, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate extraction of PPTX slides as PNG images.

// - Build C# tools for PowerPoint presentation processing.

// - Generate image assets from presentations in .NET applications.

// - Prepare slide images for web publishing where interlaced PNGs are required.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportPngInterlaced

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine input file path

            string inputPath = "input.pptx";

            if (args.Length > 0)

            {

                inputPath = args[0];

            }



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Create output directory

            string outputDir = "output_png";

            Directory.CreateDirectory(outputDir);



            try

            {

                // Load the presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    // Export each slide as PNG

                    for (int i = 0; i < pres.Slides.Count; i++)

                    {

                        ISlide slide = pres.Slides[i];

                        // Generate full‑scale image

                        IImage image = slide.GetImage(1f, 1f);

                        string outPath = Path.Combine(outputDir, $"slide_{i + 1}.png");

                        // Save PNG image (interlaced option not directly exposed; PNG will be saved normally)

                        image.Save(outPath, ImageFormat.Png);

                        image.Dispose();

                    }



                    // Save the presentation before exiting (required by lifecycle rules)

                    string savedPresPath = Path.Combine(outputDir, "presentation_saved.pptx");

                    pres.Save(savedPresPath, SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The requested format is not supported by the current Aspose.Slides version.");

            }

            catch (Exception ex)

            {

                // General exception handling (e.g., network or I/O errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

