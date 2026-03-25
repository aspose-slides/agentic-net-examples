using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "PrecisionChart.pptx";

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50, 50, 450, 300);
            chart.HasDataTable = true;
            chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine("Input file not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}