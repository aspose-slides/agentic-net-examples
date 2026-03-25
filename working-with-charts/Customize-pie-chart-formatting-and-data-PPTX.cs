using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = args.Length > 0 ? args[0] : "input.pptx";
        string outputPath = args.Length > 1 ? args[1] : "output.pptx";

        Presentation pres = null;

        try
        {
            // Load existing presentation if it exists, otherwise create a new one
            if (File.Exists(inputPath))
            {
                pres = new Presentation(inputPath);
            }
            else
            {
                // Input file not found – create a fresh presentation
                pres = new Presentation();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Access the first slide (a new presentation always has one)
        ISlide slide = pres.Slides[0];

        // Add a pie chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 500f, 400f);

        // Customize data labels: show leader lines, value, category name, and set a separator
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = " - ";

        // Customize a specific slice (explode the second data point)
        IChartSeries series = chart.ChartData.Series[0];
        series.DataPoints[1].Explosion = 20; // Explode by 20%

        // Save the modified presentation
        pres.Save(outputPath, SaveFormat.Pptx);
    }
}