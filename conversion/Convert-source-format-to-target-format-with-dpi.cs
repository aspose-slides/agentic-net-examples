// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert source format to target format with DPI using C#

//

// Description:

// Demonstrates how to convert a presentation from a specified source format

// to a target format using Aspose.Slides for .NET, with optional DPI settings

// when converting to TIFF. The example parses command‑line arguments for the

// source format, target format, and DPI, loads the input file, performs the

// conversion, and saves the result.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, Source Format, Target

// Format, DPI, TIFF, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of presentations between different file formats.

// - Generate high‑resolution TIFF images from presentations by specifying DPI.

// - Build command‑line tools for batch processing of PowerPoint files.

// - Integrate format conversion into .NET applications or CI pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.Util;



namespace SlideConverter

{

    class Program

    {

        static void Main(string[] args)

        {

            // Expect at least source and target formats

            if (args.Length < 2)

            {

                Console.WriteLine("Usage: SlideConverter <sourceFormat> <targetFormat> [dpi]");

                return;

            }



            // Parse source format enum

            string sourceFormatString = args[0];

            Aspose.Slides.SourceFormat sourceFormat;

            try

            {

                sourceFormat = (Aspose.Slides.SourceFormat)Enum.Parse(typeof(Aspose.Slides.SourceFormat), sourceFormatString, true);

            }

            catch (Exception)

            {

                Console.WriteLine("Invalid source format.");

                return;

            }



            // Parse target format enum

            string targetFormatString = args[1];

            Aspose.Slides.Export.SaveFormat targetSaveFormat;

            try

            {

                targetSaveFormat = (Aspose.Slides.Export.SaveFormat)Enum.Parse(typeof(Aspose.Slides.Export.SaveFormat), targetFormatString, true);

            }

            catch (Exception)

            {

                Console.WriteLine("Invalid target format.");

                return;

            }



            // Optional DPI

            int dpi = 0;

            if (args.Length >= 3)

            {

                if (!int.TryParse(args[2], out dpi))

                {

                    Console.WriteLine("Invalid DPI value.");

                    return;

                }

            }



            // Build input and output file paths based on current directory

            string inputFileName = "input." + sourceFormatString.ToLower();

            string outputFileName = "output." + targetFormatString.ToLower();

            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine($"Input file not found: {inputPath}");

                return;

            }



            try

            {

                // Load presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    // If target is TIFF and DPI is provided, use TiffOptions

                    if (targetSaveFormat == SaveFormat.Tiff && dpi > 0)

                    {

                        TiffOptions tiffOptions = new TiffOptions();

                        tiffOptions.DpiX = (uint)dpi;

                        tiffOptions.DpiY = (uint)dpi;

                        pres.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                    }

                    else

                    {

                        // Generic save without additional options

                        pres.Save(outputPath, targetSaveFormat);

                    }

                }



                Console.WriteLine($"Conversion completed: {outputPath}");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The requested conversion format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine($"Error during conversion: {ex.Message}");

            }

        }

    }

}

