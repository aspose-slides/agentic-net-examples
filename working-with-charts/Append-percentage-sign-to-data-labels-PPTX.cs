using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AppendPercentageSignToDataLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output PPTX file path
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Assume the first shape on the slide is a chart
                IChart chart = slide.Shapes[0] as IChart;
                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                // Iterate through all series in the chart
                for (int i = 0; i < chart.ChartData.Series.Count; i++)
                {
                    IChartSeries series = chart.ChartData.Series[i];

                    // Enable showing the value for data labels
                    series.Labels.DefaultDataLabelFormat.ShowValue = true;

                    // Ensure the number format is not linked to the source data
                    series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;

                    // Set the number format to display a percentage sign
                    series.Labels.DefaultDataLabelFormat.NumberFormat = "0%";
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}