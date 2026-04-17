using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CacheAudioFrameThumbnails
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string presentationPath = "input.pptx";
            // Cache folder for thumbnails
            string cacheFolder = "Cache";

            // Verify input file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            // Ensure cache directory exists
            Directory.CreateDirectory(cacheFolder);

            try
            {
                // Load presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Iterate through slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        int audioIndex = 0;

                        // Iterate through shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            // Check if the shape is an audio frame
                            AudioFrame audioFrame = shape as AudioFrame;
                            if (audioFrame != null)
                            {
                                // Generate thumbnail for the audio frame
                                IImage thumbnail = audioFrame.GetImage();
                                // Build thumbnail file name
                                string thumbnailPath = Path.Combine(
                                    cacheFolder,
                                    $"slide_{slideIndex + 1}_audio_{audioIndex + 1}.png");

                                // Save thumbnail image
                                thumbnail.Save(thumbnailPath, Aspose.Slides.ImageFormat.Png);
                                audioIndex++;
                            }
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}