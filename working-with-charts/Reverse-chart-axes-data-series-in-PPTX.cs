using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Validate arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: program.exe <input.pptx> <output.pptx>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Presentation pres = new Presentation(inputPath);

        // Get the first chart on the first slide
        IChart chart = pres.Slides[0].Shapes[0] as IChart;
        if (chart != null)
        {
            // Swap data series between axes
            chart.ChartData.SwitchRowColumn();
        }
        else
        {
            Console.WriteLine("No chart found on the first slide.");
        }

        // Save the modified presentation
        pres.Save(outputPath, SaveFormat.Pptx);
    }
}