using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a scatter chart with smooth lines
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
                50, 50, 400, 300);

            // Get the first series of the chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Configure X error bars (style, color, thickness)
            Aspose.Slides.Charts.IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
            errorBarsX.IsVisible = true;
            errorBarsX.Type = Aspose.Slides.Charts.ErrorBarType.Both;
            errorBarsX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
            errorBarsX.Value = 0.5f;
            errorBarsX.HasEndCap = true;
            errorBarsX.Format.Line.Width = 2.0;
            errorBarsX.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            errorBarsX.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

            // Configure Y error bars (style, color, thickness)
            Aspose.Slides.Charts.IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
            errorBarsY.IsVisible = true;
            errorBarsY.Type = Aspose.Slides.Charts.ErrorBarType.Plus;
            errorBarsY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Percentage;
            errorBarsY.Value = 10f;
            errorBarsY.HasEndCap = false;
            errorBarsY.Format.Line.Width = 3.0;
            errorBarsY.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            errorBarsY.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            pres.Save("ErrorBarsPresentation.pptx", SaveFormat.Pptx);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Input file not found: " + ex.FileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}