using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Set the data label separator to a newline character for multi‑line labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Separator = "\n";

        // Save the presentation (handle unsupported format exception)
        try
        {
            presentation.Save("ChartWithNewlineSeparator.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            // Format not supported or other saving issue
            // Console.WriteLine(ex.Message);
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}