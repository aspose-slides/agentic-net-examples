using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation presentation = new Presentation())
        {
            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Set a custom border color for the chart's plot area
            // Access the plot area's format, then its line, then the fill format to set the color
            chart.PlotArea.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            try
            {
                presentation.Save("ChartPlotAreaBorder.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}