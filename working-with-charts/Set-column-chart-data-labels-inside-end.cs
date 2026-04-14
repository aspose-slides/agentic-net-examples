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
            var presentation = new Presentation();
            var slide = presentation.Slides[0];
            var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Set data label position to InsideEnd for all series
            for (int i = 0; i < chart.ChartData.Series.Count; i++)
            {
                chart.ChartData.Series[i].Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.InsideEnd;
                chart.ChartData.Series[i].Labels.DefaultDataLabelFormat.ShowValue = true;
            }

            presentation.Save("ChartDataLabelPosition.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other exceptions
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}