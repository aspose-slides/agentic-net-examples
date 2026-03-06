using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a doughnut chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Doughnut, 50, 50, 400, 400);

        // Set the doughnut hole size via the parent series group (e.g., 50%)
        chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories
        chart.ChartData.Categories.Add(wb.GetCell(0, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(wb.GetCell(0, 2, 0, "Category 2"));

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(wb.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add data points for the doughnut series
        series.DataPoints.AddDataPointForDoughnutSeries(wb.GetCell(0, 1, 1, 30));
        series.DataPoints.AddDataPointForDoughnutSeries(wb.GetCell(0, 2, 1, 70));

        // Customize segment colors
        series.DataPoints[0].Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        series.DataPoints[0].Format.Fill.SolidFillColor.Color = System.Drawing.Color.Red;

        series.DataPoints[1].Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        series.DataPoints[1].Format.Fill.SolidFillColor.Color = System.Drawing.Color.Blue;

        // Save the presentation
        pres.Save("CustomizeDoughnutSegments.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}