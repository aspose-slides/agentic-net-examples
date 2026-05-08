using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddBubbleChartDataLabels
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a bubble chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Bubble, 0, 0, 500, 400);

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a new series
                IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

                // Add categories (X axis labels)
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Populate series with bubble data points (X, Y, BubbleSize)
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

                // Enable data labels to show the exact value for each bubble
                series.Labels.DefaultDataLabelFormat.ShowValue = true;

                // Save the presentation
                pres.Save("BubbleChartWithLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}