using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths
            var inputImagePath = "sample.jpg";
            var outputPath = "custom_shape_picture_fill.pptx";

            // Verify input image exists
            if (!File.Exists(inputImagePath))
            {
                Console.WriteLine("Input image file not found.");
                return;
            }

            try
            {
                // Create a new presentation
                var pres = new Presentation();

                // Add a custom geometry shape (based on a rectangle)
                var shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200) as GeometryShape;

                // Define a simple custom geometry (triangle)
                var geometryPath = shape.GetGeometryPaths()[0];
                geometryPath.MoveTo(0, 0);
                geometryPath.LineTo(shape.Width, 0);
                geometryPath.LineTo(shape.Width / 2, shape.Height);
                geometryPath.CloseFigure();

                // Apply the custom geometry to the shape
                shape.SetGeometryPath(geometryPath);

                // Load image from stream and add to presentation resources
                using (var imgStream = new FileStream(inputImagePath, FileMode.Open, FileAccess.Read))
                {
                    var ppImage = pres.Images.AddImage(imgStream);

                    // Apply picture fill to the custom shape
                    shape.FillFormat.FillType = FillType.Picture;
                    shape.FillFormat.PictureFillFormat.Picture.Image = ppImage;
                    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
                Console.WriteLine("Presentation saved successfully.");
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}