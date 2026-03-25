using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace DoughnutHoleSizeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Find the first doughnut chart on the slide
                Aspose.Slides.Charts.IChart doughnutChart = null;
                for (int i = 0; i < slide.Shapes.Count; i++)
                {
                    if (slide.Shapes[i] is Aspose.Slides.Charts.IChart)
                    {
                        Aspose.Slides.Charts.IChart tempChart = (Aspose.Slides.Charts.IChart)slide.Shapes[i];
                        if (tempChart.Type == Aspose.Slides.Charts.ChartType.Doughnut)
                        {
                            doughnutChart = tempChart;
                            break;
                        }
                    }
                }

                if (doughnutChart == null)
                {
                    Console.WriteLine("Error: No doughnut chart found on the first slide.");
                    presentation.Dispose();
                    return;
                }

                // Set the inner radius (hole size) of the doughnut chart (value between 10 and 90)
                byte holeSize = 50; // 50 percent
                doughnutChart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = holeSize;

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Doughnut hole size set successfully. Saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}