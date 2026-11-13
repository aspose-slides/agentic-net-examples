// -----------------------------------------------------------------------------
// Example: Add custom triangle shape with picture fill to PPTX using C#
// 
// Description:
// This console program creates a PowerPoint presentation, adds a custom
// triangle shape, applies a picture fill using a local image, and saves the
// result as a PPTX file. It demonstrates custom geometry definition and
// picture fill styling with Aspose.Slides for .NET.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, custom shape, picture fill, geometry
// 
// Use Cases:
// - Automate adding custom-shaped picture fills to PowerPoint presentations.
// - Build utilities for advanced shape styling in PPTX files.
// - Generate presentations with custom graphics in .NET applications.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        public static int Main(string[] args)
        {
            string inputImagePath = "sample.jpg";
            string outputPath = "custom_shape_picture_fill.pptx";

            // Create a sample image if it does not exist
            if (!File.Exists(inputImagePath))
            {
                try
                {
                    using (Bitmap bmp = new Bitmap(200, 200))
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.Clear(Color.LightBlue);
                            g.FillEllipse(Brushes.DarkBlue, 25, 25, 150, 150);
                        }
                        bmp.Save(inputImagePath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample image: " + ex.Message);
                    return 1;
                }
            }

            // Verify input image exists
            if (!File.Exists(inputImagePath))
            {
                Console.WriteLine("Input image file not found.");
                return 1;
            }

            try
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                Aspose.Slides.ISlide slide = pres.Slides[0];

                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);

                // Change shape to custom geometry (triangle)
                shape.ShapeType = Aspose.Slides.ShapeType.Custom;

                Aspose.Slides.IGeometryPath geometryPath = shape.GetGeometryPaths()[0];
                geometryPath.MoveTo(0, 0);
                geometryPath.LineTo(shape.Width, 0);
                geometryPath.LineTo(shape.Width / 2, shape.Height);
                geometryPath.CloseFigure();

                shape.SetGeometryPath(geometryPath);

                using (FileStream imgStream = new FileStream(inputImagePath, FileMode.Open, FileAccess.Read))
                {
                    Aspose.Slides.IPPImage ppImage = pres.Images.AddImage(imgStream);

                    shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                    shape.FillFormat.PictureFillFormat.Picture.Image = ppImage;
                    shape.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;
                }

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Presentation saved successfully.");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // The provided file format may not be supported by Aspose.Slides.
                return 1;
            }
        }
    }
}
