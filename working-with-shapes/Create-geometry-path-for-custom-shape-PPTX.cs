using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CustomShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape and treat it as a geometry shape
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
                Aspose.Slides.GeometryShape geometryShape = autoShape as Aspose.Slides.GeometryShape;

                // Create a custom geometry path (e.g., a simple house shape)
                Aspose.Slides.GeometryPath geometryPath = new Aspose.Slides.GeometryPath();
                geometryPath.MoveTo(0, 0);
                geometryPath.LineTo(geometryShape.Width, 0);
                geometryPath.LineTo(geometryShape.Width, geometryShape.Height / 2);
                geometryPath.LineTo(geometryShape.Width / 2, geometryShape.Height);
                geometryPath.LineTo(0, geometryShape.Height / 2);
                geometryPath.CloseFigure();

                // Apply the custom geometry to the shape
                geometryShape.SetGeometryPath(geometryPath);

                // Save the presentation
                presentation.Save("CustomShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}