using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Presentation presentation = null;
        try
        {
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                throw new FileNotFoundException("Input file not found.", inputPath);
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            presentation = new Presentation();
        }

        ISlide slide = presentation.Slides[0];
        IChart chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 400, 300);

        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 150; // size as percentage
        chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = PieSplitType.ByPercentage;
        chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 30.0; // split position

        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}