using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load an existing presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add a rectangle shape that will be converted to a custom star shape
                    Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 200);
                    Aspose.Slides.GeometryShape starShape = autoShape as Aspose.Slides.GeometryShape;

                    // Define the geometry of a 5‑point star
                    Aspose.Slides.GeometryPath geometryPath = new Aspose.Slides.GeometryPath();
                    geometryPath.MoveTo(100, 0);      // Top point
                    geometryPath.LineTo(120, 70);
                    geometryPath.LineTo(190, 70);
                    geometryPath.LineTo(135, 115);
                    geometryPath.LineTo(155, 185);
                    geometryPath.LineTo(100, 145);
                    geometryPath.LineTo(45, 185);
                    geometryPath.LineTo(65, 115);
                    geometryPath.LineTo(10, 70);
                    geometryPath.LineTo(80, 70);
                    geometryPath.CloseFigure();

                    // Apply the custom geometry to the shape
                    starShape.SetGeometryPath(geometryPath);

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
}