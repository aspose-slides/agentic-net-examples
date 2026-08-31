// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add fade transition to all slides using C#

//

// Description:

// Demonstrates how to add a fade transition to every slide in a PowerPoint

// presentation using C# and Aspose.Slides for .NET. The example loads an

// existing PPTX file, applies a 1‑second fade transition to each slide, and

// saves the result as a new PPTX file. This pattern can be used to automate

// slide‑show enhancements in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Fade, Transition, Slides,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automatically add fade transitions to all slides in a presentation.

// - Build .NET tools for enhancing PowerPoint slide shows.

// - Integrate slide transition automation into document generation pipelines.

// - Validate and preview presentation effects before distribution.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        // Load the presentation with exception handling for unsupported formats

        Presentation pres = null;

        try

        {

            pres = new Presentation(inputPath);

        }

        catch (Exception ex)

        {

            // Format not supported

            Console.WriteLine("Error loading presentation: " + ex.Message);

            return;

        }



        // Apply fade transition to every slide

        for (int i = 0; i < pres.Slides.Count; i++)

        {

            pres.Slides[i].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;

            // Set transition duration to 1 second (1000 ms) for smoother visual flow

            pres.Slides[i].SlideShowTransition.Duration = 1000;

        }



        // Save the modified presentation before exiting

        pres.Save(outputPath, SaveFormat.Pptx);

        pres.Dispose();

    }

}

