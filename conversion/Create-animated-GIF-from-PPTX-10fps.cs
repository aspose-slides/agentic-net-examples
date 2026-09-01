// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create animated GIF from PPTX 10fps using C#

//

// Description:

// Demonstrates how to create an animated GIF from a PPTX file at 10 frames per

// second using C# and Aspose.Slides for .NET. The example loads a PowerPoint

// presentation, configures GIF export options with a custom frame rate, and

// saves the result as an animated GIF. This pattern can be used to automate

// PPTX-to-GIF conversions, integrate presentation processing into .NET

// applications, or validate slide animations before publishing.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Animated GIF, 10Fps,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate creation of animated GIFs from PPTX files at a specific frame rate.

// - Build C# tools for PowerPoint presentation conversion and processing.

// - Generate GIF previews of slide decks for web or documentation purposes.

// - Validate slide animation timing in .NET applications.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define input and output paths

        string inputPath = "input.pptx";

        string outputPath = "output.gif";



        // Check if the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            Presentation presentation = new Presentation(inputPath);



            // Set GIF export options with custom frame rate

            GifOptions gifOptions = new GifOptions

            {

                TransitionFps = 10

            };



            // Save as animated GIF

            presentation.Save(outputPath, SaveFormat.Gif, gifOptions);



            // Dispose the presentation

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

