// -----------------------------------------------------------------------------
// Example: Apply fadein to video frames and save using C#
//
// Description:
// Demonstrates how to apply fade‑in to video frames and save using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation‑processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Fadein, Video, Frames, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate apply fade‑in to video frames and save.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FadeInVideoFrames
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // format not supported
                return;
            }

            // Iterate through all slides and shapes
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];

                    // Apply fade‑in to video frames
                    IVideoFrame videoFrame = shape as IVideoFrame;
                    if (videoFrame != null)
                    {
                        videoFrame.FadeInDuration = 200f; // 200 ms fade‑in
                    }

                    // If needed, other video properties can be set here.
                }
            }

            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
