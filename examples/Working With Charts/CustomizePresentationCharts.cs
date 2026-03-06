using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 600f, 400f);

        // Remove the default sample data
        chart.ChartData.Categories.Clear();
        chart.ChartData.Series.Clear();

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        workbook.Clear(0); // Clear the first worksheet

        // Add categories (X‑axis labels)
        workbook.GetCell(0, "A1", "Category 1");
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
        workbook.GetCell(0, "A2", "Category 2");
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));

        // Add a series (Y‑axis data)
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.ClusteredColumn);

        // Populate the series with data points
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B1", 10));
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B2", 20));

        // Enable and set the chart title
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Sample Chart");

        // Save the presentation to a file
        presentation.Save("CustomizedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}