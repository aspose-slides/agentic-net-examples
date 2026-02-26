using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load the presentation from a PPTX file
        Presentation presentation = new Presentation("input.pptx");

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                IShape shape = slide.Shapes[shapeIndex];

                // Check if the shape name matches the flash control name
                if (shape.Name == "FlashControl")
                {
                    // Attempt to cast the shape to a video frame (Flash objects are stored as embedded video frames)
                    IVideoFrame videoFrame = shape as IVideoFrame;
                    if (videoFrame != null && videoFrame.EmbeddedVideo != null)
                    {
                        // Extract the binary data of the embedded SWF object
                        byte[] swfData = videoFrame.EmbeddedVideo.BinaryData;

                        // Write the SWF data to a file
                        File.WriteAllBytes("extracted_flash.swf", swfData);
                    }
                }
            }
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}