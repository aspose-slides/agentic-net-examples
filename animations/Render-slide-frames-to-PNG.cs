// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Render animated slide frames to PNG using C#

//

// Description:

// Demonstrates how to extract each animation frame from a PowerPoint presentation

// and save them as PNG images using Aspose.Slides for .NET. The example loads an

// animated PPTX file, creates a PresentationAnimationsGenerator and a

// PresentationPlayer to step through the animation at a defined frame rate, and

// writes each generated frame to the "Frames" directory. The original presentation

// is then saved unchanged. This pattern can be used to automate frame extraction,

// create video sources, or perform visual validation of slide animations.

//

// Keywords:

// C#, Aspose.Slides, PPTX, animation, frames, PNG, rendering, PresentationAnimationsGenerator, PresentationPlayer, slide processing

//

// Use Cases:

// - Extract animation frames from PowerPoint slides for further processing.

// - Generate image sequences for video creation or GIFs.

// - Validate slide animations programmatically.

// - Build tools that need per-frame visual output of presentations.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        System.String inputPath = "animated.pptx";

        if (!System.IO.File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))

            {

                System.String outputDir = "Frames";

                System.IO.Directory.CreateDirectory(outputDir);

                const System.Double fps = 33;



                using (Aspose.Slides.Export.PresentationAnimationsGenerator generator = new Aspose.Slides.Export.PresentationAnimationsGenerator(pres))

                using (Aspose.Slides.Export.PresentationPlayer player = new Aspose.Slides.Export.PresentationPlayer(generator, fps))

                {

                    player.FrameTick += (sender, args) =>

                    {

                        System.String filePath = System.IO.Path.Combine(outputDir, $"frame_{sender.FrameIndex}.png");

                        args.GetFrame().Save(filePath, Aspose.Slides.ImageFormat.Png);

                    };



                    generator.Run(pres.Slides);

                }



                // Save the presentation before exit

                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., external URLs)

            Console.WriteLine($"An error occurred: {ex.Message}");

        }

    }

}

