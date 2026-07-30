// -----------------------------------------------------------------------------
// Example: Add captions to video frames and export using C#
//
// Description:
// Demonstrates how to read slide notes, add them as caption tracks to video
// frames within each slide, and save the updated presentation using Aspose.Slides
// for .NET. The example processes an input PPTX, extracts notes text per slide,
// attaches the notes as UTF‑8 captions to any video frames found, and exports the
// result as a new PPTX file.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Video Frames, Captions, Notes,
// Presentation Processing, Export, Office Automation
//
// Use Cases:
// - Automatically embed slide notes as captions into video frames.
// - Build .NET tools that enhance presentations with synchronized captions.
// - Convert or enrich existing PPTX files with video metadata.
// - Validate and automate PPTX workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VideoCaptionAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Retrieve notes text for the current slide, if any
                        string notesText = null;
                        if (slide.NotesSlideManager != null && slide.NotesSlideManager.NotesSlide != null &&
                            slide.NotesSlideManager.NotesSlide.NotesTextFrame != null)
                        {
                            notesText = slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text;
                        }

                        // If there are no notes, skip adding captions for this slide
                        if (string.IsNullOrEmpty(notesText))
                            continue;

                        // Convert notes text to a UTF-8 byte array
                        byte[] notesBytes = Encoding.UTF8.GetBytes(notesText);

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Process only video frames
                            IVideoFrame videoFrame = shape as IVideoFrame;
                            if (videoFrame == null)
                                continue;

                            // Add caption track using the notes text
                            using (MemoryStream captionStream = new MemoryStream(notesBytes))
                            {
                                videoFrame.CaptionTracks.Add("Notes", captionStream);
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported or other processing error
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
