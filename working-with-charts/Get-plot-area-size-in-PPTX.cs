using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation from the specified file
        Presentation presentation = new Presentation(inputPath);

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Locate the first chart on the slide
        IChart chart = null;
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is IChart)
            {
                chart = (IChart)shape;
                break;
            }
        }

        if (chart == null)
        {
            Console.WriteLine("No chart found in the presentation.");
            presentation.Dispose();
            return;
        }

        // Validate layout to obtain actual plot area dimensions
        chart.ValidateChartLayout();

        float plotWidth = chart.PlotArea.ActualWidth;
        float plotHeight = chart.PlotArea.ActualHeight;

        Console.WriteLine("Plot Area Width: " + plotWidth);
        Console.WriteLine("Plot Area Height: " + plotHeight);

        // Save the presentation (even if unchanged) before exiting
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}