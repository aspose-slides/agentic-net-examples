using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string dataDir = "Data/";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");
        string workbookPath = Path.Combine(dataDir, "data.xlsx");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            var pres = new Aspose.Slides.Presentation(inputPath);
            var slides = pres.Slides;
            int chartSlideIndex = -1;
            Aspose.Slides.Charts.IChart chart = null;

            for (int i = 0; i < slides.Count; i++)
            {
                var slide = slides[i];
                foreach (var shape in slide.Shapes)
                {
                    chart = shape as Aspose.Slides.Charts.IChart;
                    if (chart != null)
                    {
                        chartSlideIndex = i;
                        break;
                    }
                }
                if (chartSlideIndex != -1) break;
            }

            if (chartSlideIndex == -1)
            {
                Console.WriteLine("No chart found in presentation.");
                pres.Dispose();
                return;
            }

            // Clone the slide containing the chart and insert before it
            slides.InsertClone(chartSlideIndex, slides[chartSlideIndex]);

            // The cloned slide is now at chartSlideIndex
            var clonedSlide = slides[chartSlideIndex];
            Aspose.Slides.Charts.IChart clonedChart = null;
            foreach (var shape in clonedSlide.Shapes)
            {
                clonedChart = shape as Aspose.Slides.Charts.IChart;
                if (clonedChart != null) break;
            }

            if (clonedChart != null)
            {
                try
                {
                    // Replace chart data source with external workbook
                    ((Aspose.Slides.Charts.ChartData)clonedChart.ChartData).SetExternalWorkbook(workbookPath, true);
                }
                catch (InvalidOperationException)
                {
                    // External workbook not available or cannot be loaded
                }
            }

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}