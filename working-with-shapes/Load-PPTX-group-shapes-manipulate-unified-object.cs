using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing PPTX file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide in the presentation
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Create a new empty group shape on the slide
            Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();

            // Add a rectangle shape to the group
            groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 100, 100);

            // Add an ellipse shape to the group
            groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 200, 50, 100, 100);

            // Manipulate the group as a single object (rotate the entire group)
            groupShape.Rotation = 45;

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}