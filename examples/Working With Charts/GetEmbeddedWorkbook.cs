using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
            if (chart != null)
            {
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                foreach (Aspose.Slides.Charts.IChartDataWorksheet worksheet in workbook.Worksheets)
                {
                    Console.WriteLine("Worksheet: " + worksheet.Name);
                }

                Aspose.Slides.Charts.IChartDataCell cell = workbook.GetCell(0, "A1");
                Console.WriteLine("Cell A1 value: " + cell.Value);
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}