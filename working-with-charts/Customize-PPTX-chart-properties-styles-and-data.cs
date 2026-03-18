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
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

                // Configure chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
                chart.ChartTitle.Height = 20;

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Add two series
                chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
                chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

                // Add three categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Populate first series data and set fill color
                Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));
                series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                series1.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Red;

                // Populate second series data and set fill color
                Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));
                series2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                series2.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Green;

                // Customize data labels for the second series
                Aspose.Slides.Charts.IDataLabel label0 = series2.DataPoints[0].Label;
                label0.DataLabelFormat.ShowCategoryName = true;

                Aspose.Slides.Charts.IDataLabel label1 = series2.DataPoints[1].Label;
                label1.DataLabelFormat.ShowSeriesName = true;

                Aspose.Slides.Charts.IDataLabel label2 = series2.DataPoints[2].Label;
                label2.DataLabelFormat.ShowValue = true;
                label2.DataLabelFormat.ShowSeriesName = true;
                label2.DataLabelFormat.Separator = "/";

                // Apply a predefined chart style
                chart.Style = Aspose.Slides.Charts.StyleType.Style9;

                // Save the presentation
                presentation.Save("CustomizedChart_out.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}