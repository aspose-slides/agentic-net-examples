using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a bubble chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble, 50, 50, 500, 400);

            // Access chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Add primary series
            Aspose.Slides.Charts.IChartSeries primarySeries = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "Primary Series"), Aspose.Slides.Charts.ChartType.Bubble);
            primarySeries.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 1, 1, 10), workbook.GetCell(0, 1, 2, 20), workbook.GetCell(0, 1, 3, 30));
            primarySeries.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 2, 1, 15), workbook.GetCell(0, 2, 2, 25), workbook.GetCell(0, 2, 3, 35));
            primarySeries.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 3, 1, 20), workbook.GetCell(0, 3, 2, 30), workbook.GetCell(0, 3, 3, 40));

            // Add secondary series
            Aspose.Slides.Charts.IChartSeries secondarySeries = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 4, "Secondary Series"), Aspose.Slides.Charts.ChartType.Bubble);
            secondarySeries.PlotOnSecondAxis = true;
            secondarySeries.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 1, 4, 12), workbook.GetCell(0, 1, 5, 22), workbook.GetCell(0, 1, 6, 32));
            secondarySeries.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 2, 4, 18), workbook.GetCell(0, 2, 5, 28), workbook.GetCell(0, 2, 6, 38));
            secondarySeries.DataPoints.AddDataPointForBubbleSeries(
                workbook.GetCell(0, 3, 4, 24), workbook.GetCell(0, 3, 5, 34), workbook.GetCell(0, 3, 6, 44));

            // Set bubble size scale for the secondary series via its parent series group
            secondarySeries.ParentSeriesGroup.BubbleSizeScale = 150; // 150%

            // Access secondary vertical axis (read‑only) and ensure it is visible
            Aspose.Slides.Charts.IAxis secondaryAxis = chart.Axes.SecondaryVerticalAxis;
            secondaryAxis.IsVisible = true;

            // Save the presentation
            try
            {
                pres.Save("BubbleChartWithSecondaryAxis.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Format not supported or other save error
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}