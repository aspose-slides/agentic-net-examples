using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input PPTX file (first command‑line argument)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: File not found - " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Assume the first slide contains the chart
                ISlide slide = pres.Slides[0];

                // Find the first chart shape on the slide
                IChart chart = null;
                foreach (IShape shape in slide.Shapes)
                {
                    chart = shape as IChart;
                    if (chart != null)
                    {
                        break;
                    }
                }

                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                }
                else
                {
                    // Access the series collection (read‑only)
                    IChartSeriesCollection seriesCollection = chart.ChartData.Series;

                    // Iterate through the series and display their names
                    for (int i = 0; i < seriesCollection.Count; i++)
                    {
                        IChartSeries series = seriesCollection[i];
                        // IStringChartValue provides the series name; use its Text property if available
                        string seriesName = series.Name != null ? series.Name.ToString() : "Unnamed";
                        Console.WriteLine("Series " + i + ": " + seriesName);
                    }

                    // Example: add a new series with a custom name (optional)
                    // Note: Add method returns the newly created series; we do not modify read‑only properties
                    IChartSeries newSeries = seriesCollection.Add("NewSeries", chart.Type);
                    Console.WriteLine("Added new series: " + newSeries.Name.ToString());
                }

                // Save the modified presentation
                string outputPath = "output.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
        }
    }
}