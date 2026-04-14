using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetErrorBarFillToSeriesColor
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Assume the first slide contains the chart
                    ISlide slide = pres.Slides[0];

                    // Find the first chart shape on the slide
                    IChart chart = null;
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IChart)
                        {
                            chart = (IChart)shape;
                            break;
                        }
                    }

                    if (chart == null)
                    {
                        Console.WriteLine("No chart found on the first slide.");
                        return;
                    }

                    // Work with the first series of the chart
                    IChartSeries series = chart.ChartData.Series[0];

                    // Get the series line color
                    Color seriesLineColor = series.Format.Line.FillFormat.SolidFillColor.Color;

                    // Access the Y-direction error bars (commonly used for line charts)
                    IErrorBarsFormat errorBars = series.ErrorBarsYFormat;
                    if (errorBars != null)
                    {
                        // Ensure error bars are visible
                        errorBars.IsVisible = true;

                        // Set error bar fill to solid and match the series line color
                        errorBars.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                        errorBars.Format.Fill.SolidFillColor.Color = seriesLineColor;
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}