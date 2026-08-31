// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Render presentation to TIFF with fallback using C#

//

// Description:

// Demonstrates how to render a PowerPoint presentation to a high‑resolution TIFF

// image while applying font fallback rules using Aspose.Slides for .NET. The

// example loads a PPTX file, configures fallback for missing Unicode ranges,

// sets TIFF export options, and saves the result as a TIFF file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Render, Presentation, Tiff,

// Fallback, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX presentations to high‑resolution TIFF images.

// - Ensure proper rendering of characters when original fonts are unavailable.

// - Build .NET tools for batch processing of PowerPoint files with font fallback.

// - Validate presentation rendering workflows before deployment.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesTiffFallback

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

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Set up font fallback rules

                    IFontFallBackRulesCollection fallbackRules = new FontFallBackRulesCollection();

                    fallbackRules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

                    presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;



                    // Configure TIFF options for high‑resolution output

                    TiffOptions tiffOptions = new TiffOptions

                    {

                        DpiX = 300,

                        DpiY = 300

                    };



                    // Save the presentation as TIFF using the specified options

                    presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                }



                Console.WriteLine("Presentation successfully saved as TIFF: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // The requested file format is not supported by Aspose.Slides.

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., loading errors, I/O errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

