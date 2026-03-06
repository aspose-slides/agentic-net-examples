using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart
        Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 100f, 100f, 500f, 350f);
        chart.ValidateChartLayout();

        // Get actual position and size of the plot area
        double plotX = chart.PlotArea.ActualX;
        double plotY = chart.PlotArea.ActualY;
        double plotW = chart.PlotArea.ActualWidth;
        double plotH = chart.PlotArea.ActualHeight;

        // Ensure the chart has a title and add text
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Sample Title");

        // Cast to ChartTitle to access actual layout properties
        Aspose.Slides.Charts.ChartTitle chartTitle = (Aspose.Slides.Charts.ChartTitle)chart.ChartTitle;
        double titleX = chartTitle.ActualX;
        double titleY = chartTitle.ActualY;
        double titleW = chartTitle.ActualWidth;
        double titleH = chartTitle.ActualHeight;

        // Get actual position and size of the legend
        Aspose.Slides.Charts.Legend legend = (Aspose.Slides.Charts.Legend)chart.Legend;
        double legendX = legend.ActualX;
        double legendY = legend.ActualY;
        double legendW = legend.ActualWidth;
        double legendH = legend.ActualHeight;

        // Example usage: output values to console
        Console.WriteLine("Plot Area - X: {0}, Y: {1}, Width: {2}, Height: {3}", plotX, plotY, plotW, plotH);
        Console.WriteLine("Chart Title - X: {0}, Y: {1}, Width: {2}, Height: {3}", titleX, titleY, titleW, titleH);
        Console.WriteLine("Legend - X: {0}, Y: {1}, Width: {2}, Height: {3}", legendX, legendY, legendW, legendH);

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}