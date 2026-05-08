using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetChartBackgroundSolidColor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);

                // Retrieve a theme accent color (e.g., Accent1) from the presentation's master theme
                Aspose.Slides.Theme.IColorScheme colorScheme = pres.MasterTheme.ColorScheme;
                Color themeColor = colorScheme.Accent1.Color;

                // Set the chart's background fill to a solid color matching the theme accent color
                chart.FillFormat.FillType = FillType.Solid;
                chart.FillFormat.SolidFillColor.Color = themeColor;

                // Save the presentation
                try
                {
                    pres.Save("ChartBackgroundSolidColor.pptx", SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other save errors
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}