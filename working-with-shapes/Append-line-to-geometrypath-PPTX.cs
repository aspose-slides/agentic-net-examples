using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GeometryPathExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load an existing presentation
                Presentation presentation = new Presentation("input.pptx");

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Assume the first shape is a GeometryShape
                IGeometryShape geometryShape = slide.Shapes[0] as IGeometryShape;
                if (geometryShape == null)
                {
                    throw new InvalidOperationException("The first shape is not a geometry shape.");
                }

                // Retrieve the first geometry path of the shape
                IGeometryPath[] geometryPaths = geometryShape.GetGeometryPaths();
                if (geometryPaths == null || geometryPaths.Length == 0)
                {
                    throw new InvalidOperationException("No geometry paths found on the shape.");
                }

                IGeometryPath geometryPath = geometryPaths[0];

                // Append a line segment to the geometry path
                geometryPath.LineTo(100f, 50f); // Example coordinates

                // Apply the modified geometry path back to the shape
                geometryShape.SetGeometryPath(geometryPath);

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}