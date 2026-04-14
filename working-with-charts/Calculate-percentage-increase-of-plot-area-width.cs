using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartPlotAreaWidthIncrease
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a chart with manual layout
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20f, 100f, 600f, 400f);

            // Define manual layout for the plot area (fraction of chart size)
            chart.PlotArea.AsILayoutable.X = 0.2f;
            chart.PlotArea.AsILayoutable.Y = 0.2f;
            chart.PlotArea.AsILayoutable.Width = 0.7f;
            chart.PlotArea.AsILayoutable.Height = 0.7f;

            // First layout target: Outer (including axis and labels)
            chart.PlotArea.LayoutTargetType = LayoutTargetType.Outer;
            chart.ValidateChartLayout();
            float outerWidth = chart.PlotArea.ActualWidth;

            // Second layout target: Inner (excluding axis and labels)
            chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
            chart.ValidateChartLayout();
            float innerWidth = chart.PlotArea.ActualWidth;

            // Calculate percentage increase from Outer to Inner
            float increase = ((innerWidth - outerWidth) / outerWidth) * 100f;

            // Output the result
            Console.WriteLine("Outer Plot Area Width: " + outerWidth);
            Console.WriteLine("Inner Plot Area Width: " + innerWidth);
            Console.WriteLine("Percentage increase: " + increase + "%");

            // Save the presentation
            presentation.Save("ChartPlotAreaWidthIncrease.pptx", SaveFormat.Pptx);
        }
    }
}