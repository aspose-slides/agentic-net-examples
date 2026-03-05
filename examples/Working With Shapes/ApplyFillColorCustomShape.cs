using System;

namespace FillColorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle autoshape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

            // Set fill type to solid and apply a scheme color
            autoShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            autoShape.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent1;

            // Save the presentation
            presentation.Save("CustomShapeFill.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}