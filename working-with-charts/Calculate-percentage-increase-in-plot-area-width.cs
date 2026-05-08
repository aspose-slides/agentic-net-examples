using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart and cast to Chart to access layout methods
        Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 20f, 100f, 600f, 400f);

        // Define manual layout for the plot area (as fractions of the chart size)
        chart.PlotArea.AsILayoutable.X = 0.2f;
        chart.PlotArea.AsILayoutable.Y = 0.2f;
        chart.PlotArea.AsILayoutable.Width = 0.7f;
        chart.PlotArea.AsILayoutable.Height = 0.7f;

        // Set LayoutTargetType to Outer and get actual width
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Outer;
        chart.ValidateChartLayout();
        float outerWidth = chart.PlotArea.ActualWidth;

        // Set LayoutTargetType to Inner and get actual width
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;
        chart.ValidateChartLayout();
        float innerWidth = chart.PlotArea.ActualWidth;

        // Calculate percentage increase in plot area width
        float percentageIncrease = ((innerWidth - outerWidth) / outerWidth) * 100f;

        // Output the results
        Console.WriteLine("Outer Actual Width: " + outerWidth);
        Console.WriteLine("Inner Actual Width: " + innerWidth);
        Console.WriteLine("Percentage increase: " + percentageIncrease + "%");

        // Save the presentation
        presentation.Save("ChartLayoutTargetTypeDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}