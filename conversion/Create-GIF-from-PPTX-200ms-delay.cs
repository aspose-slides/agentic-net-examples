// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create GIF from PPTX with 200 ms frame delay using C#

//

// Description:

// Demonstrates how to load a PowerPoint PPTX file and export it as an animated

// GIF with a 200 ms delay between frames using Aspose.Slides for .NET. The

// example includes input validation, exception handling, and shows the required

// export options configuration in a console application. Developers can adapt

// this pattern to automate PPTX‑to‑GIF conversions, integrate presentation

// processing into .NET tools, or validate visual output before publishing.

//

// Keywords:

// C#, PowerPoint, PPTX, GIF, Aspose.Slides for .NET, 200ms, Delay, Presentation

// Processing, Office Automation

//

// Use Cases:

// - Convert PPTX presentations to animated GIFs with a fixed frame delay.

// - Build C# utilities for batch processing of PowerPoint files.

// - Integrate GIF export functionality into larger .NET applications.

// - Test and verify slide animations programmatically.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesGifExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input PPTX file path

            string inputPath = "input.pptx";

            // Output GIF file path

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

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    // Set GIF export options with a frame delay of 200 milliseconds

                    Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();

                    gifOptions.DefaultDelay = 200;



                    // Save the presentation as an animated GIF

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

                }



                Console.WriteLine("GIF animation created successfully at: " + outputPath);

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

