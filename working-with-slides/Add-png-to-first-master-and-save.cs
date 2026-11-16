// -----------------------------------------------------------------------------
// Example: Add PNG Image to First Master Slide and Save Presentation
//
// Description:
// Demonstrates how to add a PNG image to the first master slide of a new
// presentation and save the result as a PPTX file using C# and Aspose.Slides
// for .NET. The program creates a sample PNG if none exists, inserts the image
// into the master slide covering the entire slide area, and writes the output.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Master Slide, Add Image, Save Presentation
//
// Use Cases:
// - Automate adding a background PNG to the first master slide of presentations.
// - Build .NET tools for PowerPoint master slide customization.
// - Generate or modify PPTX files programmatically in C# applications.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;

class Program
{
    static int Main()
    {
        string inputImagePath = "sample.png";
        string outputPath = "output.pptx";

        // Ensure sample PNG exists; create a simple one if missing
        if (!File.Exists(inputImagePath))
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(800, 600))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.Clear(Color.LightBlue);
                        using (Pen pen = new Pen(Color.DarkBlue, 5))
                        {
                            graphics.DrawRectangle(pen, 10, 10, 780, 580);
                        }
                    }
                    bitmap.Save(inputImagePath, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample image: " + ex.Message);
                return 1;
            }
        }

        // Verify the image file now exists
        if (!File.Exists(inputImagePath))
        {
            Console.WriteLine("Input image file does not exist.");
            return 1;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Load image data and add to presentation's image collection
                byte[] imageData = File.ReadAllBytes(inputImagePath);
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageData);

                // Access the first master slide
                Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

                // Add picture frame covering the entire master slide area
                masterSlide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    0,
                    0,
                    presentation.SlideSize.Size.Width,
                    presentation.SlideSize.Size.Height,
                    image);

                // Save the presentation as PPTX
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported.");
            return 1;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return 1;
        }

        Console.WriteLine("Presentation saved successfully to " + outputPath);
        return 0;
    }
}
