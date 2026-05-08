using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetErrorBarLineStyleDashed
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart with sample data
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Ensure the chart has at least one series
                if (chart.ChartData.Series.Count > 0)
                {
                    // Take the first series
                    Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

                    // Enable Y‑direction error bars
                    Aspose.Slides.Charts.IErrorBarsFormat errorBars = series.ErrorBarsYFormat;
                    if (errorBars != null)
                    {
                        errorBars.IsVisible = true;

                        // Set the line dash style of the error bars to dashed
                        errorBars.Format.Line.DashStyle = Aspose.Slides.LineDashStyle.Dash;
                    }
                }

                // Save the presentation
                try
                {
                    presentation.Save("SetErrorBarLineStyleDashed.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception)
                {
                    // Handle other exceptions (e.g., I/O errors)
                }
            }
        }
    }
}