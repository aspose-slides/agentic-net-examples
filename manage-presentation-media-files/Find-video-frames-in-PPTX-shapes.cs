using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VideoFrameTraversal
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Paths to input and output presentations
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape is a VideoFrame
                        if (shape is Aspose.Slides.VideoFrame)
                        {
                            Aspose.Slides.VideoFrame videoFrame = (Aspose.Slides.VideoFrame)shape;
                            Console.WriteLine($"VideoFrame found on slide {slideIndex + 1}, shape index {shapeIndex}, name: {videoFrame.Name}");
                        }
                    }
                }

                // Save the (potentially unchanged) presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}