using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a clustered column chart to the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400, false);

                // Access the vertical (value) axis of the chart
                IAxis verticalAxis = chart.Axes.VerticalAxis;

                // Enable display unit label by setting a display unit (e.g., Millions)
                verticalAxis.DisplayUnit = DisplayUnitType.Millions;

                // Optional: set number format for axis labels
                verticalAxis.NumberFormat = "#,##0";

                // Save the presentation
                presentation.Save("ChartWithDisplayUnit.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}