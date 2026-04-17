using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DetectMissingAudioThumbnails
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation not found: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    int slideNumber = 0;
                    foreach (ISlide slide in pres.Slides)
                    {
                        slideNumber++;
                        foreach (IShape shape in slide.Shapes)
                        {
                            IAudioFrame audioFrame = shape as IAudioFrame;
                            if (audioFrame != null)
                            {
                                // Check if the audio frame has an associated thumbnail image
                                if (audioFrame.PictureFormat == null ||
                                    audioFrame.PictureFormat.Picture == null ||
                                    audioFrame.PictureFormat.Picture.Image == null)
                                {
                                    Console.WriteLine($"Slide {slideNumber}: Audio frame '{audioFrame.Name}' has no thumbnail.");
                                }
                            }
                        }
                    }

                    // Save the (potentially unchanged) presentation
                    string outputPath = "output.pptx";
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine("Operation not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}