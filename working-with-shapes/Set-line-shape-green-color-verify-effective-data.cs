using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Add a line shape to the first slide
                Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)pres.Slides[0].Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line, 50, 50, 300, 0);

                // Set line width
                lineShape.LineFormat.Width = 5;

                // Set line color to green
                lineShape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Green;

                // Retrieve effective line format data
                Aspose.Slides.ILineFormatEffectiveData effectiveLineFormat = lineShape.LineFormat.GetEffective();

                // Output the effective line color
                Console.WriteLine("Effective line color: " + effectiveLineFormat.FillFormat.SolidFillColor);

                // Save the presentation
                pres.Save("LineShapeGreen.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}