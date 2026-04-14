using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a clustered column chart to the first slide
        Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100f, 100f, 500f, 350f);

        // Calculate actual layout values for the chart
        chart.ValidateChartLayout();

        // Retrieve actual width and height of the chart's plot area
        float actualWidth = chart.PlotArea.ActualWidth;
        float actualHeight = chart.PlotArea.ActualHeight;

        // Ensure the actual dimensions are greater than zero before any manual adjustments
        if (actualWidth > 0 && actualHeight > 0)
        {
            // Manual layout adjustments can be performed here
            // (e.g., modifying plot area properties if they were writable)
        }
        else
        {
            Console.WriteLine("Chart actual dimensions are not valid.");
        }

        // Save the presentation
        try
        {
            pres.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Clean up resources
        pres.Dispose();
    }
}