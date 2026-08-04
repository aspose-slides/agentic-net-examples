// -----------------------------------------------------------------------------
// Example: Add bubble data labels show exact value using C#
//
// Description:
// Demonstrates how to add bubble data labels that display both the data value 
// and bubble size using C# and Aspose.Slides for .NET. The example creates a 
// presentation, inserts a bubble chart, populates it with data points, enables 
// value and bubble size labels, and saves the result as a PPTX file. This 
// pattern can be used to automate PowerPoint chart labeling tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bubble Chart, Data Labels, 
// Show Value, Show Bubble Size, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding bubble chart data labels that show exact values and sizes.
// - Build C# utilities for PowerPoint chart customization.
// - Generate or modify PPTX files with detailed bubble chart annotations.
// - Validate chart labeling in presentation workflows before publishing.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace BubbleChartDataLabelExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a bubble chart to the first slide
                IChart bubbleChart = presentation.Slides[0].Shapes.AddChart(
                    ChartType.Bubble, 50f, 50f, 600f, 400f);

                // Access the first series of the chart
                IChartSeries series = bubbleChart.ChartData.Series[0];

                // Add data points (X, Y, BubbleSize)
                series.DataPoints.AddDataPointForBubbleSeries(1.0, 2.0, 3.0);
                series.DataPoints.AddDataPointForBubbleSeries(2.0, 3.5, 4.5);
                series.DataPoints.AddDataPointForBubbleSeries(3.0, 1.5, 2.5);
                series.DataPoints.AddDataPointForBubbleSeries(4.0, 4.0, 5.0);

                // Show the value and bubble size on each data label
                series.Labels.DefaultDataLabelFormat.ShowValue = true;
                series.Labels.DefaultDataLabelFormat.ShowBubbleSize = true;

                // Save the presentation
                string outputPath = "BubbleChartWithDataLabels.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
