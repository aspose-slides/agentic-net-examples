using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to the slide
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

            // Translate the shape (move it)
            shape.X = shape.X + 50;
            shape.Y = shape.Y + 30;

            // Rotate the shape by 45 degrees
            shape.Rotation = 45;

            // Scale the shape (increase size by 1.5 times)
            shape.Width = shape.Width * 1.5f;
            shape.Height = shape.Height * 1.5f;

            // Duplicate the shape
            Aspose.Slides.IShape duplicatedShape = slide.Shapes.AddClone(shape);
            // Move the duplicated shape to a new position
            duplicatedShape.X = duplicatedShape.X + 300;
            duplicatedShape.Y = duplicatedShape.Y;

            // Save the presentation
            presentation.Save("ShapeTransformations_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}