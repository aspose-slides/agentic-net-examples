// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set looping background video animation infinite using C#

//

// Description:

// Demonstrates how to set a looping background video animation to play infinitely 

// using C# and Aspose.Slides for .NET. The example creates a new presentation, 

// adds a video file as a background video frame, configures it to start 

// automatically and loop forever, and saves the result as a PPTX file. This 

// pattern is useful for automating PowerPoint workflows that require continuous 

// background video playback.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Looping, Background, Video, 

// Animation, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate setting a looping background video animation infinite.

// - Build C# tools for PowerPoint presentation processing with continuous video.

// - Generate or transform PPTX files that include background videos in .NET 

//   applications.

// - Validate presentation workflows involving video playback before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SetLoopingBackgroundVideo

{

    class Program

    {

        static void Main(string[] args)

        {

            // Path to the video file (can be changed or passed via args)

            string videoPath = "background.mp4";



            // Check if the video file exists

            if (!File.Exists(videoPath))

            {

                Console.WriteLine("Video file not found: " + videoPath);

                return;

            }



            try

            {

                // Create a new presentation

                Presentation presentation = new Presentation();



                // Get the first slide

                ISlide slide = presentation.Slides[0];



                // Add the video to the presentation's video collection

                FileStream videoStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read, FileShare.Read);

                IVideo video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);

                videoStream.Close();



                // Add a video frame to the slide

                IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 720, 540, video);



                // Set the video to play automatically and loop infinitely

                videoFrame.PlayMode = VideoPlayModePreset.Auto;

                videoFrame.PlayLoopMode = true;



                // Save the presentation

                presentation.Save("LoopingBackgroundVideo.pptx", SaveFormat.Pptx);

                presentation.Dispose();

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                // Format not supported

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

