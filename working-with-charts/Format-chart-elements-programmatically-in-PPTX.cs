using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartCustomizationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "CustomizedChart.pptx";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a Pie chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 400f, 400f);

            // Customize data label appearance
            // Show leader lines for the default data label format
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

            // Show value for the first data label
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;

            // Show category name for the first data label
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = true;

            // Set a custom separator for the first data label
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = " - ";

            // Optionally set number format for all data labels in the series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation object
            pres.Dispose();

            Console.WriteLine("Presentation saved to: " + Path.GetFullPath(outputPath));
        }
    }
}