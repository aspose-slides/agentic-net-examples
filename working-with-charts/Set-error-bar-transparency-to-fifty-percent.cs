using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "ErrorBarTransparency.pptx";

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a bubble chart (no sample data)
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble,
                50f, 50f, 500f, 400f, false);

            // Ensure there is at least one series
            if (chart.ChartData.Series.Count > 0)
            {
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

                // Configure X error bars (if supported)
                Aspose.Slides.Charts.IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
                if (errorBarsX != null)
                {
                    errorBarsX.IsVisible = true;
                    errorBarsX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
                    errorBarsX.Value = 5f;
                    errorBarsX.Type = Aspose.Slides.Charts.ErrorBarType.Plus;
                    errorBarsX.HasEndCap = true;

                    // Set 50% transparency via alpha channel (128 out of 255)
                    errorBarsX.Format.Fill.SolidFillColor.Color = System.Drawing.Color.FromArgb(128, System.Drawing.Color.Blue);
                }

                // Configure Y error bars (if supported)
                Aspose.Slides.Charts.IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
                if (errorBarsY != null)
                {
                    errorBarsY.IsVisible = true;
                    errorBarsY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Percentage;
                    errorBarsY.Value = 10f;
                    errorBarsY.Type = Aspose.Slides.Charts.ErrorBarType.Plus;
                    errorBarsY.HasEndCap = true;

                    // Set 50% transparency via alpha channel (128 out of 255)
                    errorBarsY.Format.Fill.SolidFillColor.Color = System.Drawing.Color.FromArgb(128, System.Drawing.Color.Green);
                }
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., file I/O, external resources)
        }
    }
}