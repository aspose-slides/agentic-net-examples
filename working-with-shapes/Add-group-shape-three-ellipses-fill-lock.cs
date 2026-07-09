using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a group shape to the slide
        Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();

        // Add three ellipses to the group shape
        Aspose.Slides.IShape ellipse1 = groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 50, 50, 100, 100);
        Aspose.Slides.IShape ellipse2 = groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 200, 50, 100, 100);
        Aspose.Slides.IShape ellipse3 = groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 350, 50, 100, 100);

        // Set fill colors for each ellipse
        ellipse1.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        ellipse1.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(255, 200, 200); // Light red

        ellipse2.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        ellipse2.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(200, 255, 200); // Light green

        ellipse3.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        ellipse3.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(200, 200, 255); // Light blue

        // Lock the group shape to prevent moving and resizing
        groupShape.GroupShapeLock.PositionLocked = true;
        groupShape.GroupShapeLock.SizeLocked = true;

        // Save the presentation
        string outputPath = "GroupShapeExample.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}