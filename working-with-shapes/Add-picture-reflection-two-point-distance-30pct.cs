// -----------------------------------------------------------------------------
// Example: Add picture reflection with two-point distance and 30% opacity using C#
// 
// Description:
// Demonstrates how to insert an image into a PowerPoint slide and apply a
// reflection effect with a distance of two points and 30% transparency using
// Aspose.Slides for .NET. The program creates a sample image if none is found,
// saves the modified presentation, and exits with an appropriate status code.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, picture reflection, distance, opacity
// 
// Use Cases:
// - Automate adding reflective images to presentations.
// - Build tools for batch processing of PPTX files with visual effects.
// - Integrate reflection styling into .NET presentation generation workflows.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ReflectionEffectDemo
{
    class Program
    {
        static int Main(string[] args)
        {
            string inputPath = "input.jpg";
            string outputPath = "output.pptx";

            try
            {
                // Ensure sample image exists
                if (!File.Exists(inputPath))
                {
                    using (Bitmap bitmap = new Bitmap(200, 200))
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.Clear(Color.LightGray);
                            using (Pen pen = new Pen(Color.DarkBlue, 4))
                            {
                                graphics.DrawEllipse(pen, 20, 20, 160, 160);
                            }
                        }
                        bitmap.Save(inputPath, ImageFormat.Jpeg);
                    }
                }

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Load the image and add it to the presentation's image collection
                Aspose.Slides.IImage slideImage = Aspose.Slides.Images.FromFile(inputPath);
                Aspose.Slides.IPPImage ppImage = presentation.Images.AddImage(slideImage);

                // Add picture frame to the first slide
                Aspose.Slides.IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    50,
                    50,
                    slideImage.Width,
                    slideImage.Height,
                    ppImage);

                // Enable reflection effect and configure properties
                pictureFrame.EffectFormat.EnableReflectionEffect();
                pictureFrame.EffectFormat.ReflectionEffect.Distance = 2.0; // two point distance
                pictureFrame.EffectFormat.ReflectionEffect.EndReflectionOpacity = 70f; // 30% transparency

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 1;
            }

            Console.WriteLine("Presentation saved to " + outputPath);
            return 0;
        }
    }
}
