using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50, 50, 450, 300);

        // Enable data table for the chart
        chart.HasDataTable = true;

        // Set numeric format for series values to display two decimal places
        chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

        // Save the presentation to a PPTX file
        string outputPath = "PrecisionChart.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}