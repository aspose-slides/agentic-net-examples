using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Get the shape to be cloned (e.g., the first shape on the slide)
                Aspose.Slides.IShape sourceShape = slide.Shapes[0];

                // Clone the shape and add it to the same slide
                Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(sourceShape);

                // Optionally reposition the cloned shape
                clonedShape.X = sourceShape.X + 50;
                clonedShape.Y = sourceShape.Y + 50;

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}