using System;
using System.IO;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DefineCustomDataRange
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Open the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Add a new chart to the first slide
                Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Define a custom data range for the chart
                string customRange = "Sheet1!$A$1:$C$4";
                chart.ChartData.SetRange(customRange);

                // Save the modified presentation
                string outputPath = "output.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}