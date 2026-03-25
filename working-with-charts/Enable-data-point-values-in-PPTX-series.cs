using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation from the input file
        Presentation presentation = new Presentation(inputPath);

        // Iterate through all slides in the presentation
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                IChart chart = slide.Shapes[shapeIndex] as IChart;
                if (chart != null)
                {
                    // Enable value display for each series in the chart
                    for (int seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
                    {
                        chart.ChartData.Series[seriesIndex].Labels.DefaultDataLabelFormat.ShowValue = true;
                    }
                }
            }
        }

        // Save the modified presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}