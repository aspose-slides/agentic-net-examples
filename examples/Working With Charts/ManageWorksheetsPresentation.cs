using System;
using System.Collections;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a stacked column 3D chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.StackedColumn3D, 0, 0, 500, 500);

        // Access the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add series and categories
        chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
        chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

        // Set 3D rotation properties
        chart.Rotation3D.RightAngleAxes = true;
        chart.Rotation3D.RotationX = 20;
        chart.Rotation3D.RotationY = 30;
        chart.Rotation3D.DepthPercents = 100;

        // Populate series data points
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));
        series2.ParentSeriesGroup.Overlap = 0;

        // List worksheet names in the embedded workbook
        IEnumerator worksheetEnumerator = workbook.Worksheets.GetEnumerator();
        while (worksheetEnumerator.MoveNext())
        {
            Aspose.Slides.Charts.IChartDataWorksheet ws = (Aspose.Slides.Charts.IChartDataWorksheet)worksheetEnumerator.Current;
            Console.WriteLine("Worksheet: " + ws.Name);
        }

        // Save the presentation
        string outputPath = "ManagedWorksheetsPresentation.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}