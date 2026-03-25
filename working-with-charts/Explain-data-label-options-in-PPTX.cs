using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DataLabelDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : string.Empty;
            string outputPath = args.Length > 1 ? args[1] : "DataLabelDemo.pptx";

            Presentation pres = null;

            try
            {
                if (!string.IsNullOrEmpty(inputPath))
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine("Input file not found: " + inputPath);
                        return;
                    }
                    pres = new Presentation(inputPath);
                }
                else
                {
                    pres = new Presentation();
                }

                // Ensure at least one slide exists
                ISlide slide = pres.Slides.Count > 0 ? pres.Slides[0] : pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

                // Add a Pie chart
                IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 500f, 400f);

                // Customize data label: show leader lines, value, category name, separator
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;
                chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
                chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = false;
                chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = ", ";

                // Show percentage and set number format
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "0.00%";

                // Display data labels as callouts
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }
    }
}