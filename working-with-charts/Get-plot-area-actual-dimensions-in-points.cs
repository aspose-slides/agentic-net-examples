using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.IO;

class Program
{
    static void Main()
    {
        // Define output path
        string outputPath = "ChartPlotAreaOutput.pptx";

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a chart to the first slide
        Chart chart = (Chart)presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100f, 100f, 500f, 350f);
        chart.ValidateChartLayout();

        // Retrieve actual layout values
        double actualX = chart.PlotArea.ActualX;
        double actualY = chart.PlotArea.ActualY;
        double actualWidth = chart.PlotArea.ActualWidth;
        double actualHeight = chart.PlotArea.ActualHeight;

        // Output the retrieved values
        Console.WriteLine("ActualX: " + actualX);
        Console.WriteLine("ActualY: " + actualY);
        Console.WriteLine("ActualWidth: " + actualWidth);
        Console.WriteLine("ActualHeight: " + actualHeight);

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}