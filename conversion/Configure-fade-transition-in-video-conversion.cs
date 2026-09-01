// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Configure fade transition in video conversion using C#

//

// Description:

// Demonstrates how to configure a fade transition when converting a PowerPoint

// presentation to an animated GIF using C# and Aspose.Slides for .NET. The

// example shows the required presentation‑processing steps, applies a fade

// transition to the first slide, sets GIF export options, and saves the result

// as an animated GIF. Developers can use this pattern to automate PPTX workflows,

// validate results, or integrate presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Fade, Transition,

// GIF, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate configuring fade transition in GIF conversion.

// - Build C# tools for PowerPoint presentation processing.

// - Generate animated GIFs from PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace Example

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "output.gif";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                // Load the presentation

                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))

                {

                    // Apply fade transition effect to the first slide

                    pres.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;



                    // Configure GIF export options with a higher transition FPS

                    Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();

                    gifOptions.TransitionFps = 60;

                    gifOptions.FrameSize = new System.Drawing.Size(960, 720);



                    // Save the presentation as an animated GIF

                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

                }

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

