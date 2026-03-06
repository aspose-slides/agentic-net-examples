using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Line, // Chart type
                0,    // X position
                0,    // Y position
                500,  // Width
                400   // Height
            );

            // Clear any default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Ensure the workbook is empty
            workbook.Clear(0);

            // Add categories (X-axis labels)
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Add two series to the chart
            chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
            chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

            // Populate data points for Series 1
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
            series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 10));
            series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 20));
            series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, 30));

            // Populate data points for Series 2
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
            series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 15));
            series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 25));
            series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 35));

            // Save the presentation to a file
            presentation.Save("LineChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}