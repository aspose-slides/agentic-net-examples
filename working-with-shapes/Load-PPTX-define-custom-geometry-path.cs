using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load an existing PPTX presentation
                Presentation pres = new Presentation("input.pptx");

                // Add a rectangle shape to the first slide
                GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(
                    ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

                // Define a custom geometry path for the shape
                GeometryPath geometryPath = new GeometryPath();
                geometryPath.MoveTo(0, 0);
                geometryPath.LineTo(shape.Width, 0);
                geometryPath.LineTo(shape.Width, shape.Height / 3);
                geometryPath.LineTo(0, shape.Height / 3);
                geometryPath.CloseFigure();

                // Apply the custom geometry to the shape
                shape.SetGeometryPath(geometryPath);

                // Save the modified presentation
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}