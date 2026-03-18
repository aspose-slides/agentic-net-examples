using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace RotateShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation presentation = new Presentation("input.pptx");

                // Find the shape by its alternative text
                IShape shape = SlideUtil.FindShape(presentation, "TargetShape");

                if (shape != null)
                {
                    // Apply a rotation of 45 degrees
                    shape.Rotation = 45f;
                }
                else
                {
                    Console.WriteLine("Shape with the specified alternative text was not found.");
                }

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}