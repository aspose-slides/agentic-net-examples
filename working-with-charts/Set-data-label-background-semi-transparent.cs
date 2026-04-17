using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

        // Ensure the chart has at least one series
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        int defaultWorksheetIndex = 0;
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add a single category
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));

        // Add a series and a data point
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 50));

        // Set data label background to a semi‑transparent yellow
        series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color =
            System.Drawing.Color.FromArgb(128, 255, 255, 0); // 50% transparent yellow

        // Save the presentation
        presentation.Save("ChartWithSemiTransparentLabel.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}