using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;
            if (chart != null)
            {
                bool isVisible = IsChartDataTableVisible(chart);
                Console.WriteLine("Data table visible: " + isVisible);
            }
            else
            {
                Console.WriteLine("No chart found on first slide.");
            }

            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URLs)
        }
    }

    static bool IsChartDataTableVisible(Aspose.Slides.Charts.IChart chart)
    {
        return chart.HasDataTable;
    }
}