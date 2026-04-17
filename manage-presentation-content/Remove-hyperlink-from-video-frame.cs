using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveVideoHyperlink
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Format not supported comment
                // Format not supported.
                return;
            }

            try
            {
                // Iterate through slides and shapes to find video frames
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.IVideoFrame)
                        {
                            Aspose.Slides.IVideoFrame videoFrame = (Aspose.Slides.IVideoFrame)shape;
                            // Remove hyperlink on click to prevent navigation
                            videoFrame.HyperlinkManager.RemoveHyperlinkClick();
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            finally
            {
                // Ensure the presentation is disposed
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}