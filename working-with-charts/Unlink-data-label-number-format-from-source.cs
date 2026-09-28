// -----------------------------------------------------------------------------
// Example: Unlink Data Label Number Format from Source in Pie Chart
//
// Description:
// This console application creates a PowerPoint presentation, adds a pie chart,
// unlinks the data label number format from its source data, applies a custom
// number format, and saves the file as PPTX. It demonstrates using Aspose.Slides
// for .NET to control chart data label formatting.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, chart data label, number format, unlink
//
// Use Cases:
// - Generate automated reports with customized chart label formats.
// - Prepare presentation slides where data label formatting must differ from source.
// - Create templates that enforce specific number formatting on charts.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Output file path
                string outputPath = "UnlinkedDataLabelNumberFormat.pptx";

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a pie chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Pie,
                    50f, 50f, 500f, 400f);

                // Access the chart's workbook to add custom data
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear any default series
                chart.ChartData.Series.Clear();

                // Add a new series with sample data
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, 30),
                    chart.Type);

                // Add data points to the series
                series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 0, 2, 20));
                series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 0, 3, 50));

                // Unlink the number format from the source and apply a custom format
                series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
                series.Labels.DefaultDataLabelFormat.NumberFormat = "0.00%";
                series.Labels.DefaultDataLabelFormat.ShowValue = true;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
