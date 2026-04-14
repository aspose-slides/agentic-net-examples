using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        var dataDir = "Data";
        var workbookPath = Path.Combine(dataDir, "workbook.xlsx");
        var outputPath = Path.Combine(dataDir, "output.pptx");

        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        if (!File.Exists(workbookPath))
        {
            Console.WriteLine("Workbook not found: " + workbookPath);
            return;
        }

        try
        {
            var presentation = new Aspose.Slides.Presentation();

            var chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 600, true);
            var chartData = chart.ChartData;
            ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook(workbookPath, true);

            var workbook = chartData.ChartDataWorkbook;
            workbook.GetCell(0, "A1", "Category 1");
            workbook.GetCell(0, "B1", 10);
            workbook.GetCell(0, "A2", "Category 2");
            workbook.GetCell(0, "B2", 20);
            workbook.CalculateFormulas();

            var slide = (Aspose.Slides.Slide)presentation.Slides[0];
            var shapes = (Aspose.Slides.ShapeCollection)slide.Shapes;
            var chartShape = (Aspose.Slides.Charts.IChart)shapes[0];
            slide.Timeline.MainSequence.AddEffect(chartShape, Aspose.Slides.Animation.EffectType.Fade, Aspose.Slides.Animation.EffectSubtype.None, Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
            var seq = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;
            int categoryCount = chartShape.ChartData.Categories.Count;
            int seriesCount = chartShape.ChartData.Series.Count;
            for (int cat = 0; cat < categoryCount; cat++)
            {
                for (int ser = 0; ser < seriesCount; ser++)
                {
                    seq.AddEffect(chartShape, Aspose.Slides.Animation.EffectChartMinorGroupingType.ByElementInCategory, ser, cat, Aspose.Slides.Animation.EffectType.Appear, Aspose.Slides.Animation.EffectSubtype.None, Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Invalid operation: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}