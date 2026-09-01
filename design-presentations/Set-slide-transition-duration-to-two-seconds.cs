// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set slide transition duration to two seconds using C#

//

// Description:

// Demonstrates how to set the slide transition duration to two seconds for all

// slides in a PowerPoint presentation using C# and Aspose.Slides for .NET.

// The example creates a new presentation, applies a 2000‑millisecond transition

// duration to each slide, and saves the result as a PPTX file. This pattern can

// be used to automate slide transition settings in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide, Transition, Duration,

// Seconds, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate setting slide transition duration to two seconds across a deck.

// - Build C# utilities for PowerPoint presentation customization.

// - Generate or modify PPTX files programmatically in .NET.

// - Ensure consistent slide transitions before publishing presentations.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string outputPath = "output.pptx";

        try

        {

            // Create a new presentation

            Presentation pres = new Presentation();



            // Set transition duration to 2000 milliseconds (2 seconds) for each slide

            foreach (ISlide slide in pres.Slides)

            {

                slide.SlideShowTransition.Duration = 2000;

            }



            // Save the presentation

            pres.Save(outputPath, SaveFormat.Pptx);

            pres.Dispose();

        }

        catch (Exception ex)

        {

            // Handle exceptions (e.g., unsupported format)

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

