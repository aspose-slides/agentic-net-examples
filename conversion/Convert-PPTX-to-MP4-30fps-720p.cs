// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX to MP4 30fps 720p using C#

//

// Description:

// Demonstrates how to generate 30 fps 720p PNG frames from a PPTX using

// Aspose.Slides for .NET, which can then be combined into an MP4 video with an

// external encoder. The example shows how to set slide size, create an

// animations generator, capture each frame, and save the presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, 30fps, 720p, PNG frames,

// Video encoding, Presentation Processing

//

// Use Cases:

// - Generate high‑resolution PNG frames from PPTX for video creation.

// - Automate PPTX to MP4 conversion workflow using external encoders.

// - Build .NET tools for slide animation extraction.

// - Validate slide size and animation rendering before video production.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputVideoPath = "output.mp4";

        string framesDirectory = "frames_30fps";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            using (Presentation pres = new Presentation(inputPath))

            {

                // Set slide size to 1280x720 points without scaling content

                pres.SlideSize.SetSize(1280f, 720f, SlideSizeScaleType.DoNotScale);



                // Ensure output directory for frames exists

                Directory.CreateDirectory(framesDirectory);



                // Initialize animations generator with desired frame size

                using (PresentationAnimationsGenerator generator = new PresentationAnimationsGenerator(new Size(1280, 720)))

                {

                    // Create player with 30 FPS

                    using (PresentationPlayer player = new PresentationPlayer(generator, 30.0))

                    {

                        int frameCounter = 0;

                        player.FrameTick += (sender, args) =>

                        {

                            string framePath = Path.Combine(framesDirectory, $"frame_{frameCounter++.ToString("D5")}.png");

                            args.GetFrame().Save(framePath, Aspose.Slides.ImageFormat.Png);

                        };



                        // Generate animation frames for all slides

                        generator.Run(pres.Slides);

                    }

                }



                // NOTE: Aspose.Slides does not provide direct MP4 export.

                // The generated PNG frames can be combined into an MP4 video using an external encoder.

                // If MP4 export were supported, the following call would be used:

                // pres.Save(outputVideoPath, SaveFormat.Mp4);

                // Since the format is not supported, we handle it gracefully.



                // Save the (potentially modified) presentation before exiting

                pres.Save("saved_output.pptx", SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("MP4 format is not supported by Aspose.Slides.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

