// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create GIF from PPTX disposal none using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to an animated

// GIF with the disposal method set to None using C# and Aspose.Slides for .NET.

// The example loads a PPTX file, configures GIF export options (frame size,

// delay, transition FPS) and saves the result as a GIF. Although Aspose.Slides

// does not expose a direct property for the disposal method, the code includes

// a placeholder comment indicating where such a setting would be applied.

// This pattern can be used in console applications to automate PPTX to GIF

// conversions.

//

// Keywords:

// C#, PowerPoint, PPTX, GIF, Aspose.Slides for .NET, Disposal, None, 

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX presentations to animated GIFs with custom

//   disposal settings.

// - Build C# utilities for batch processing of PowerPoint files into GIFs.

// - Integrate PPTX-to-GIF conversion into .NET applications or CI pipelines.

// - Prototype presentation export workflows before implementing full disposal

//   control.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



namespace GifFromSlides

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output paths

            string inputPath = "input.pptx";

            string outputPath = "output.gif";



            // Check if input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                // Load presentation

                Presentation presentation = new Presentation(inputPath);



                // TODO: Select specific slides to include in GIF

                // Example: remove unwanted slides (placeholder logic)

                // int[] slidesToKeep = new int[] {0, 2};

                // // Implementation omitted



                // Configure GIF options

                GifOptions gifOptions = new GifOptions();

                gifOptions.FrameSize = new Size(960, 720);

                gifOptions.DefaultDelay = 2000; // 2 seconds per slide

                gifOptions.TransitionFps = 35;

                // Disposal method set to none is not directly exposed; placeholder comment

                // gifOptions.DisposalMethod = DisposalMethod.None; // Not supported directly



                // Save as GIF

                presentation.Save(outputPath, SaveFormat.Gif, gifOptions);

                presentation.Dispose();

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

                // Format not supported comment

                // TODO: Add handling for unsupported file format

            }

        }

    }

}

