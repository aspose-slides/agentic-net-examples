using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AttachExternalWorkbook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the source presentation and external Excel workbook
            string presentationPath = "template.pptx";
            string workbookPath = "data.xlsx";

            // Verify that the input files exist
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            if (!File.Exists(workbookPath))
            {
                Console.WriteLine("Excel workbook not found: " + workbookPath);
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(presentationPath))
            {
                // Access the first slide (or create one if none exist)
                ISlide slide;
                if (pres.Slides.Count > 0)
                {
                    slide = pres.Slides[0];
                }
                else
                {
                    slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
                }

                // Add a chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);

                // Set the external workbook as the data source for the chart
                IChartData chartData = chart.ChartData;
                ((ChartData)chartData).SetExternalWorkbook(workbookPath, false);

                // Save the modified presentation
                string outputPath = "output.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
        }
    }
}