using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            var presentationPath = "input.pptx";
            using (var pres = new Aspose.Slides.Presentation(presentationPath))
            {
                var slide = pres.Slides[0];
                var chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
                if (chart != null)
                {
                    var externalWorkbookPath = chart.ChartData.ExternalWorkbookPath;
                    Console.WriteLine("External workbook path: " + (externalWorkbookPath ?? "None"));
                }
                else
                {
                    Console.WriteLine("No chart found on the first shape.");
                }

                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}