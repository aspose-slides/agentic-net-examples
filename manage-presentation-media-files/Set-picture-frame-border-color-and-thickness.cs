using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace PictureFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string imagePath = Path.Combine(currentDirectory, "image.jpg");
            string outputPath = Path.Combine(currentDirectory, "output.pptx");

            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            try
            {
                Presentation pres = new Presentation();
                ISlide slide = pres.Slides[0];

                IImage img = Images.FromFile(imagePath);
                IPPImage imgX = pres.Images.AddImage(img);

                IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    50f,
                    50f,
                    imgX.Width,
                    imgX.Height,
                    imgX);

                // Set border style
                pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
                pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                pictureFrame.LineFormat.Width = 3f; // thickness

                pres.Save(outputPath, SaveFormat.Pptx);
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