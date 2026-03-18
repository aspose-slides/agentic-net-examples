using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50, 50, 500, 400);

                // Access the value (Y) axis
                Aspose.Slides.Charts.IAxis valueAxis = chart.Axes.VerticalAxis;

                // Set a custom number format for axis labels
                valueAxis.NumberFormat = "0.00%";

                // Change the font size of the axis labels
                Aspose.Slides.Charts.IChartTextFormat textFormat = valueAxis.TextFormat;
                textFormat.PortionFormat.FontHeight = 14;

                // Rotate the tick labels for better readability
                valueAxis.TickLabelRotationAngle = -45;

                // Save the presentation
                pres.Save("CustomizedAxisLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}