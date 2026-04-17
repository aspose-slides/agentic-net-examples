using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceVideoWithGif
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output presentation path
            string outputPath = "output.pptx";
            // Animated GIF to replace videos with
            string gifPath = "animation.gif";

            // Verify input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation not found: " + inputPath);
                return;
            }
            if (!File.Exists(gifPath))
            {
                Console.WriteLine("GIF file not found: " + gifPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Load GIF image once
                    byte[] gifData = File.ReadAllBytes(gifPath);
                    IPPImage gifImage = pres.Images.AddImage(gifData);

                    // Iterate through all slides and shapes
                    foreach (ISlide slide in pres.Slides)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Identify video frames
                            if (shape is IVideoFrame)
                            {
                                IVideoFrame videoFrame = (IVideoFrame)shape;

                                // Replace visual content with the animated GIF
                                videoFrame.PictureFormat.Picture.Image = gifImage;

                                // Remove embedded video reference (optional)
                                videoFrame.EmbeddedVideo = null;
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}