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
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Ensure there is at least one slide
                if (pres.Slides.Count == 0)
                {
                    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
                }

                // Get or add a chart on the first slide
                Aspose.Slides.Charts.IChart chart = null;
                if (pres.Slides[0].Shapes.Count > 0 && pres.Slides[0].Shapes[0] is Aspose.Slides.Charts.IChart)
                {
                    chart = (Aspose.Slides.Charts.IChart)pres.Slides[0].Shapes[0];
                }
                else
                {
                    chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 400, 300);
                }

                // Access the embedded workbook of the chart
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // List existing worksheets
                Console.WriteLine("Worksheets in chart data workbook:");
                for (int i = 0; i < workbook.Worksheets.Count; i++)
                {
                    Aspose.Slides.Charts.IChartDataWorksheet ws = workbook.Worksheets[i];
                    Console.WriteLine("Index: " + i + " Name: " + ws.Name);
                }

                // Clear the first worksheet (if any) instead of removing it
                if (workbook.Worksheets.Count > 0)
                {
                    workbook.Clear(0);
                    Console.WriteLine("Cleared data of worksheet at index 0.");
                }

                // Save the modified presentation
                string outputPath = "output.pptx";
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}