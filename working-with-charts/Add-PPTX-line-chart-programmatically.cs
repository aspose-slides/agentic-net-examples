using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (Presentation presentation = new Presentation())
                {
                    ISlide slide = presentation.Slides[0];
                    IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50, 50, 500, 400);
                    chart.HasTitle = true;
                    chart.ChartTitle.AddTextFrameForOverriding("Sample Line Chart");
                    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
                    chart.ChartTitle.Height = 20;

                    int defaultWorksheetIndex = 0;
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.Line);
                    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), Aspose.Slides.Charts.ChartType.Line);

                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                    series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
                    series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
                    series1.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

                    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 15));
                    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 25));
                    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 35));

                    presentation.Save("LineChartPresentation.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}