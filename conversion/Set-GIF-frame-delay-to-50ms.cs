// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set GIF frame delay to 50ms using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to an animated

// GIF while setting each frame's delay to 50 milliseconds using Aspose.Slides

// for .NET. The example loads a presentation, configures GIF export options,

// and saves the result as a GIF file. This pattern can be used in console

// applications or integrated into larger .NET solutions for automated

// presentation processing.

//

// Keywords:

// C#, PowerPoint, PPTX, GIF, Frame Delay, 50ms, Aspose.Slides for .NET, 

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to GIF with a fixed 50 ms frame delay.

// - Build C# utilities for batch processing of presentations into animated GIFs.

// - Integrate GIF export with custom timing into .NET applications.

// - Validate and preview presentation animations before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

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

            var presentation = new Aspose.Slides.Presentation(inputPath);



            // Configure GIF export options

            var gifOptions = new Aspose.Slides.Export.GifOptions();

            gifOptions.DefaultDelay = 50; // Set frame delay to 50 milliseconds



            // Save as GIF

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);



            // Dispose the presentation

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

