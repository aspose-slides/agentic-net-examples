using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartFormulaDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define paths
                string dataDir = Directory.GetCurrentDirectory();
                string inputPath = Path.Combine(dataDir, "Template.pptx");
                string outputPath = Path.Combine(dataDir, "ChartFormulaDemo.pptx");

                // Load existing presentation if it exists, otherwise create a new one
                Presentation presentation;
                if (File.Exists(inputPath))
                {
                    presentation = new Presentation(inputPath);
                }
                else
                {
                    presentation = new Presentation();
                }

                // Add a clustered column chart to the first slide
                ISlide slide = presentation.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 600f, 400f);

                // Access the chart's embedded workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Populate cells with values
                workbook.GetCell(0, "B2", 2);
                workbook.GetCell(0, "B3", 3);

                // Set a formula that sums B2 and B3
                workbook.GetCell(0, "B4").Formula = "B2+B3";

                // Calculate all formulas in the workbook
                workbook.CalculateFormulas();

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine("Required file not found: " + fnfEx.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}