using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);
            try
            {
                int videoFrameIndex = 0;

                // Iterate through all slides and shapes to find video frames
                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IVideoFrame videoFrame)
                        {
                            IVideo video = videoFrame.EmbeddedVideo;

                            // Placeholder: extract duration and resolution from the video stream
                            // Aspose.Slides does not expose duration/resolution directly.
                            // You would need an external media library to read these properties.
                            Console.WriteLine($"Video Frame {videoFrameIndex}: ContentType = {video.ContentType}");

                            videoFrameIndex++;
                        }
                    }
                }

                // Save the presentation before exiting
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            finally
            {
                // Ensure resources are released
                pres.Dispose();
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}