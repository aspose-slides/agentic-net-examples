using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartParentCoordinates
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Presentation and chart objects
            Presentation presentation;
            IChart chart;

            // Load existing presentation if it exists, otherwise create a new one and add a chart
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
                // Assume the first shape on the first slide is a chart
                chart = (IChart)presentation.Slides[0].Shapes[0];
            }
            else
            {
                presentation = new Presentation();
                chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100f, 100f, 500f, 350f);
            }

            // Validate layout to get actual values
            chart.ValidateChartLayout();

            // Get actual plot area coordinates and size
            double plotX = chart.PlotArea.ActualX;
            double plotY = chart.PlotArea.ActualY;
            double plotWidth = chart.PlotArea.ActualWidth;
            double plotHeight = chart.PlotArea.ActualHeight;

            // Get chart position on the slide
            double chartX = chart.X;
            double chartY = chart.Y;

            // Calculate absolute coordinates of the plot area (parent element) on the slide
            double absolutePlotX = chartX + plotX;
            double absolutePlotY = chartY + plotY;

            // Output the results
            Console.WriteLine("Chart Position on Slide: X = {0}, Y = {1}", chartX, chartY);
            Console.WriteLine("Plot Area Actual Position relative to Chart: X = {0}, Y = {1}", plotX, plotY);
            Console.WriteLine("Plot Area Size: Width = {0}, Height = {1}", plotWidth, plotHeight);
            Console.WriteLine("Absolute Plot Area Position on Slide: X = {0}, Y = {1}", absolutePlotX, absolutePlotY);

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}