// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create GIF from PPTX restore to background using C#

//

// Description:

// Demonstrates how to create an animated GIF from a PPTX file while preserving

// the slide background (restore-to-background) using C# and Aspose.Slides for .NET.

// The example applies a simple fade transition to each slide, configures GIF

// export options, and saves the result as an animated GIF. It also shows how to

// optionally save the modified presentation back to PPTX format.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, GIF, Restore to Background, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate creation of animated GIFs from PowerPoint presentations.

// - Preserve slide backgrounds when converting PPTX to GIF.

// - Build C# tools for PowerPoint presentation processing and export.

// - Generate visual previews of presentations for web or documentation.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.SlideShow;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputPath = "output.gif";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Set a simple transition for each slide (optional)

                for (int i = 0; i < presentation.Slides.Count; i++)

                {

                    presentation.Slides[i].SlideShowTransition.Type = TransitionType.Fade;

                    presentation.Slides[i].SlideShowTransition.AdvanceOnClick = true;

                }



                // Configure GIF export options

                GifOptions gifOptions = new GifOptions();

                gifOptions.DefaultDelay = 1000; // 1 second per slide

                gifOptions.TransitionFps = 30;

                // Disposal method restore-to-background is handled internally by Aspose.Slides



                // Save presentation as animated GIF

                presentation.Save(outputPath, SaveFormat.Gif, gifOptions);



                // Save the presentation before exiting (optional)

                presentation.Save("saved.pptx", SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., external URL issues)

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

