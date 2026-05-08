using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    ISlide slide = pres.Slides[0];
                    IChart chart = null;

                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IChart)
                        {
                            chart = (IChart)shape;
                            break;
                        }
                    }

                    if (chart != null)
                    {
                        // Ensure actual layout values are calculated
                        chart.ValidateChartLayout();

                        IChartPlotArea plotArea = chart.PlotArea;

                        float actualX = plotArea.ActualX;
                        float actualY = plotArea.ActualY;
                        float actualWidth = plotArea.ActualWidth;
                        float actualHeight = plotArea.ActualHeight;

                        Console.WriteLine($"Plot Area Dimensions:");
                        Console.WriteLine($"X: {actualX}");
                        Console.WriteLine($"Y: {actualY}");
                        Console.WriteLine($"Width: {actualWidth}");
                        Console.WriteLine($"Height: {actualHeight}");
                    }
                    else
                    {
                        Console.WriteLine("No chart found on the first slide.");
                    }

                    // Save the presentation before exiting
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}