using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddRemoveSeriesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a clustered column chart with sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0, 0, 500, 400);

            // Clear the default generated series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook to create cells
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add two series
            chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
            chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

            // Add three categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Populate data for the first series
            Aspose.Slides.Charts.IChartSeries series0 = chart.ChartData.Series[0];
            series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
            series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
            series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

            // Populate data for the second series
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[1];
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));

            // OPTIONAL: Set fill colors for visual distinction
            series0.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series0.Format.Fill.SolidFillColor.Color = Color.Red;
            series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series1.Format.Fill.SolidFillColor.Color = Color.Green;

            // Remove the first series from the chart
            chart.ChartData.Series.Remove(series0);
            // Alternatively, you could use RemoveAt(0) to remove by index:
            // chart.ChartData.Series.RemoveAt(0);

            // Save the presentation
            pres.Save("AddRemoveSeries_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}