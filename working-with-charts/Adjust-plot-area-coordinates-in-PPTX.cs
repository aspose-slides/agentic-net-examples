using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartPlotAreaAdjustment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.ClusteredColumn, 50f, 50f, 450f, 300f);

            // Adjust the plot area position and size (as fractions of the chart size)
            chart.PlotArea.AsILayoutable.X = 0.1f;      // 10% from the left
            chart.PlotArea.AsILayoutable.Y = 0.1f;      // 10% from the top
            chart.PlotArea.AsILayoutable.Width = 0.8f;  // 80% width
            chart.PlotArea.AsILayoutable.Height = 0.8f; // 80% height

            // Define how the plot area layout should be calculated
            chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

            // Save the presentation
            string outputPath = "AdjustedChart.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}