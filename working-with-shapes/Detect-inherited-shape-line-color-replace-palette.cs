using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load presentation with exception handling for unsupported formats
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Iterate through shapes on the first slide
        foreach (Aspose.Slides.IShape shape in presentation.Slides[0].Shapes)
        {
            // Get effective line formatting (includes inherited values)
            Aspose.Slides.ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();

            // If the shape has a visible line (width > 0), replace its line color
            if (effectiveLine.Width > 0)
            {
                // Set line fill to solid and apply a custom palette entry (Accent2)
                shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.LineFormat.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent2;
            }
        }

        // Save the modified presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
    }
}