using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GroupShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outPath = "GroupShapeCustomGeometry_out.pptx";
            string outDir = Path.GetDirectoryName(Path.GetFullPath(outPath));
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a group shape to the slide
            IGroupShape group = slide.Shapes.AddGroupShape();

            // Add a custom geometry shape inside the group
            GeometryShape customShape = group.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

            // Get the geometry path of the shape
            IGeometryPath[] geometryPaths = customShape.GetGeometryPaths();
            IGeometryPath geometryPath = geometryPaths[0];

            // Define complex geometry (example: a triangle)
            geometryPath.MoveTo(0, 0);
            geometryPath.LineTo(customShape.Width, 0, 1);
            geometryPath.LineTo(customShape.Width / 2, customShape.Height, 1);
            geometryPath.CloseFigure();

            // Apply the geometry path to the shape
            customShape.SetGeometryPath(geometryPath);

            // Set rotation of the custom shape
            customShape.Rotation = 45f;

            // Save the presentation
            pres.Save(outPath, SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}