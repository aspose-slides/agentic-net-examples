using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = null;
        string outputPath = "ModifiedChart.pptx";

        if (args.Length > 0)
        {
            inputPath = args[0];
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }
        }

        if (args.Length > 1)
        {
            outputPath = args[1];
        }

        try
        {
            Aspose.Slides.Presentation presentation;
            if (inputPath != null)
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

            // Configure font attributes for the chart
            chart.TextFormat.PortionFormat.FontHeight = 14f;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}