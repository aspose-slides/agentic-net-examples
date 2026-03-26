using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Enable the data table for the chart
            chart.HasDataTable = true;

            // Customize the data table appearance (optional)
            chart.ChartDataTable.HasBorderHorizontal = true;
            chart.ChartDataTable.HasBorderVertical = true;
            chart.ChartDataTable.HasBorderOutline = true;

            // Save the presentation to disk
            pres.Save("ChartWithDataTable.pptx", SaveFormat.Pptx);
        }
    }
}