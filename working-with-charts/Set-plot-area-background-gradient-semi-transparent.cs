using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered bar chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredBar,
                50f, 50f, 600f, 400f);

            // Set the plot area fill to a gradient
            chart.PlotArea.Format.Fill.FillType = Aspose.Slides.FillType.Gradient;

            // Configure gradient shape and direction
            chart.PlotArea.Format.Fill.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
            chart.PlotArea.Format.Fill.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;

            // Add gradient stops with semi‑transparent colors
            // First stop: semi‑transparent blue at position 0%
            chart.PlotArea.Format.Fill.GradientFormat.GradientStops.Add(
                0f,
                Color.FromArgb(128, 0, 0, 255)); // 50% opacity

            // Second stop: semi‑transparent green at position 100%
            chart.PlotArea.Format.Fill.GradientFormat.GradientStops.Add(
                1f,
                Color.FromArgb(128, 0, 255, 0)); // 50% opacity

            // Save the presentation
            try
            {
                presentation.Save("BarChartPlotAreaGradient.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other possible exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}