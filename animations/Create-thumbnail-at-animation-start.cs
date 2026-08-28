// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create thumbnail at animation start using C#

//

// Description:

// Demonstrates how to generate a PNG thumbnail for each animation at its start

// position in a PowerPoint presentation using Aspose.Slides for .NET. The

// example loads a PPTX file, iterates through all animation events, captures the

// first frame (time position 0) of each animation, and saves the frames as PNG

// images in a specified output directory. This pattern can be used to extract

// visual previews of animation sequences for documentation, testing, or UI

// generation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Thumbnail, Animation, Start,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate creation of thumbnails at the start of each animation.

// - Build C# tools for extracting visual previews from PowerPoint files.

// - Generate or transform PPTX files in .NET applications.

// - Validate animation workflows before publishing or integration.

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

        string outputDir = "AnimationFrames";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        Directory.CreateDirectory(outputDir);



        try

        {

            using (Presentation presentation = new Presentation(inputPath))

            {

                using (PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation))

                {

                    animationsGenerator.NewAnimation += animationPlayer =>

                    {

                        // Capture the frame at the start of the animation (time position 0)

                        animationPlayer.SetTimePosition(0);

                        string framePath = Path.Combine(outputDir, $"animation_start_{DateTime.Now.Ticks}.png");

                        animationPlayer.GetFrame().Save(framePath, ImageFormat.Png);

                    };



                    // Generate animation events for all slides

                    animationsGenerator.Run(presentation.Slides);

                }



                // Save the presentation before exiting (no modifications made)

                presentation.Save(inputPath, SaveFormat.Pptx);

            }

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

