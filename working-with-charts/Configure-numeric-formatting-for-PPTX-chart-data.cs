using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Line, 50, 50, 450, 300);

        // Enable data table for the chart
        chart.HasDataTable = true;

        // Set numeric format for the first series values
        chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

        // Configure data labels to show values with the same numeric format
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "#,##0.00";

        // Save the presentation
        string outputPath = "NumericFormattingChart.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}