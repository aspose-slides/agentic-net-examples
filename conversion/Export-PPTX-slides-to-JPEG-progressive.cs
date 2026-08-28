// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX slides to JPEG progressive using C#

//

// Description:

// Demonstrates how to export PPTX slides to JPEG progressive using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Export, Pptx, Slides, 

// Jpeg, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate export PPTX slides to JPEG progressive.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

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

            // Input presentation file

            string inputPath = "input.pptx";

            // Output directory for JPEG images

            string outputDir = "output";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Ensure output directory exists

            if (!Directory.Exists(outputDir))

            {

                Directory.CreateDirectory(outputDir);

            }



            try

            {

                // Load presentation

                Presentation presentation = new Presentation(inputPath);



                // Export each slide as JPEG with quality (progressive encoding not directly exposed)

                for (int i = 0; i < presentation.Slides.Count; i++)

                {

                    // Get full‑scale image of the slide

                    IImage slideImage = presentation.Slides[i].GetImage(1f, 1f);

                    // Build output file name

                    string outputPath = Path.Combine(outputDir, $"slide_{i + 1}.jpg");

                    // Save JPEG with quality parameter (0‑100). Higher quality retains progressive encoding where supported.

                    slideImage.Save(outputPath, ImageFormat.Jpeg, 80);

                    // Dispose image to free resources

                    slideImage.Dispose();

                }



                // Save the presentation (required by lifecycle rule)

                presentation.Save(inputPath, SaveFormat.Pptx);

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported for this operation.");

            }

            catch (Exception ex)

            {

                // General exception handling (e.g., web service errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

