using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "CustomDashLine.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a line shape
            Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

            // Set line style and width
            line.LineFormat.Style = Aspose.Slides.LineStyle.ThickBetweenThin;
            line.LineFormat.Width = 10;

            // Use custom dash pattern
            line.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Custom;
            line.LineFormat.CustomDashPattern = new float[] { 5, 2, 3, 2 };

            // Save the presentation
            try
            {
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Format not supported
            }
        }
    }
}