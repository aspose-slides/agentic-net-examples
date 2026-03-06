using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50, 50, 500, 400);

        // Access the chart's data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear existing categories and add a new one
        chart.ChartData.Categories.Clear();
        chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));

        // Get the first series (created by default)
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Set the value of the first data point
        series.DataPoints[0].Value.AsLiteralDouble = 42.5;

        // Retrieve the value of the first data point
        Aspose.Slides.Charts.IDoubleChartValue doubleValue = series.DataPoints[0].Value;
        double numericValue = doubleValue.ToDouble();

        // Add a textbox shape to display the data point value
        Aspose.Slides.IAutoShape textShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            50, 470, 300, 50);
        textShape.AddTextFrame("Data Point Value: " + numericValue.ToString());

        // Save the presentation
        presentation.Save("DataPointValue.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}