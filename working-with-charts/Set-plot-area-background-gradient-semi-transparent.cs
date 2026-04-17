using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetPlotAreaBackgroundGradient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column (bar) chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Access the plot area of the chart
            IChartPlotArea plotArea = chart.PlotArea;

            // Set the fill type of the plot area to Gradient
            plotArea.Format.Fill.FillType = FillType.Gradient;

            // Configure the gradient stops for a semi‑transparent gradient
            IGradientFormat gradient = plotArea.Format.Fill.GradientFormat;
            gradient.GradientStops.Clear();

            // First stop: semi‑transparent light blue at the start
            gradient.GradientStops.Add(0.0f, Color.FromArgb(128, Color.LightBlue));

            // Second stop: fully transparent white at the end
            gradient.GradientStops.Add(1.0f, Color.FromArgb(0, Color.White));

            // Save the presentation
            try
            {
                presentation.Save("BarChartWithGradient.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // If the format is not supported, write a comment
                // Format not supported: " + ex.Message
            }
        }
    }
}