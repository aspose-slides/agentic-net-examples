using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input SVG file path
        string svgPath = "input.svg";
        // Output PPTX file path
        string outputPath = "output.pptx";

        // Verify that the SVG file exists
        if (!File.Exists(svgPath))
        {
            Console.WriteLine("SVG file not found: " + svgPath);
            return;
        }

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Load the SVG content into an ISvgImage object
            Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgPath);

            // Convert the SVG image into individual shapes by adding a group shape to the first slide
            // The group shape will contain the vector shapes extracted from the SVG
            Aspose.Slides.IGroupShape groupShape = pres.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, 500f, 500f);

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Handle unsupported file format
            Console.WriteLine("The provided file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL or I/O errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}