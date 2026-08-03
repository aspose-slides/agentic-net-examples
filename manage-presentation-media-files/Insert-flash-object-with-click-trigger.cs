// -----------------------------------------------------------------------------
// Example: Insert flash object with click trigger using C#
//
// Description:
// Demonstrates how to attempt inserting a Flash (SWF) file as a video frame 
// with an OnClick playback trigger using Aspose.Slides for .NET. The example 
// shows validation of the source file, handling of unsupported formats, and 
// saving the resulting presentation. This pattern helps developers understand 
// the limitations of embedding Flash content and how to implement click‑triggered 
// media insertion in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Flash, SWF, Click Trigger, 
// Video Frame, Presentation Processing, Office Automation
//
// Use Cases:
// - Attempt to embed Flash media with click‑triggered playback in a PPTX.
// - Detect and handle unsupported media formats during presentation generation.
// - Automate creation of presentations that include media placeholders.
// - Validate media insertion workflows before deployment.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertFlashObject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input flash file path
            string flashFilePath = "sample.swf";
            // Output presentation path
            string outputPath = "FlashObjectPresentation.pptx";

            // Verify that the flash file exists
            if (!File.Exists(flashFilePath))
            {
                Console.WriteLine("Flash file not found: " + flashFilePath);
                return;
            }

            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                try
                {
                    // Attempt to add the flash file as a video frame (unsupported format)
                    Aspose.Slides.IVideoFrame flashFrame = slide.Shapes.AddVideoFrame(50f, 150f, 300f, 250f, flashFilePath);
                    // Set playback to start only on click
                    flashFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.OnClick;
                }
                catch (Exception ex)
                {
                    // Format not supported – flash cannot be embedded as a video frame
                    // Comment: Flash format not supported for video frames.
                    Console.WriteLine("Unable to embed flash as video frame: " + ex.Message);
                }

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                // Dispose is called automatically by the using statement
            }
        }
    }
}
