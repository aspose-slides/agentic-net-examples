using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CustomizeChartPlotArea
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 450f, 300f);

            // Position the horizontal axis between categories
            chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

            // Adjust plot area dimensions (as fractions of the chart size)
            chart.PlotArea.AsILayoutable.X = 0.1f;      // left offset
            chart.PlotArea.AsILayoutable.Y = 0.1f;      // top offset
            chart.PlotArea.AsILayoutable.Width = 0.8f;  // width fraction
            chart.PlotArea.AsILayoutable.Height = 0.8f; // height fraction

            // Define layout target type (inner excludes axis labels)
            chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;

            // Set background fill of the plot area to a solid light gray color
            chart.PlotArea.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightGray;

            // Save the presentation
            presentation.Save("CustomizedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}