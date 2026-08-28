// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set entrance animation delay two seconds using C#

//

// Description:

// Demonstrates how to set a default entrance animation delay of two seconds 

// for all slides in a PowerPoint presentation using Aspose.Slides for .NET. 

// The example loads an existing PPTX file, configures the PresentationAnimationsGenerator 

// with a 2000 ms delay, applies it to the presentation, and saves the result. 

// This pattern can be used to automate animation timing adjustments in .NET 

// applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Entrance, Animation, Delay, 

// Seconds, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate setting a uniform entrance animation delay of two seconds.

// - Build C# tools for adjusting animation timings in PowerPoint files.

// - Generate or transform PPTX presentations with consistent animation behavior.

// - Validate and preprocess presentation workflows before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        // Check if the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Create the animations generator and set a default delay of 2000 ms (2 seconds)

            using (Aspose.Slides.Export.PresentationAnimationsGenerator animationsGenerator = new Aspose.Slides.Export.PresentationAnimationsGenerator(presentation))

            {

                animationsGenerator.DefaultDelay = 2000; // 2 seconds

                animationsGenerator.Run(presentation.Slides);

            }



            // Save the modified presentation

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format exception

            // Format not supported

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

