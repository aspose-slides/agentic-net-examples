using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input and output files
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        // Load the presentation
        using (Presentation pres = new Presentation(inputPath))
        {
            // Ensure there is at least one slide
            if (pres.Slides.Count == 0)
            {
                Console.WriteLine("The presentation contains no slides.");
                return;
            }

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Locate the first chart on the slide
            Aspose.Slides.Charts.IChart chart = null;
            foreach (IShape shape in slide.Shapes)
            {
                chart = shape as Aspose.Slides.Charts.IChart;
                if (chart != null)
                {
                    break;
                }
            }

            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                return;
            }

            // Delete a specific series (e.g., the second series) if it exists
            IChartSeriesCollection seriesCollection = chart.ChartData.Series;
            int seriesIndexToRemove = 1; // zero‑based index

            if (seriesIndexToRemove >= 0 && seriesIndexToRemove < seriesCollection.Count)
            {
                IChartSeries seriesToRemove = seriesCollection[seriesIndexToRemove];
                seriesCollection.Remove(seriesToRemove);
                // Alternatively, you could use seriesCollection.RemoveAt(seriesIndexToRemove);
            }
            else
            {
                Console.WriteLine($"Series index {seriesIndexToRemove} is out of range.");
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}