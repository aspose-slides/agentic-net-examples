// -----------------------------------------------------------------------------
// Example: Set picture frame border color and thickness using C#
//
// Description:
// Demonstrates how to set picture frame border color and thickness using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Picture, Frame, Border, Color, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set picture frame border color and thickness.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
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
