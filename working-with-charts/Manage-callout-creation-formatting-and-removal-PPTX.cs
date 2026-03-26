using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartCalloutDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            if (File.Exists(inputPath))
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    ManageChartCallouts(presentation);
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            else
            {
                using (Presentation presentation = new Presentation())
                {
                    // Ensure there is at least one slide
                    ISlide slide = presentation.Slides[0];
                    // Add a new chart to the slide
                    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 400f, 300f);
                    // Enable callout for data labels and show values
                    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
                    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
                    // Later, remove the callout by disabling it
                    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = false;
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
        }

        // Helper method to demonstrate callout management on an existing presentation
        private static void ManageChartCallouts(Presentation presentation)
        {
            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a new chart if none exists
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 400f, 300f);

            // Enable callout for data labels and show values
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Example of removing the callout (disable it)
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = false;
        }
    }
}