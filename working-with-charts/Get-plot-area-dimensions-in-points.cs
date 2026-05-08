using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        var presentation = new Aspose.Slides.Presentation();

        var chart = (Aspose.Slides.Charts.Chart)presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 100f, 100f, 500f, 350f);
        chart.ValidateChartLayout();

        var x = chart.PlotArea.ActualX;
        var y = chart.PlotArea.ActualY;
        var w = chart.PlotArea.ActualWidth;
        var h = chart.PlotArea.ActualHeight;

        Console.WriteLine($"PlotArea ActualX: {x}, ActualY: {y}, ActualWidth: {w}, ActualHeight: {h}");

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}