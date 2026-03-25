using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HideChartElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.ISlide slide = pres.Slides[0];
                Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

                if (chart != null)
                {
                    // Hide various data label information for the first series
                    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLegendKey = false;
                    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = false;
                    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowCategoryName = false;
                    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowSeriesName = false;
                    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = false;
                    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowBubbleSize = false;

                    // Optionally hide the entire chart
                    chart.Hidden = true;
                }

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}