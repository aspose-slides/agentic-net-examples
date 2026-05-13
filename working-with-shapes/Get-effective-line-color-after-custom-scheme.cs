using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

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
            using (Presentation pres = new Presentation(inputPath))
            {
                // Apply a custom color scheme by changing the first line style to red
                try
                {
                    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
                }
                catch (Exception ex)
                {
                    // Handle cases where the format does not support this operation
                    Console.WriteLine("Failed to apply custom color scheme: " + ex.Message);
                }

                // Retrieve the first shape on the first slide
                IShape shape = pres.Slides[0].Shapes[0];

                // Get effective line formatting data
                ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();

                // Extract the effective line color (solid fill)
                Color effectiveColor = Color.Empty;
                if (effectiveLine.FillFormat != null && effectiveLine.FillFormat.SolidFillColor != null)
                {
                    effectiveColor = effectiveLine.FillFormat.SolidFillColor;
                }

                Console.WriteLine("Effective line color: " + effectiveColor.ToString());

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL issues)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}