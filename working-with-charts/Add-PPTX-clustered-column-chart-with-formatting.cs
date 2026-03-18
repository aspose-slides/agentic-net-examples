using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    0f, 0f, 500f, 400f);

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sales Comparison");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
                chart.ChartTitle.Height = 20f;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Add series
                IChartSeries series1 = chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 1, "2019"),
                    Aspose.Slides.Charts.ChartType.ClusteredColumn);
                IChartSeries series2 = chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 2, "2020"),
                    Aspose.Slides.Charts.ChartType.ClusteredColumn);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Q1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Q2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Q3"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 4, 0, "Q4"));

                // Populate series 1 data points
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 150));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 200));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 180));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 220));

                // Populate series 2 data points
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 120));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 190));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 160));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 210));

                // Set fill colors for series
                series1.Format.Fill.FillType = FillType.Solid;
                series1.Format.Fill.SolidFillColor.Color = Color.Red;

                series2.Format.Fill.FillType = FillType.Solid;
                series2.Format.Fill.SolidFillColor.Color = Color.Green;

                // Configure horizontal axis (categories)
                IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                horizontalAxis.Title.AddTextFrameForOverriding("Quarter");
                horizontalAxis.Title.TextFrameForOverriding.Text = "Quarter";

                // Configure vertical axis (values)
                IAxis verticalAxis = chart.Axes.VerticalAxis;
                verticalAxis.Title.AddTextFrameForOverriding("Revenue (in thousands)");
                verticalAxis.Title.TextFrameForOverriding.Text = "Revenue (in thousands)";

                // Save the presentation
                pres.Save("ClusteredColumnChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}