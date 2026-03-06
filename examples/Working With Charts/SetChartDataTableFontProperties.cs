using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Enable the data table for the chart
        chart.HasDataTable = true;

        // Set font height for chart text (e.g., title)
        chart.TextFormat.PortionFormat.FontHeight = 14f;

        // Set font height for the data table text
        chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 12f;

        // Save the presentation
        pres.Save("SetChartDataTableFontProperties_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}