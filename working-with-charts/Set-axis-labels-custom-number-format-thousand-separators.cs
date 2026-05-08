using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Configure axis labels to use thousand separator format
            chart.Axes.VerticalAxis.NumberFormat = "#,##0";
            chart.Axes.HorizontalAxis.NumberFormat = "#,##0";

            // Save the presentation
            string outputPath = "ChartAxisNumberFormat.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unexpected errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}