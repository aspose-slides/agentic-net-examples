using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Create an empty group shape on the slide
            Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();

            // Move all existing shapes (except the newly created group) into the group
            for (int i = slide.Shapes.Count - 1; i >= 0; i--)
            {
                Aspose.Slides.IShape shape = slide.Shapes[i];
                if (shape == groupShape)
                    continue;

                // Clone the shape into the group
                groupShape.Shapes.AddClone(shape);
                // Remove the original shape from the slide
                slide.Shapes.Remove(shape);
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}