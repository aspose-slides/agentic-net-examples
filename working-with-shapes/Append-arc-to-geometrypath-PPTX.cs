using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GeometryArcExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load existing presentation
                Presentation presentation = new Presentation("input.pptx");

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape (will be used as geometry shape)
                IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

                // Cast to GeometryShape to work with geometry paths
                GeometryShape geometryShape = autoShape as GeometryShape;
                if (geometryShape != null)
                {
                    // Retrieve existing geometry paths
                    IGeometryPath[] geometryPaths = geometryShape.GetGeometryPaths();
                    if (geometryPaths != null && geometryPaths.Length > 0)
                    {
                        // Modify the first geometry path by appending an arc
                        IGeometryPath geometryPath = geometryPaths[0];
                        geometryPath.ArcTo(50f, 50f, 0f, 180f); // width, height, startAngle, sweepAngle

                        // Apply the modified geometry path back to the shape
                        geometryShape.SetGeometryPath(geometryPath);
                    }
                }

                // Save the presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}