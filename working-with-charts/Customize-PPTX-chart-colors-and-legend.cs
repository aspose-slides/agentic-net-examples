using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Presentation pres = new Presentation(inputPath))
        {
            // Access the first shape on the first slide
            IShape shape = pres.Slides[0].Shapes[0];
            IChart chart = shape as IChart;

            if (chart != null)
            {
                // Get the series collection
                IChartSeriesCollection series = chart.ChartData.Series;

                if (series.Count > 0)
                {
                    // Access data labels of the first series
                    IDataLabelCollection labels = series[0].Labels;

                    // Set leader line color to semi‑transparent red
                    labels.LeaderLinesFormat.Line.FillFormat.FillType = FillType.Solid;
                    labels.LeaderLinesFormat.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(128, 255, 0, 0);
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}