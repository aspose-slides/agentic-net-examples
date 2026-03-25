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
            var presentation = new Aspose.Slides.Presentation();
            var chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Sunburst, 50f, 50f, 500f, 400f);
            var dataPoints = chart.ChartData.Series[0].DataPoints;

            // Customize the label and color of a specific data point level
            var label = dataPoints[3].DataPointLevels[0].Label;
            label.DataLabelFormat.ShowValue = true;
            label.DataLabelFormat.ShowSeriesName = true;
            label.TextFormat.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            label.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Yellow;

            // Save the presentation
            presentation.Save("CustomLabelChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine("Input file not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}