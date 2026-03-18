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
            // Paths to the input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Iterate through all slides
            foreach (ISlide slide in pres.Slides)
            {
                // Iterate through all shapes on the slide
                foreach (IShape shape in slide.Shapes)
                {
                    // Check if the shape is a chart
                    IChart chart = shape as IChart;
                    if (chart != null)
                    {
                        // Enable percentage display for each series' data labels
                        foreach (IChartSeries series in chart.ChartData.Series)
                        {
                            series.Labels.DefaultDataLabelFormat.ShowPercentage = true;
                        }
                    }
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}