// -----------------------------------------------------------------------------
// Example: Add video placeholder to master auto play using C#
//
// Description:
// Demonstrates how to add a video placeholder to a master slide and set it to
// play automatically using C# and Aspose.Slides for .NET. The example creates a
// new presentation, accesses the first master slide, inserts a video frame with
// a placeholder video file, configures the playback mode to auto, and saves the
// resulting PPTX file. This pattern can be used to automate PowerPoint
// presentation workflows that require video placeholders on master slides.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Video, Placeholder, Master,
// Auto, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding video placeholders to master slides with auto‑play settings.
// - Build C# tools for PowerPoint presentation processing involving media.
// - Generate or transform PPTX files with predefined video placeholders in .NET.
// - Validate presentation workflows that include auto‑playing video content.
// -----------------------------------------------------------------------------

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
            presentation.Save("VideoPlaceholder.pptx", SaveFormat.Pptx);
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
