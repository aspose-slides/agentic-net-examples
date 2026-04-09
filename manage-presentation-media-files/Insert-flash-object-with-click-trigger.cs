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