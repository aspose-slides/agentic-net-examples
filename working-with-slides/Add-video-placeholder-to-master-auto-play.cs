using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first master slide
            IMasterSlide masterSlide = presentation.Masters[0];

            // Add a video placeholder to the master slide (using a dummy video path)
            IVideoFrame videoFrame = masterSlide.Shapes.AddVideoFrame(50f, 150f, 300f, 150f, "placeholder.mp4");

            // Set playback mode to start automatically
            videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;

            // Save the presentation
            presentation.Save("VideoPlaceholder.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (System.IO.FileNotFoundException ex)
        {
            // Handle missing video file
            Console.WriteLine("Video file not found: " + ex.Message);
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}