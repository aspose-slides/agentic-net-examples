// -----------------------------------------------------------------------------
// Example: Remove hyperlink from outdated media frame using C#
//
// Description:
// Demonstrates how to remove hyperlinks from video, audio, and OLE object
// frames in a PowerPoint presentation using Aspose.Slides for .NET. The
// example loads a PPTX file, iterates through all slides and shapes, clears
// click and mouse‑over hyperlinks from media frames, and saves the result.
// This pattern helps automate cleanup of legacy presentations before
// distribution.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Hyperlink, Media Frame,
// Video, Audio, OLE, Presentation Processing, Office Automation
//
// Use Cases:
// - Clean up old presentations by removing hyperlinks from embedded media.
// - Build .NET tools that prepare PPTX files for publishing or archiving.
// - Ensure compliance by stripping interactive links from media objects.
// - Integrate hyperlink removal into automated PowerPoint workflow pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveOutdatedMediaHyperlinks
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Remove hyperlink from video frames
                            if (shape is IVideoFrame)
                            {
                                IVideoFrame videoFrame = (IVideoFrame)shape;
                                if (videoFrame.HyperlinkClick != null)
                                {
                                    videoFrame.HyperlinkClick = null;
                                }
                            }

                            // Remove hyperlink from audio frames
                            if (shape is IAudioFrame)
                            {
                                IAudioFrame audioFrame = (IAudioFrame)shape;
                                if (audioFrame.HyperlinkClick != null)
                                {
                                    audioFrame.HyperlinkClick = null;
                                }
                            }

                            // Remove hyperlink from OLE object frames
                            if (shape is IOleObjectFrame)
                            {
                                IOleObjectFrame oleFrame = (IOleObjectFrame)shape;
                                if (oleFrame.HyperlinkClick != null)
                                {
                                    oleFrame.HyperlinkClick = null;
                                }
                            }

                            // Alternative approach using HyperlinkManager (removes both click and mouseover)
                            IHyperlinkManager hyperlinkManager = shape.HyperlinkManager;
                            if (hyperlinkManager != null)
                            {
                                hyperlinkManager.RemoveHyperlinkClick();
                                hyperlinkManager.RemoveHyperlinkMouseOver();
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX files
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported for PPT files
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
