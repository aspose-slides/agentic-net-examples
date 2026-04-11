using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VideoThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Output directory for thumbnails and modified presentation
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Custom timestamp offset in milliseconds (e.g., 5 seconds)
            float timestampOffsetMs = 5000f;

            Aspose.Slides.Presentation pres = null;
            try
            {
                // Load presentation
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Format not supported comment
                // The provided file format is not supported by Aspose.Slides.
                return;
            }

            // Iterate through slides
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                // Iterate through shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Process only video frames
                    if (shape is Aspose.Slides.IVideoFrame)
                    {
                        Aspose.Slides.IVideoFrame videoFrame = (Aspose.Slides.IVideoFrame)shape;

                        // Apply custom timestamp offset
                        videoFrame.TrimFromStart = timestampOffsetMs;

                        // Generate thumbnail of the slide (full scale)
                        Aspose.Slides.IImage thumbnail = slide.GetImage(1f, 1f);

                        // Build output thumbnail file name
                        string thumbnailPath = Path.Combine(
                            outputDir,
                            $"slide_{slideIndex + 1}_shape_{shapeIndex}_thumb.jpg");

                        // Save thumbnail as JPEG
                        thumbnail.Save(thumbnailPath, Aspose.Slides.ImageFormat.Jpeg);
                        thumbnail.Dispose();
                    }
                }
            }

            // Save the modified presentation
            string outputPresentationPath = Path.Combine(outputDir, "modified.pptx");
            pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}