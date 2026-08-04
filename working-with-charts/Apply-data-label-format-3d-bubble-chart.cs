// -----------------------------------------------------------------------------
// Example: Apply data label format to 3D bubble chart using C#
//
// Description:
// Demonstrates how to create a 3‑D bubble chart, enable 3‑D bubbles, and apply
// predefined data label formatting (show bubble size, value, and category name)
// using C# and Aspose.Slides for .NET. The example includes creating a presentation,
// adding a chart, populating series data, configuring 3‑D effects, and saving the
// result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D bubble chart, Data label,
// Format, Presentation processing, Office automation
//
// Use Cases:
// - Automate applying data label formats to 3‑D bubble charts.
// - Build C# utilities for PowerPoint chart customization.
// - Generate or modify PPTX files with advanced chart styling in .NET applications.
// - Validate chart rendering and labeling before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a 3‑D bubble chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f);

                // Access the chart's workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Add a series
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

                // Add data points for the bubble series (X, Y, Size)
                series.DataPoints.AddDataPointForBubbleSeries(
                    workbook.GetCell(0, 1, 1, 10),   // X value
                    workbook.GetCell(0, 1, 2, 20),   // Y value
                    workbook.GetCell(0, 1, 3, 30));  // Bubble size

                series.DataPoints.AddDataPointForBubbleSeries(
                    workbook.GetCell(0, 2, 1, 15),
                    workbook.GetCell(0, 2, 2, 25),
                    workbook.GetCell(0, 2, 3, 35));

                series.DataPoints.AddDataPointForBubbleSeries(
                    workbook.GetCell(0, 3, 1, 20),
                    workbook.GetCell(0, 3, 2, 30),
                    workbook.GetCell(0, 3, 3, 40));

                // Enable 3‑D effect for all data points
                for (int i = 0; i < series.DataPoints.Count; i++)
                {
                    series.DataPoints[i].IsBubble3D = true;
                }

                // Apply predefined data label format to all data points
                // Show bubble size value in the data labels
                series.Labels.DefaultDataLabelFormat.ShowBubbleSize = true;
                // Optionally show other label elements
                series.Labels.DefaultDataLabelFormat.ShowValue = true;
                series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

                // Save the presentation
                presentation.Save("3DBubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception)
            {
                // Handle other exceptions (e.g., file I/O, Aspose.Slides errors)
            }
        }
    }
}
