using System;
using System.IO;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertVideoPlaceholder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = null;
            try
            {
                pres = new Aspose.Slides.Presentation();

                // Get the first (intro) slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a video frame that references an external streaming URL
                string videoUrl = "https://www.youtube.com/embed/Tj75Arhq5ho";
                Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 427, 240, videoUrl);

                // Set play mode to auto
                videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;

                // Add a hyperlink to the video frame (optional)
                videoFrame.HyperlinkClick = new Aspose.Slides.Hyperlink(videoUrl);
                videoFrame.HyperlinkClick.Tooltip = "Watch video";

                // Save the presentation
                pres.Save("IntroVideoPlaceholder.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (WebException ex)
            {
                // Handle web related errors (e.g., URL not reachable)
                Console.WriteLine("Web error while accessing video URL: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }
    }
}