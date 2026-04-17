using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string outputPath = "ErrorBarTransparency.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble,
            50, 50, 500, 400, true);

        // Access the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Configure X error bars
        Aspose.Slides.Charts.IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
        errorBarsX.IsVisible = true;
        errorBarsX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
        errorBarsX.Value = 5f;
        errorBarsX.Type = Aspose.Slides.Charts.ErrorBarType.Plus;
        errorBarsX.HasEndCap = true;

        // Reduce X error bar transparency to 50% (alpha = 128)
        if (errorBarsX.Format != null && errorBarsX.Format.Line != null && errorBarsX.Format.Line.FillFormat != null)
        {
            errorBarsX.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            errorBarsX.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(128, 0, 0, 255);
        }

        // Configure Y error bars
        Aspose.Slides.Charts.IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
        errorBarsY.IsVisible = true;
        errorBarsY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Percentage;
        errorBarsY.Value = 10f;
        errorBarsY.Format.Line.Width = 2;

        // Reduce Y error bar transparency to 50% (alpha = 128)
        if (errorBarsY.Format != null && errorBarsY.Format.Line != null && errorBarsY.Format.Line.FillFormat != null)
        {
            errorBarsY.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            errorBarsY.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(128, 255, 0, 0);
        }

        // Save the presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}