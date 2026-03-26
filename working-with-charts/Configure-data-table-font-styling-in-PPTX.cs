using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            Aspose.Slides.Charts.IChart chart;
            if (slide.Shapes.Count > 0 && slide.Shapes[0] is Aspose.Slides.Charts.IChart)
            {
                chart = (Aspose.Slides.Charts.IChart)slide.Shapes[0];
            }
            else
            {
                chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);
            }

            chart.HasDataTable = true;

            Aspose.Slides.Charts.IDataTable dataTable = chart.ChartDataTable;

            Aspose.Slides.Charts.IChartTextFormat textFormat = dataTable.TextFormat;
            textFormat.PortionFormat.FontHeight = 12f;
            textFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
            textFormat.PortionFormat.FontItalic = Aspose.Slides.NullableBool.False;
            textFormat.PortionFormat.FontUnderline = Aspose.Slides.TextUnderlineType.Single;

            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}