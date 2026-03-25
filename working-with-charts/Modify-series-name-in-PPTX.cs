using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ModifySeriesName
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output PPTX file path
            string outputPath = "output_modified_series_name.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Find the first chart on the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.Charts.IChart chart = null;
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.Charts.IChart)
                    {
                        chart = (Aspose.Slides.Charts.IChart)shape;
                        break;
                    }
                }

                if (chart == null)
                {
                    Console.WriteLine("Error: No chart found in the presentation.");
                    return;
                }

                // Modify the name of the first series
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
                series.Name.AsLiteralString = "Updated Series Name";

                // Ensure data labels display the series name
                series.Labels.DefaultDataLabelFormat.ShowSeriesName = true;

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
        }
    }
}