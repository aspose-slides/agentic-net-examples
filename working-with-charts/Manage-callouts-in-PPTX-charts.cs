using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        using (Presentation presentation = new Presentation(inputPath))
        {
            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Create a pie chart
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

            // Enable callout for data labels
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

            // Save the presentation with the chart and callout
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Remove the chart (demonstrating removal)
            slide.Shapes.Remove(chart);

            // Save the presentation after removal
            string removedOutputPath = "output_removed.pptx";
            presentation.Save(removedOutputPath, SaveFormat.Pptx);
        }
    }
}