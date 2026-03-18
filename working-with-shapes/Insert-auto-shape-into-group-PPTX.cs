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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Get the slide's shape collection
            Aspose.Slides.IShapeCollection slideShapes = slide.Shapes;

            // Find an existing group shape or create a new one
            Aspose.Slides.IGroupShape groupShape = null;
            foreach (Aspose.Slides.IShape shape in slideShapes)
            {
                if (shape is Aspose.Slides.IGroupShape)
                {
                    groupShape = (Aspose.Slides.IGroupShape)shape;
                    break;
                }
            }
            if (groupShape == null)
            {
                groupShape = slideShapes.AddGroupShape();
                groupShape.X = 100;
                groupShape.Y = 100;
                groupShape.Width = 400;
                groupShape.Height = 300;
            }

            // Insert an auto shape into the group, preserving relative positioning
            Aspose.Slides.IAutoShape autoShape = groupShape.Shapes.InsertAutoShape(
                0,
                Aspose.Slides.ShapeType.Rectangle,
                50,   // X relative to group
                50,   // Y relative to group
                100,  // Width
                60    // Height
            );

            // Add a text frame to the new shape
            autoShape.AddTextFrame("Inserted Shape");

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}