using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Add a rectangle shape
            IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
            // Set fill to use SchemeColor.Background1
            shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Background1;
            // Retrieve effective RGB color
            Color effectiveColor = shape.FillFormat.SolidFillColor.Color;
            Console.WriteLine("Effective RGB of SchemeColor.Background1: R={0}, G={1}, B={2}",
                effectiveColor.R, effectiveColor.G, effectiveColor.B);
            // Save presentation
            try
            {
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}