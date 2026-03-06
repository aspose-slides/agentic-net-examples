using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a Box and Whisker chart
        IChart chart = slide.Shapes.AddChart(ChartType.BoxAndWhisker, 50f, 50f, 500f, 400f);

        // Set chart title
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Box and Whisker Chart");

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Get the chart data workbook
        int defaultWorksheetIndex = 0;
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add a series
        IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
            ChartType.BoxAndWhisker);

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Add data points for each category (values are comma‑separated)
        IChartDataCell cell1 = workbook.GetCell(defaultWorksheetIndex, 1, 1, "1,2,3,4,5");
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(cell1);

        IChartDataCell cell2 = workbook.GetCell(defaultWorksheetIndex, 2, 1, "2,3,4,5,6");
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(cell2);

        IChartDataCell cell3 = workbook.GetCell(defaultWorksheetIndex, 3, 1, "3,4,5,6,7");
        series.DataPoints.AddDataPointForBoxAndWhiskerSeries(cell3);

        // Save the presentation
        presentation.Save("BoxWhiskerChart_out.pptx", SaveFormat.Pptx);
        presentation.Dispose();
    }
}