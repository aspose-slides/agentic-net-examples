// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert PPTX to TIFF LZW using C#

//

// Description:

// Demonstrates how to batch convert multiple PPTX files to TIFF images with LZW

// compression using C# and Aspose.Slides for .NET. The console application scans

// a specified directory (or the current working directory) for *.pptx files,

// converts each presentation to a single-page TIFF file, and saves the output

// alongside the source files.

//

// Keywords:

// C#, PowerPoint, PPTX, TIFF, LZW, Aspose.Slides for .NET, Batch conversion,

// Presentation processing, Office automation

//

// Use Cases:

// - Automate conversion of a collection of PPTX presentations to TIFF LZW for

//   archival or printing purposes.

// - Integrate PPTX-to-TIFF conversion into .NET build or deployment pipelines.

// - Create utilities for bulk image extraction from PowerPoint files.

// - Validate and preprocess presentations before further processing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



namespace BatchConvertPptxToTiff

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine the directory containing PPTX files

            string inputDirectory = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();



            // Get all PPTX files in the directory

            string[] pptxFiles = Directory.GetFiles(inputDirectory, "*.pptx");



            foreach (string inputPath in pptxFiles)

            {

                // Build output TIFF file path

                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(inputPath);

                string outputPath = Path.Combine(inputDirectory, fileNameWithoutExtension + ".tiff");



                try

                {

                    // Load the presentation

                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                    // Set TIFF options with LZW compression (default)

                    Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();

                    tiffOptions.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.LZW;



                    // Save the presentation as TIFF

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);



                    // Dispose the presentation

                    presentation.Dispose();

                }

                catch (NotSupportedException)

                {

                    // Format not supported

                }

                catch (Exception)

                {

                    // Handle other exceptions as needed

                }

            }

        }

    }

}

