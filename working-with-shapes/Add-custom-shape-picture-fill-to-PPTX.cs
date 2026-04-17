using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input image and output presentation
        string imagePath = "image.jpg";
        string outputPath = "output.pptx";

        // Verify that the image file exists
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found.");
            return;
        }

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a custom geometry shape (initially a rectangle) to the first slide
        Aspose.Slides.GeometryShape customShape = pres.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100) as Aspose.Slides.GeometryShape;

        // Define a custom geometry path (e.g., a triangle)
        Aspose.Slides.IGeometryPath geometryPath = customShape.GetGeometryPaths()[0];
        geometryPath.MoveTo(0, 0);
        geometryPath.LineTo(customShape.Width, 0);
        geometryPath.LineTo(customShape.Width / 2, customShape.Height);
        geometryPath.CloseFigure();

        // Apply the custom geometry to the shape
        customShape.SetGeometryPath(geometryPath);

        // Add picture fill from a stream source
        using (FileStream imgStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        {
            Aspose.Slides.IPPImage ppImage = pres.Images.AddImage(imgStream);
            customShape.FillFormat.FillType = Aspose.Slides.FillType.Picture;
            customShape.FillFormat.PictureFillFormat.Picture.Image = ppImage;
            customShape.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;
        }

        // Save the presentation, handling possible format errors
        try
        {
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Format not supported or other saving error
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Clean up
        pres.Dispose();
    }
}