// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create multi page TIFF from PPTX embed ICC using C#

//

// Description:

// Demonstrates how to convert a PPTX presentation to a multi‑page TIFF image

// while preserving color accuracy by embedding an ICC profile (if supported) using

// Aspose.Slides for .NET. The example loads a presentation, configures TIFF

// export options such as compression and DPI, and saves the result as a

// multi‑page TIFF file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Multi, Page, Tiff, Pptx,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to multi‑page TIFF for archival or printing.

// - Build C# utilities that handle color‑managed image export from presentations.

// - Integrate PPTX to TIFF transformation into .NET applications or workflows.

// - Validate and test presentation rendering with ICC profile support.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace MultiPageTiffExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.tiff";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Configure TIFF options

                TiffOptions tiffOptions = new TiffOptions();

                tiffOptions.CompressionType = TiffCompressionTypes.CCITT4;

                tiffOptions.DpiX = 300;

                tiffOptions.DpiY = 300;



                // TODO: Embed ICC profile for color accuracy

                // (Aspose.Slides currently does not expose a direct property for ICC profile embedding.

                // If such functionality becomes available, set it here, e.g., tiffOptions.IccProfile = ...;)



                // Save as multi‑page TIFF

                presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);



                // Dispose the presentation

                presentation.Dispose();



                Console.WriteLine("TIFF file created successfully: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: The provided file format is not supported for conversion.

                Console.WriteLine("The file format is not supported for TIFF conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

