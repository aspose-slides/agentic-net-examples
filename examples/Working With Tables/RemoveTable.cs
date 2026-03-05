using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Iterate through shapes in reverse order to safely remove items
            for (int shapeIndex = slide.Shapes.Count - 1; shapeIndex >= 0; shapeIndex--)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                Aspose.Slides.ITable table = shape as Aspose.Slides.ITable;

                // If the shape is a table, remove it from the slide
                if (table != null)
                {
                    slide.Shapes.RemoveAt(shapeIndex);
                }
            }
        }

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}