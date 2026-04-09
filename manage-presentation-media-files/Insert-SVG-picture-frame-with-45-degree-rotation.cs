using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define directories and file paths
        string dataDir = "Data";
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        string svgPath = Path.Combine(dataDir, "input.svg");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Verify that the SVG input file exists
        if (!File.Exists(svgPath))
        {
            Console.WriteLine("SVG file not found: " + svgPath);
            return;
        }

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Load SVG content and create an SVG image object
            string svgContent = File.ReadAllText(svgPath);
            Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgContent);

            // Add the SVG image to the presentation's image collection
            Aspose.Slides.IPPImage ppImage = presentation.Images.AddImage(svgImage);

            // Insert the SVG as a picture frame on the first slide
            Aspose.Slides.IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                0,
                0,
                ppImage.Width,
                ppImage.Height,
                ppImage);

            // Apply a 45-degree rotation to the picture frame
            pictureFrame.Rotation = 45f;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}