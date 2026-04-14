using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetChartBackgroundGradient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 400f, 300f);

            // Set the chart background fill to a gradient
            chart.FillFormat.FillType = Aspose.Slides.FillType.Gradient;

            // Configure gradient shape and direction
            chart.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
            chart.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;

            // Retrieve theme accent colors to match the presentation's color scheme
            Color accentColor1 = presentation.MasterTheme.ColorScheme.Accent1.Color;
            Color accentColor2 = presentation.MasterTheme.ColorScheme.Accent2.Color;

            // Add gradient stops using the theme colors
            chart.FillFormat.GradientFormat.GradientStops.Add(0f, accentColor1);
            chart.FillFormat.GradientFormat.GradientStops.Add(1f, accentColor2);

            // Save the presentation
            try
            {
                presentation.Save("ChartWithGradientBackground.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}