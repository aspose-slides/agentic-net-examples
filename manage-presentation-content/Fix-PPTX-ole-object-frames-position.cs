using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FixOleObjectFrames
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_fixed.pptx";

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    foreach (ISlide slide in pres.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Cast shape to OleObjectFrame
                            OleObjectFrame oleFrame = shape as OleObjectFrame;
                            if (oleFrame != null)
                            {
                                // Lock position, size, and aspect ratio to prevent resizing or moving
                                oleFrame.ShapeLock.PositionLocked = true;
                                oleFrame.ShapeLock.SizeLocked = true;
                                oleFrame.ShapeLock.AspectRatioLocked = true;
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}