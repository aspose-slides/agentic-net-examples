using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace UnlockGroupShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output_unlocked.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            IGroupShape groupShape = shape as IGroupShape;

                            if (groupShape != null)
                            {
                                // Unlock all editing-related locks on the group shape
                                IGroupShapeLock lockObj = groupShape.GroupShapeLock;
                                lockObj.PositionLocked = false;
                                lockObj.SizeLocked = false;
                                lockObj.RotationLocked = false;
                                lockObj.SelectLocked = false;
                                lockObj.UngroupingLocked = false;
                                lockObj.GroupingLocked = false;
                                lockObj.AspectRatioLocked = false;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}