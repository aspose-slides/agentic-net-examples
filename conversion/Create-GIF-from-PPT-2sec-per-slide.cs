// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create animated GIF preview from PPTX with 2‑second slide duration using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation (PPTX) and export it as an

// animated GIF where each slide is displayed for 2 seconds. The example uses

// Aspose.Slides for .NET in a simple console application, showing the required

// steps to validate input, configure GIF export options, and save the result.

// This pattern can be used to automate PPTX to GIF conversion, generate preview

// animations, or integrate slide‑to‑GIF functionality into .NET solutions.

//

// Keywords:

// C#, Aspose.Slides for .NET, PowerPoint, PPTX, GIF, Animated GIF, Slide Duration,

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Generate an animated GIF preview of a PowerPoint presentation with a fixed

//   slide display time.

// - Automate batch conversion of PPTX files to GIF for quick sharing or review.

// - Incorporate slide‑to‑GIF conversion into custom .NET tools or services.

// - Validate presentation content by creating visual previews before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace GifPreviewGenerator

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input PPTX file path

            string inputPath = "input.pptx";

            // Output GIF file path

            string outputPath = "preview.gif";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation pres = new Presentation(inputPath);



                // Configure GIF export options: 2 seconds per slide

                GifOptions gifOptions = new GifOptions();

                gifOptions.DefaultDelay = 2000; // 2000 ms = 2 seconds



                // Save the presentation as an animated GIF

                pres.Save(outputPath, SaveFormat.Gif, gifOptions);



                // Dispose the presentation

                pres.Dispose();



                Console.WriteLine("GIF preview generated successfully at: " + outputPath);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

                // Format not supported comment

                // The provided file format may not be supported by Aspose.Slides.

            }

        }

    }

}

