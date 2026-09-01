// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Reuse single TiffOptions instance for batch conversions using C#

//

// Description:

// Demonstrates how to reuse a single TiffOptions instance to convert multiple

// PowerPoint presentations to TIFF images using Aspose.Slides for .NET. The

// example creates an output folder, iterates over a list of PPTX files, loads

// each presentation, and saves it as a TIFF file with the shared options.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Reuse, Single, TiffOptions,

// Batch Conversion, TIFF, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of PPTX files to TIFF with consistent settings.

// - Build .NET tools that process multiple presentations efficiently.

// - Reduce memory overhead by reusing a single TiffOptions object.

// - Integrate PowerPoint to image conversion into larger workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input presentation files

        string[] inputFiles = new string[] { "input1.pptx", "input2.pptx" };

        // Output directory

        string outputDir = "output";

        if (!Directory.Exists(outputDir))

        {

            Directory.CreateDirectory(outputDir);

        }



        // Reuse a single TiffOptions instance for all conversions

        Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();

        tiffOptions.DpiX = 200;

        tiffOptions.DpiY = 200;



        foreach (string inputPath in inputFiles)

        {

            try

            {

                // Check if the input file exists

                if (!File.Exists(inputPath))

                {

                    Console.WriteLine("Input file not found: " + inputPath);

                    continue;

                }



                // Load the presentation

                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))

                {

                    string fileName = Path.GetFileNameWithoutExtension(inputPath);

                    string outputPath = Path.Combine(outputDir, fileName + ".tiff");

                    // Save as TIFF using the shared TiffOptions

                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

                    Console.WriteLine("Saved TIFF: " + outputPath);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("Format not supported for file: " + inputPath);

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URLs)

                Console.WriteLine("Error processing file " + inputPath + ": " + ex.Message);

            }

        }

    }

}

