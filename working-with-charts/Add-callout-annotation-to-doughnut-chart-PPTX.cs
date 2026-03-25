using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DoughnutCalloutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Presentation presentation = null;
            try
            {
                if (args.Length > 0)
                {
                    string inputPath = args[0];
                    if (!File.Exists(inputPath))
                    {
                        throw new FileNotFoundException("Input file not found.", inputPath);
                    }
                    presentation = new Presentation(inputPath);
                }
                else
                {
                    presentation = new Presentation();
                }

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a doughnut chart
                IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 50f, 50f, 500f, 400f);

                // Enable callout for data labels (default for all data labels)
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

                // Optionally show values in the callout
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

                // Determine output path
                string outputPath = (args.Length > 1) ? args[1] : "DoughnutCalloutOutput.pptx";

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}