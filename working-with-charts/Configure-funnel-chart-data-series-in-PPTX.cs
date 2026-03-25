using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a funnel chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Funnel, 50f, 50f, 500f, 400f);

            // Remove default categories and series
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Get the chart data workbook and clear its default sheet
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            workbook.Clear(0);

            // Add categories
            Aspose.Slides.Charts.IChartDataCell cellA1 = workbook.GetCell(0, "A1", "Stage 1");
            chart.ChartData.Categories.Add(cellA1);
            Aspose.Slides.Charts.IChartDataCell cellA2 = workbook.GetCell(0, "A2", "Stage 2");
            chart.ChartData.Categories.Add(cellA2);
            Aspose.Slides.Charts.IChartDataCell cellA3 = workbook.GetCell(0, "A3", "Stage 3");
            chart.ChartData.Categories.Add(cellA3);
            Aspose.Slides.Charts.IChartDataCell cellA4 = workbook.GetCell(0, "A4", "Stage 4");
            chart.ChartData.Categories.Add(cellA4);
            Aspose.Slides.Charts.IChartDataCell cellA5 = workbook.GetCell(0, "A5", "Stage 5");
            chart.ChartData.Categories.Add(cellA5);
            Aspose.Slides.Charts.IChartDataCell cellA6 = workbook.GetCell(0, "A6", "Stage 6");
            chart.ChartData.Categories.Add(cellA6);

            // Add a series for the funnel chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Funnel);

            // Add data points to the series
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 100));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 80));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 60));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 40));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 20));
            series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 10));

            // Save the presentation
            presentation.Save("FunnelChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine("File not found: " + ex.FileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}