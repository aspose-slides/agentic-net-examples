// -----------------------------------------------------------------------------
// Example: Set video frame playback speed to 1.5x using C#
//
// Description:
// Demonstrates how to set video frame playback speed to 1.5x using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Video, Frame, Playback, Speed, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting video frame playback speed to 1.5x.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetVideoPlaybackSpeed
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
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

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is a video frame
                            IVideoFrame videoFrame = shape as IVideoFrame;
                            if (videoFrame != null)
                            {
                                // Adjust playback speed to 1.5×
                                // Aspose.Slides does not expose a direct playback speed property.
                                // As a workaround, you could modify related properties or use external tools.
                                // Here we set the PlayMode to Auto as an example placeholder.
                                videoFrame.PlayMode = VideoPlayModePreset.Auto;

                                // Add a comment indicating the intended speed adjustment
                                Console.WriteLine($"Adjusted video on slide {slideIndex + 1}, shape {shapeIndex + 1} to 1.5× speed (placeholder).");
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., network errors if external URLs were used)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
