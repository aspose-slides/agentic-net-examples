// -----------------------------------------------------------------------------
// Example: Configure fixed constant error bars series using C#
//
// Description:
// Demonstrates how to configure fixed constant error bars for a chart series 
// using C# and Aspose.Slides for .NET. The example creates a new presentation, 
// adds a clustered column chart, sets a fixed error bar value for the Y‑axis 
// series, and saves the result as a PPTX file. This pattern can be used to 
// automate chart error‑bar configuration in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Fixed, Constant, 
// Error, Bars, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate the configuration of fixed constant error bars in chart series.
// - Build C# utilities for PowerPoint chart manipulation.
// - Generate or modify PPTX files with custom error‑bar settings in .NET 
//   applications.
// - Validate chart configurations before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Path to the output presentation
            string outputPath = "ErrorBarsChart.pptx";

            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a clustered column chart
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

                    // Ensure there is at least one series
                    if (chart.ChartData.Series.Count > 0)
                    {
                        // Get the first series
                        IChartSeries series = chart.ChartData.Series[0];

                        // Configure fixed constant error bars (Y direction) with a value of 0.2
                        IErrorBarsFormat errorBars = series.ErrorBarsYFormat;
                        errorBars.ValueType = ErrorBarValueType.Fixed;
                        errorBars.Value = 0.2f;
                        errorBars.IsVisible = true;
                    }

                    // Save the presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, Aspose.Slides errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
