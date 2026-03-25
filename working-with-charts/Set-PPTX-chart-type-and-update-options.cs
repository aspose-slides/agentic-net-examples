using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: program <input.pptx> <output.pptx>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation from the specified file
        using (Presentation presentation = new Presentation(inputPath))
        {
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
                Console.WriteLine("No chart found on the first slide.");
                return;
            }

            // Change the chart type to Pie
            chart.Type = ChartType.Pie;

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}