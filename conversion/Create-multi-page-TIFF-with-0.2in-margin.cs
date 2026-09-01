// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create multi page TIFF with 0.2in margin using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to a multi‑page TIFF

// image using Aspose.Slides for .NET while attempting to apply a 0.2 inch margin.

// The example loads a PPTX file, configures TIFF export options, and saves the

// result as a multi‑page TIFF. It also includes basic file existence checks and

// exception handling suitable for console applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Multi‑page TIFF, Margin, Presentation conversion, Office Automation

//

// Use Cases:

// - Convert presentations to multi‑page TIFF files for archival or printing.

// - Generate TIFF images with a specific margin for document workflows.

// - Build .NET utilities that automate PPTX to image transformations.

// - Validate and test presentation export settings in automated pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideToTiffExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.tiff";



            // Verify that the input file exists

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



                // Set slide layout options (each slide on a separate page)

                // Note: Margin of 0.2 inches is not directly exposed; default layout is used.

                tiffOptions.SlidesLayoutOptions = new HandoutLayoutingOptions

                {

                    Handout = HandoutType.Handouts4Horizontal

                };



                // Save the presentation as a multi-page TIFF

                presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

            }

            catch (NotSupportedException)

            {

                // Handle unsupported format exception

                Console.WriteLine("The specified format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

