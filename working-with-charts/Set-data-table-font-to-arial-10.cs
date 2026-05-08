using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Enable the data table for the chart
        chart.HasDataTable = true;

        // Set the data table font size to 10 points
        chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 10f;

        // Set the data table font family to Arial
        chart.ChartDataTable.TextFormat.PortionFormat.LatinFont = new Aspose.Slides.FontData("Arial");

        // Save the presentation
        try
        {
            pres.Save("SetDataTableFont.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Dispose the presentation
        pres.Dispose();
    }
}