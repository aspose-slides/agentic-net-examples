using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Prepare chart data
                int defaultWorksheetIndex = 0;
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

                // Configure data point labels
                IChartDataPoint point0 = series.DataPoints[0];
                point0.Label.DataLabelFormat.ShowCategoryName = true;
                point0.Label.DataLabelFormat.ShowValue = false;
                series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
                point0.Format.Fill.FillType = FillType.Solid;
                point0.Format.Fill.SolidFillColor.Color = Color.Blue;

                IChartDataPoint point1 = series.DataPoints[1];
                point1.Label.DataLabelFormat.ShowSeriesName = true;
                point1.Label.DataLabelFormat.ShowValue = true;
                point1.Label.DataLabelFormat.Separator = " - ";

                IChartDataPoint point2 = series.DataPoints[2];
                point2.Label.Hide();

                // Save the presentation
                pres.Save("DataPointLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}