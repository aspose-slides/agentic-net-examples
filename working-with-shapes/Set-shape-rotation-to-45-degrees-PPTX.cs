using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Presentation presentation = new Presentation(inputPath))
            {
                // Locate the shape by its alternative text
                IShape shape = SlideUtil.FindShape(presentation, "MyShapeAltText");
                if (shape != null)
                {
                    // Apply a 45-degree rotation
                    shape.Rotation = 45f;
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}