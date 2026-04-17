using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPresentationPath = "input.pptx";
        string inputVideoPath = "sample.mp4";
        string outputHtmlPath = "output.html";

        if (!File.Exists(inputPresentationPath))
        {
            Console.WriteLine("Input presentation file not found.");
            return;
        }

        if (!File.Exists(inputVideoPath))
        {
            Console.WriteLine("Input video file not found.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPresentationPath);

            // Add a video frame to the first slide
            ISlide slide = presentation.Slides[0];
            IVideo video = presentation.Videos.AddVideo(File.ReadAllBytes(inputVideoPath));
            IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 150, video);
            videoFrame.PlayMode = VideoPlayModePreset.Auto;
            videoFrame.Volume = AudioVolumeMode.Loud;

            // Hide speaker notes during conversion
            Html5Options htmlOptions = new Html5Options();
            htmlOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions();
            ((NotesCommentsLayoutingOptions)htmlOptions.SlidesLayoutOptions).NotesPosition = NotesPositions.None;

            // Save as HTML5 with notes hidden
            presentation.Save(outputHtmlPath, SaveFormat.Html5, htmlOptions);

            // Save the presentation before exiting
            presentation.Save("output.pptx", SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}