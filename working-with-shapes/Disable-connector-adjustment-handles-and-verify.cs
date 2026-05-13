using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectorAdjustmentDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                Presentation presentation = new Presentation(inputPath);

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Shape shape = (Shape)slide.Shapes[shapeIndex];
                        if (shape is Connector)
                        {
                            Connector connector = (Connector)shape;
                            // Disable adjustment handles
                            connector.ConnectorLock.AdjustHandlesLocked = true;

                            // Verify that the handles are locked
                            bool isLocked = connector.ConnectorLock.AdjustHandlesLocked;
                            Console.WriteLine($"Connector on slide {slideIndex}, shape {shapeIndex} adjustment handles locked: {isLocked}");
                        }
                    }
                }

                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the exception is due to unsupported format, you could add a comment here.
                // Format not supported.
            }
        }
    }
}