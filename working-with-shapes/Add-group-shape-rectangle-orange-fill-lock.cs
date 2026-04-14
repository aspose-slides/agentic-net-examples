using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            var pres = new Aspose.Slides.Presentation();
            var slide = pres.Slides[0];
            var groupShape = slide.Shapes.AddGroupShape();

            // Add a rectangle inside the group shape
            var rect = groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100f, 100f, 200f, 100f);
            rect.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            rect.FillFormat.SolidFillColor.Color = System.Drawing.Color.Orange;

            // Lock the rectangle (prevent grouping changes)
            rect.ShapeLock.GroupingLocked = true;

            // Save the presentation
            pres.Save("GroupShapeExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // For unsupported format, comment: format not supported
        }
    }
}