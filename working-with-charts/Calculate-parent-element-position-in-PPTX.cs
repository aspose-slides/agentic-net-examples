using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load existing presentation if it exists, otherwise create a new one
        Presentation pres;
        if (File.Exists(inputPath))
        {
            pres = new Presentation(inputPath);
        }
        else
        {
            pres = new Presentation();
            // Add a sample chart to the new presentation
            ISlide slide = pres.Slides[0];
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sample Chart");
        }

        // Get the first slide
        ISlide firstSlide = pres.Slides[0];

        // Find the first chart on the slide
        IChart chartShape = null;
        foreach (IShape shape in firstSlide.Shapes)
        {
            if (shape is IChart)
            {
                chartShape = (IChart)shape;
                break;
            }
        }

        if (chartShape != null)
        {
            // Calculate actual layout values for the chart
            chartShape.ValidateChartLayout();

            // Access the plot area via the IChartPlotArea interface
            IChartPlotArea plotArea = chartShape.PlotArea;

            // Output actual position and size of the plot area
            Console.WriteLine("Plot Area Actual Position:");
            Console.WriteLine($"X: {plotArea.ActualX}, Y: {plotArea.ActualY}");
            Console.WriteLine($"Width: {plotArea.ActualWidth}, Height: {plotArea.ActualHeight}");

            // If the chart has a title, output its actual position as well
            if (chartShape.HasTitle)
            {
                ChartTitle title = chartShape.ChartTitle as ChartTitle;
                if (title != null)
                {
                    Console.WriteLine("Chart Title Actual Position:");
                    Console.WriteLine($"X: {title.ActualX}, Y: {title.ActualY}");
                    Console.WriteLine($"Width: {title.ActualWidth}, Height: {title.ActualHeight}");
                }
            }
        }

        // Save the presentation
        pres.Save(outputPath, SaveFormat.Pptx);
        pres.Dispose();
    }
}