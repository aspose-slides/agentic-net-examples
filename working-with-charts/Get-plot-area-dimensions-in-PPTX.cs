using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load existing presentation if it exists; otherwise create a new one
        Aspose.Slides.Presentation presentation;
        if (File.Exists(inputPath))
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        else
        {
            presentation = new Aspose.Slides.Presentation();
        }

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 100f, 100f, 500f, 350f);

        // Validate layout to obtain actual plot area dimensions
        chart.ValidateChartLayout();

        // Retrieve actual plot area coordinates and size
        double plotX = chart.PlotArea.ActualX;
        double plotY = chart.PlotArea.ActualY;
        double plotWidth = chart.PlotArea.ActualWidth;
        double plotHeight = chart.PlotArea.ActualHeight;

        // Display the retrieved values
        Console.WriteLine("Plot Area X: " + plotX);
        Console.WriteLine("Plot Area Y: " + plotY);
        Console.WriteLine("Plot Area Width: " + plotWidth);
        Console.WriteLine("Plot Area Height: " + plotHeight);

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}