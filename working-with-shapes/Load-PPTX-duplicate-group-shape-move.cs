using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output_duplicated.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    ISlide slide = presentation.Slides[0];
                    IShape shape = slide.Shapes[0];
                    IGroupShape groupShape = shape as IGroupShape;
                    if (groupShape == null)
                    {
                        Console.WriteLine("No group shape found on the first slide.");
                        return;
                    }

                    // Clone the group shape
                    IShape clonedShape = slide.Shapes.AddClone(groupShape);
                    // Modify position of the cloned group shape
                    clonedShape.X = groupShape.X + 50;
                    clonedShape.Y = groupShape.Y + 50;

                    // Save the presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (including loading errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}