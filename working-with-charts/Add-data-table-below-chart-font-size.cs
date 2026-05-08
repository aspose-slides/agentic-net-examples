using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a clustered column chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Set the chart's overall font size for readability
        chart.TextFormat.PortionFormat.FontHeight = 14f;

        // Enable the data table below the chart
        chart.HasDataTable = true;

        // Customize the data table's font size
        chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 12f;

        // Save the presentation
        presentation.Save("ChartWithDataTable.pptx", SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}