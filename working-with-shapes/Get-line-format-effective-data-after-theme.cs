using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Apply a theme override (change first line style fill color to Red) if possible
            if (presentation.MasterTheme != null && presentation.MasterTheme.FormatScheme.LineStyles.Count > 0)
            {
                presentation.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
            }

            // Ensure there is at least one slide and one shape
            if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
            {
                Aspose.Slides.ILineFormatEffectiveData effectiveLine = presentation.Slides[0].Shapes[0].LineFormat.GetEffective();

                Console.WriteLine("Effective Line Style: " + effectiveLine.Style);
                Console.WriteLine("Effective Line Width: " + effectiveLine.Width);
                Console.WriteLine("Effective Line Fill Type: " + effectiveLine.FillFormat.FillType);
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., file access, Aspose.Slides errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}