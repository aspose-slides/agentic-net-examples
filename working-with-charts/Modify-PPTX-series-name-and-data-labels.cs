using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string dataDir = "Data";
            string inputPath = System.IO.Path.Combine(dataDir, "input.pptx");
            string outputPath = System.IO.Path.Combine(dataDir, "output.pptx");

            // Load the existing presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Assume the first shape on the slide is a chart
            Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)slide.Shapes[0];

            // Modify the name of the first series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
            series.Name.AsLiteralString = "Updated Series";

            // Configure data label to show the series name (and optionally the value)
            series.Labels.DefaultDataLabelFormat.ShowSeriesName = true;
            series.Labels.DefaultDataLabelFormat.ShowValue = true;

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}