// -----------------------------------------------------------------------------
// Example: Insert Video onto Slide with Auto Play using Aspose.Slides for .NET
//
// Description:
// This console application demonstrates how to insert a video file onto a
// PowerPoint slide and configure it for automatic playback using C# and
// Aspose.Slides for .NET. It loads an existing PPTX if present, adds a video
// frame, sets the play mode to auto, and saves the modified presentation.
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, insert video, auto play, video frame
//
// Use Cases:
// - Automate adding instructional videos to corporate slide decks.
// - Generate presentation assets with embedded media for e‑learning platforms.
// - Batch‑process PPTX files to ensure videos start automatically during slide shows.
// Tested and Verified with Aspose.Slides for .NET v26.10.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string videoPath = "sample.mp4";

        // Verify that the video file exists.
        if (!File.Exists(videoPath))
        {
            Console.WriteLine("Video file not found: " + videoPath);
            return;
        }

        // Load an existing presentation or create a new one.
        Aspose.Slides.Presentation presentation = null;
        try
        {
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            Console.WriteLine("Unsupported PPTX format.");
            return;
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            Console.WriteLine("Unsupported PPT format.");
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Ensure there is at least one slide to work with.
        Aspose.Slides.ISlide slide;
        if (presentation.Slides.Count > 0)
        {
            slide = presentation.Slides[0];
        }
        else
        {
            slide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        }

        // Add the video to the presentation and place it on the slide.
        FileStream videoStream = null;
        try
        {
            videoStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read);
            Aspose.Slides.IVideo video = presentation.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.ReadStreamAndRelease);

            int x = 100;
            int y = 100;
            int width = 320;
            int height = 240;

            Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(x, y, width, height, video);
            videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding video: " + ex.Message);
        }
        finally
        {
            if (videoStream != null)
            {
                videoStream.Close();
            }
        }

        // Save the modified presentation.
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine("Presentation saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}
