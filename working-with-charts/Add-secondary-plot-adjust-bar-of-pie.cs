using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a Pie of Pie chart (secondary plot) to the first slide
                ISlide slide = presentation.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 400, 400);

                // Enable showing values on the primary pie
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

                // Adjust secondary plot size (percentage of primary pie)
                chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 50; // 50%

                // Set split method to ByPercentage and define the split threshold
                chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = PieSplitType.ByPercentage;
                chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 5.0; // Split at 5%

                // Save the presentation
                string outputPath = "BarOfPieChart.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}