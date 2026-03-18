using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ComputeChartElementPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 400f, 300f);

                // Calculate actual layout values
                chart.ValidateChartLayout();

                // Retrieve actual positions of chart title
                float titleActualX = chart.ChartTitle.ActualX;
                float titleActualY = chart.ChartTitle.ActualY;
                float titleActualWidth = chart.ChartTitle.ActualWidth;
                float titleActualHeight = chart.ChartTitle.ActualHeight;

                // Retrieve actual positions of plot area
                float plotActualX = chart.PlotArea.ActualX;
                float plotActualY = chart.PlotArea.ActualY;
                float plotActualWidth = chart.PlotArea.ActualWidth;
                float plotActualHeight = chart.PlotArea.ActualHeight;

                // Output the actual positions
                Console.WriteLine("Chart Title - X: {0}, Y: {1}, Width: {2}, Height: {3}",
                    titleActualX, titleActualY, titleActualWidth, titleActualHeight);
                Console.WriteLine("Plot Area   - X: {0}, Y: {1}, Width: {2}, Height: {3}",
                    plotActualX, plotActualY, plotActualWidth, plotActualHeight);

                // Save the presentation
                pres.Save("ChartPosition.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}