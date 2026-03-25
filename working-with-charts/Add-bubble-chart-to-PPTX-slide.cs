using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "BubbleChart.pptx";
        Presentation presentation = null;
        try
        {
            if (args.Length > 0)
            {
                string inputPath = args[0];
                if (!File.Exists(inputPath))
                {
                    throw new FileNotFoundException("Input file not found.", inputPath);
                }
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
            }

            ISlide slide = presentation.Slides[0];

            // Add a bubble chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f);

            // Set bubble size scale (e.g., 150%)
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

            // Set bubble size representation to Width
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

            // Show bubble size values in data labels
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowBubbleSize = true;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}