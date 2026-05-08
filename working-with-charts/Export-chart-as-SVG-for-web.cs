using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line chart with sample data
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Line, 50, 50, 450, 300);
            chart.HasDataTable = true;
            chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

            // Export the slide (containing the chart) as an SVG file
            using (FileStream svgStream = File.Create("chart.svg"))
            {
                slide.WriteAsSvg(svgStream);
            }

            // Save the presentation as PPTX
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., I/O errors)
        }
    }
}