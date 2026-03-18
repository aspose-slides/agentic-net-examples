using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation from a file
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
                {
                    // Find the shape by its alternative text (replace "TargetShape" with the actual alt text)
                    Aspose.Slides.IShape targetShape = SlideUtil.FindShape(presentation, "TargetShape");

                    if (targetShape != null)
                    {
                        // Set the height of the shape to 200 points
                        targetShape.Height = 200f;
                    }
                    else
                    {
                        Console.WriteLine("Shape with the specified alternative text was not found.");
                    }

                    // Save the modified presentation
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}