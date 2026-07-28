// -----------------------------------------------------------------------------
// Example: Add hyperlink to video autoplay using C#
//
// Description:
// Demonstrates how to add a video frame that plays automatically and includes
// a clickable hyperlink using C# and Aspose.Slides for .NET. The example
// creates a new presentation, inserts a video file, sets it to autoplay,
// assigns a hyperlink with a tooltip, and saves the presentation as PPTX.
// This pattern can be used to automate PowerPoint workflows that require
// interactive video content.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hyperlink, Video, Autoplay,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding autoplay videos with hyperlinks to presentations.
// - Build C# tools for enriching PowerPoint slides with interactive media.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate video and hyperlink integration before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string videoPath = "sample.mp4";
        string outputPath = "output.pptx";
        string hyperlinkUrl = "https://www.example.com/video";

        if (!File.Exists(videoPath))
        {
            Console.WriteLine("Video file does not exist: " + videoPath);
            return;
        }

        try
        {
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];
                IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(10, 10, 400, 300, videoPath);
                videoFrame.PlayMode = VideoPlayModePreset.Auto;
                videoFrame.HyperlinkClick = new Hyperlink(hyperlinkUrl);
                videoFrame.HyperlinkClick.Tooltip = "Open video link";

                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
