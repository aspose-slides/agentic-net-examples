using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Apply a custom color to the first line style in the master theme
                    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Blue;

                    // Retrieve the first shape on the first slide
                    IShape shape = pres.Slides[0].Shapes[0];

                    // Get effective line formatting data
                    ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();

                    // The solid fill color of the effective line format is a System.Drawing.Color
                    Color effectiveColor = effectiveLine.FillFormat.SolidFillColor;

                    Console.WriteLine("Effective line color: " + effectiveColor);
                    
                    // Save the modified presentation
                    string outputPath = "output.pptx";
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // Handle unsupported format or other specific exceptions as needed
            }
        }
    }
}