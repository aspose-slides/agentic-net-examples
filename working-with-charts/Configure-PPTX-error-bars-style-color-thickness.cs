using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a line chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 500, 400);

                // Verify that Y‑error bars are allowed for this chart type
                if (ChartTypeCharacterizer.IsErrorBarsYAllowed(chart.Type))
                {
                    // Access the first series in the chart
                    IChartSeries series = chart.ChartData.Series[0];

                    // Obtain the Y‑error bars format object
                    IErrorBarsFormat errFormat = series.ErrorBarsYFormat;

                    // Make error bars visible
                    errFormat.IsVisible = true;

                    // Set the error bar type (both positive and negative)
                    errFormat.Type = ErrorBarType.Both;

                    // Use a fixed length for the error bars
                    errFormat.ValueType = ErrorBarValueType.Fixed;
                    errFormat.Value = 5f; // length in chart units

                    // Configure visual appearance: line thickness and color
                    errFormat.Format.Line.Width = 2f;
                    errFormat.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
                }

                // Save the presentation before exiting
                pres.Save("ErrorBarsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}