using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 400, 300);

            // Calculate actual layout values for chart elements
            chart.ValidateChartLayout();

            // Plot area actual coordinates
            Aspose.Slides.Charts.IChartPlotArea plotArea = chart.PlotArea;
            float plotX = plotArea.ActualX;
            float plotY = plotArea.ActualY;
            float plotWidth = plotArea.ActualWidth;
            float plotHeight = plotArea.ActualHeight;

            // Legend actual coordinates
            Aspose.Slides.Charts.ILegend legend = chart.Legend;
            float legendX = legend.ActualX;
            float legendY = legend.ActualY;
            float legendWidth = legend.ActualWidth;
            float legendHeight = legend.ActualHeight;

            // Chart title actual coordinates
            Aspose.Slides.Charts.IChartTitle title = chart.ChartTitle;
            float titleX = title.ActualX;
            float titleY = title.ActualY;
            float titleWidth = title.ActualWidth;
            float titleHeight = title.ActualHeight;

            // Output the absolute coordinates
            Console.WriteLine("Plot Area - X:{0}, Y:{1}, Width:{2}, Height:{3}", plotX, plotY, plotWidth, plotHeight);
            Console.WriteLine("Legend - X:{0}, Y:{1}, Width:{2}, Height:{3}", legendX, legendY, legendWidth, legendHeight);
            Console.WriteLine("Title - X:{0}, Y:{1}, Width:{2}, Height:{3}", titleX, titleY, titleWidth, titleHeight);

            // Save the presentation
            presentation.Save("ChartLayoutCoordinates.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}