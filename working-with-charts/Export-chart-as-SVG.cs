using System;
using System.IO;
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
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Line, 50, 50, 450, 300);

        // Enable data table and set number format for values
        chart.HasDataTable = true;
        chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

        // Export the chart as an SVG file
        string svgFilePath = "chart.svg";
        try
        {
            using (FileStream svgStream = File.Create(svgFilePath))
            {
                chart.WriteAsSvg(svgStream);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}