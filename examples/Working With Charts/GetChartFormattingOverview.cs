using System;
using System.Drawing;

namespace ChartFormattingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var pres = new Aspose.Slides.Presentation())
            {
                var slide = pres.Slides[0];
                var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 500);
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
                chart.ChartTitle.Height = 20;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                int defaultWorksheetIndex = 0;
                var fact = chart.ChartData.ChartDataWorkbook;

                // Add series
                chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
                chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

                // Add categories
                chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                // First series data
                var series0 = chart.ChartData.Series[0];
                series0.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
                series0.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
                series0.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
                series0.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                series0.Format.Fill.SolidFillColor.Color = Color.Red;

                // Second series data
                var series1 = chart.ChartData.Series[1];
                series1.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
                series1.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
                series1.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));
                series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                series1.Format.Fill.SolidFillColor.Color = Color.Green;

                // Data labels
                var lbl0 = series0.DataPoints[0].Label;
                lbl0.DataLabelFormat.ShowCategoryName = true;
                var lbl1 = series0.DataPoints[1].Label;
                lbl1.DataLabelFormat.ShowSeriesName = true;
                var lbl2 = series0.DataPoints[2].Label;
                lbl2.DataLabelFormat.ShowValue = true;
                lbl2.DataLabelFormat.ShowSeriesName = true;
                lbl2.DataLabelFormat.Separator = "/";

                pres.Save("ChartFormattingDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}