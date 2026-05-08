using System;
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

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Enable the data table for the chart
            chart.HasDataTable = true;

            // Customize the font size of the data table for better readability
            chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 14f;

            // Save the presentation
            presentation.Save("ChartWithDataTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle any unexpected errors (e.g., unsupported format)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}