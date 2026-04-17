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