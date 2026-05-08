using System;
using System.IO;
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

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Enable the data table for the chart
            chart.HasDataTable = true;

            // Get the chart's data table
            IDataTable dataTable = chart.ChartDataTable;

            // Apply bold style to the header row (using TextFormat.PortionFormat)
            dataTable.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;

            // Save the presentation
            try
            {
                pres.Save("ChartDataTableBoldHeader.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}