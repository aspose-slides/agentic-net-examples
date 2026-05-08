using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a scatter chart with smooth lines (acts as a spline chart)
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
                50f, 50f, 500f, 400f);

            // Enable curve smoothing for the first series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
            series.Smooth = true;

            // Adjust tension for curve refinement
            // Note: Aspose.Slides does not expose a direct tension property.
            // This comment indicates where such adjustment would be made if available.

            // Save the presentation
            presentation.Save("SplineSmoothChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            // Handle missing input files if any are used
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., unsupported format)
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}