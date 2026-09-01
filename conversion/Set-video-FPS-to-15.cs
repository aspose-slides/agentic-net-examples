// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set video FPS to 15 using C#

//

// Description:

// Demonstrates how to embed a video that has been pre‑encoded to 15 FPS into a

// PowerPoint presentation using Aspose.Slides for .NET. The example shows the

// required steps to create a presentation, add a video frame, configure basic

// playback settings, and save the PPTX file. Because Aspose.Slides does not

// provide an API to modify video FPS, the source video must be re‑encoded to

// the desired frame rate before embedding.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Video, Video FPS, Presentation Processing, 

// Office Automation

//

// Use Cases:

// - Embed a 15 FPS video into a PowerPoint slide programmatically.

// - Build C# tools for PowerPoint presentation processing that require specific video frame rates.

// - Generate or transform PPTX files in .NET applications with pre‑processed video assets.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace VideoFpsAdjustment

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input video file path

            string inputVideoPath = "sample.mp4";

            // Output presentation path

            string outputPath = "VideoFpsAdjusted.pptx";



            // Verify that the input video file exists

            if (!File.Exists(inputVideoPath))

            {

                Console.WriteLine("Input video file does not exist: " + inputVideoPath);

                return;

            }



            try

            {

                // Create a new presentation

                Presentation presentation = new Presentation();



                // Get the first slide

                ISlide slide = presentation.Slides[0];



                // Add the video to the presentation's video collection

                IVideo video = presentation.Videos.AddVideo(File.ReadAllBytes(inputVideoPath));



                // Add a video frame to the slide (using the add-video-frame rule)

                IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 150, video);

                videoFrame.PlayMode = VideoPlayModePreset.Auto;

                videoFrame.Volume = AudioVolumeMode.Loud;



                // NOTE: Aspose.Slides does not provide a direct API to change the FPS of an embedded video.

                // Reducing the video FPS typically requires re-encoding the video file itself before embedding.

                // Here we assume the source video has been re-encoded to 15 FPS externally.



                // Save the presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

                presentation.Dispose();



                Console.WriteLine("Presentation saved successfully to: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: The provided video format is not supported by Aspose.Slides.

                Console.WriteLine("The video format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., web service errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

