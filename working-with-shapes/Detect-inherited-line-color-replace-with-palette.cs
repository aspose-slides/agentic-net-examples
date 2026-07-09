using System;
using System.IO;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or loading errors
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Iterate through all slides and shapes
        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
        {
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                // Get effective line formatting (includes inherited values)
                Aspose.Slides.ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();

                // If the shape has line formatting, replace its line color with a custom palette entry (Accent2)
                if (effectiveLine != null && effectiveLine.FillFormat != null)
                {
                    shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    shape.LineFormat.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent2;
                }
            }
        }

        // Save the modified presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle save errors (e.g., unsupported format)
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
    }
}