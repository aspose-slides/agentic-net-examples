// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create GIF from PPTX 128 colors using C#

//

// Description:

// Demonstrates how to create an animated GIF from a PPTX file using

// Aspose.Slides for .NET while targeting a 128‑color palette (the closest

// achievable setting is the 8‑bit 256‑color GIF format). The example shows

// loading a presentation, configuring GIF export options, and saving the

// result as a GIF file in a console application. Developers can adapt this

// pattern to automate PPTX‑to‑GIF conversions, integrate presentation

// processing into .NET tools, or validate visual output.

//

// Keywords:

// C#, PowerPoint, PPTX, GIF, Aspose.Slides for .NET, Colors, Presentation Processing,

// Office Automation

//

// Use Cases:

// - Automate conversion of PPTX slides to animated GIFs with limited color depth.

// - Build C# utilities for PowerPoint presentation export.

// - Generate GIF previews of presentations in .NET applications.

// - Validate visual fidelity of PPTX content before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CreateGifFromPptx

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.gif";



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

                    // Configure GIF export options

                    GifOptions gifOptions = new GifOptions();

                    // Note: Aspose.Slides does not expose a direct property for color depth.

                    // The GIF format is limited to 8‑bit indexed color (256 colors). This is the closest

                    // achievable setting to the requested 128‑color limit.



                    // Save the presentation as an animated GIF

                    presentation.Save(outputPath, SaveFormat.Gif, gifOptions);

                }



                Console.WriteLine("GIF created successfully at: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

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

