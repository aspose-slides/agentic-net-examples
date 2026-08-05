// -----------------------------------------------------------------------------
// Example: Add picture reflection two point distance 30pct using C#
//
// Description:
// Demonstrates how to add picture reflection two point distance 30pct using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Picture, Reflection, Point, 
// Distance, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate add picture reflection two point distance 30pct.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReflectionEffectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.jpg";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input image file not found: " + inputPath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Load the image and add it as a picture frame
                IImage img = Images.FromFile(inputPath);
                IPPImage image = pres.Images.AddImage(img);
                IPictureFrame picture = pres.Slides[0].Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    50, 50,
                    img.Width, img.Height,
                    image);

                // Enable reflection effect and configure properties
                picture.EffectFormat.EnableReflectionEffect();
                picture.EffectFormat.ReflectionEffect.Distance = 2.0; // two point distance
                picture.EffectFormat.ReflectionEffect.EndReflectionOpacity = 70f; // 30% transparency

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // Handle format not supported or other specific exceptions as needed
            }
        }
    }
}
