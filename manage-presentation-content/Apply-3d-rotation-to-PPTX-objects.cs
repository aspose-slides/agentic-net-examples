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

            // Add a rectangle shape to the first slide
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);

            // Set text for the shape
            shape.TextFrame.Text = "3D Shape";

            // Apply 3D rotation using the shape's ThreeDFormat
            shape.ThreeDFormat.Camera.SetRotation(30, 40, 0); // X, Y, Z rotation angles
            shape.ThreeDFormat.Depth = 50; // Depth of the 3D effect
            shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic; // Material preset

            // Save the presentation
            presentation.Save("3DShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}