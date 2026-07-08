using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CustomShapeWithPictureFill
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input image path (stream source) and output presentation path
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.jpg");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "CustomShapeOutput.pptx");

            // Verify input image exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Input image file not found: " + imagePath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Add a custom geometry shape (based on a rectangle) to the first slide
                GeometryShape customShape = pres.Slides[0].Shapes.AddAutoShape(
                    ShapeType.Rectangle, 100, 100, 300, 200) as GeometryShape;

                // Modify the geometry path (example: add a diagonal line)
                IGeometryPath geometryPath = customShape.GetGeometryPaths()[0];
                geometryPath.LineTo(300, 0, 1); // line to top-right corner
                geometryPath.LineTo(0, 200, 1); // line to bottom-left corner
                geometryPath.CloseFigure();

                // Apply the modified geometry to the shape
                customShape.SetGeometryPath(geometryPath);

                // Load image from stream and add it to presentation resources
                FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                IPPImage ppImage = pres.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);
                imageStream.Dispose();

                // Set picture fill for the custom shape
                customShape.FillFormat.FillType = FillType.Picture;
                customShape.FillFormat.PictureFillFormat.Picture.Image = ppImage;
                customShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}