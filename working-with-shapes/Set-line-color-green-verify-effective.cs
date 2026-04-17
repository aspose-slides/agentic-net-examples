using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a line shape to the first slide
            Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Line, 100, 100, 300, 0);

            // Set the line color to green
            lineShape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Green;

            // Retrieve effective line format data
            Aspose.Slides.ILineFormatEffectiveData effectiveLine = lineShape.LineFormat.GetEffective();

            // Output the effective line color
            Console.WriteLine("Effective line color: " + effectiveLine.FillFormat.SolidFillColor);

            // Save the presentation
            try
            {
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }
}