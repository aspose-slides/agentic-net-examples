using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string presentationPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Error: Presentation file not found - " + presentationPath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(presentationPath))
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50, 50, 400, 300);

                // Access the embedded workbook of the chart
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Modify cells in the default worksheet (index 0)
                workbook.GetCell(0, 0, 1, "Series 1");      // Cell B1
                workbook.GetCell(0, 1, 0, "Category 1");   // Cell A2
                workbook.GetCell(0, 1, 1, 10);             // Cell B2
                workbook.GetCell(0, 2, 1, 20);             // Cell B3

                // If a second worksheet exists, clear its data (acts as removal)
                if (workbook.Worksheets.Count > 1)
                {
                    workbook.Clear(1);
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}