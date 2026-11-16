// -----------------------------------------------------------------------------
// Example: Clone Chart Slide and Link to External Workbook
//
// Description:
// Demonstrates cloning a slide that contains a chart, inserting the clone before
// the original slide, and linking the chart's data to an external Excel workbook
// using Aspose.Slides for .NET. The program creates sample files if they are
// missing, processes the presentation, and saves the result.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Slide, Chart, External Workbook
//
// Use Cases:
// - Automate cloning a chart slide and linking it to external data.
// - Build tools for batch updating PowerPoint presentations with Excel sources.
// - Validate presentation workflows that involve chart data externalization.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");
        string workbookPath = Path.Combine(dataDir, "data.xlsx");

        try
        {
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            if (!File.Exists(workbookPath))
            {
                File.WriteAllBytes(workbookPath, new byte[0]);
            }

            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = samplePres.Slides[0];
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50, 50, 500, 400);
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlideCollection slides = pres.Slides;

            int chartSlideIndex = -1;
            Aspose.Slides.Charts.IChart originalChart = null;

            for (int i = 0; i < slides.Count; i++)
            {
                Aspose.Slides.ISlide s = slides[i];
                foreach (Aspose.Slides.IShape shape in s.Shapes)
                {
                    originalChart = shape as Aspose.Slides.Charts.IChart;
                    if (originalChart != null)
                    {
                        chartSlideIndex = i;
                        break;
                    }
                }
                if (chartSlideIndex != -1)
                {
                    break;
                }
            }

            if (chartSlideIndex == -1)
            {
                Console.WriteLine("No chart found in the presentation.");
                pres.Dispose();
                Environment.Exit(1);
            }

            slides.InsertClone(chartSlideIndex, slides[chartSlideIndex]);

            Aspose.Slides.ISlide clonedSlide = slides[chartSlideIndex];
            Aspose.Slides.Charts.IChart clonedChart = null;
            foreach (Aspose.Slides.IShape shape in clonedSlide.Shapes)
            {
                clonedChart = shape as Aspose.Slides.Charts.IChart;
                if (clonedChart != null)
                {
                    break;
                }
            }

            if (clonedChart != null)
            {
                try
                {
                    clonedChart.ChartData.SetExternalWorkbook(workbookPath, true);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Failed to set external workbook: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Cloned chart not found.");
                pres.Dispose();
                Environment.Exit(1);
            }

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The file format is not supported.");
            Environment.Exit(1);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
