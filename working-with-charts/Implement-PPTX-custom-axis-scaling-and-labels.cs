using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Q1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Q2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Q3"));

                // Add a series with data points
                Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 70));

                // Configure vertical axis
                Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;
                verticalAxis.HasTitle = true;
                verticalAxis.Title.AddTextFrameForOverriding("Revenue (USD)");
                verticalAxis.MinValue = 0;
                verticalAxis.MaxValue = 100;
                verticalAxis.MajorUnit = 20;
                verticalAxis.DisplayUnit = Aspose.Slides.Charts.DisplayUnitType.Thousands;
                verticalAxis.NumberFormat = "#,##0";

                // Configure horizontal axis
                Aspose.Slides.Charts.IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                horizontalAxis.HasTitle = true;
                horizontalAxis.Title.AddTextFrameForOverriding("Quarter");
                horizontalAxis.TickLabelRotationAngle = -45;
                horizontalAxis.NumberFormat = "0%";

                // Save the presentation
                presentation.Save("CustomAxisChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}