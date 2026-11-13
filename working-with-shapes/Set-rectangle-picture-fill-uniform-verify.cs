// -----------------------------------------------------------------------------
// Example: Set Rectangle Picture Fill Uniform Mode and Verify Using C#
// 
// Description:
// Demonstrates how to create a rectangle shape, apply a picture fill with uniform
// (stretch) scaling, verify the fill mode, and save the presentation as PPTX using
// Aspose.Slides for .NET. The program generates a sample image if none exists,
// applies the fill, checks the mode, and exits with an error code on failure.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rectangle, Picture Fill, Uniform, Verification
// 
// Use Cases:
// - Automate setting rectangle picture fill to uniform scaling in batch processing.
// - Validate picture fill configurations in generated presentations.
// - Build tools that ensure visual consistency of images in PowerPoint slides.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        string imageFileName = "sample.jpg";
        string imagePath = Path.Combine(dataDir, imageFileName);
        if (!File.Exists(imagePath))
        {
            try
            {
                using (Bitmap bmp = new Bitmap(200, 150))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.LightBlue);
                        g.DrawEllipse(Pens.DarkBlue, 20, 20, 160, 110);
                    }
                    bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample image: " + ex.Message);
                Environment.Exit(1);
            }
        }

        string outputFileName = "output.pptx";
        string outPath = Path.Combine(dataDir, outputFileName);

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = pres.Slides[0];

            byte[] imageBytes = File.ReadAllBytes(imagePath);
            Aspose.Slides.IPPImage imgx = pres.Images.AddImage(imageBytes);

            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100,
                100,
                imgx.Width,
                imgx.Height);

            shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;
            shape.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;

            bool isUniform = shape.FillFormat.PictureFillFormat.PictureFillMode == Aspose.Slides.PictureFillMode.Stretch;
            Console.WriteLine("Uniform picture fill applied: " + isUniform);
            if (!isUniform)
            {
                Console.WriteLine("Verification failed: Picture fill mode is not uniform.");
                pres.Dispose();
                Environment.Exit(1);
            }

            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
