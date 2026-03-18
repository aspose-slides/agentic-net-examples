using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Add a scatter chart
                Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ScatterWithMarkers,
                    0f, 0f, 500f, 400f);

                // Enable and set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Custom Scatter Chart");

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                int defaultWorksheetIndex = 0;
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Add two series
                Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                    chart.Type);
                Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"),
                    chart.Type);

                // Add categories (optional for scatter)
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                // Populate series1 data points
                series1.DataPoints.AddDataPointForScatterSeries(
                    workbook.GetCell(defaultWorksheetIndex, 1, 1, 1.0),
                    workbook.GetCell(defaultWorksheetIndex, 1, 2, 4.0));
                series1.DataPoints.AddDataPointForScatterSeries(
                    workbook.GetCell(defaultWorksheetIndex, 2, 1, 2.0),
                    workbook.GetCell(defaultWorksheetIndex, 2, 2, 5.0));
                series1.DataPoints.AddDataPointForScatterSeries(
                    workbook.GetCell(defaultWorksheetIndex, 3, 1, 3.0),
                    workbook.GetCell(defaultWorksheetIndex, 3, 2, 6.0));

                // Set fill color for series1
                series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                series1.Format.Fill.SolidFillColor.Color = Color.Red;

                // Populate series2 data points
                series2.DataPoints.AddDataPointForScatterSeries(
                    workbook.GetCell(defaultWorksheetIndex, 1, 1, 1.5),
                    workbook.GetCell(defaultWorksheetIndex, 1, 3, 3.5));
                series2.DataPoints.AddDataPointForScatterSeries(
                    workbook.GetCell(defaultWorksheetIndex, 2, 1, 2.5),
                    workbook.GetCell(defaultWorksheetIndex, 2, 3, 4.5));
                series2.DataPoints.AddDataPointForScatterSeries(
                    workbook.GetCell(defaultWorksheetIndex, 3, 1, 3.5),
                    workbook.GetCell(defaultWorksheetIndex, 3, 3, 5.5));

                // Set fill color for series2
                series2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                series2.Format.Fill.SolidFillColor.Color = Color.Green;

                // Modify axes: hide vertical axis
                Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;
                verticalAxis.IsVisible = false;

                // Save the presentation
                pres.Save("CustomChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}