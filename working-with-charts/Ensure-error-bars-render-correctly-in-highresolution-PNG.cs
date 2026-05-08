using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ErrorBarsPngExport
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                var presentation = new Aspose.Slides.Presentation();

                // Add a bubble chart with error bars on the first slide
                var slide = presentation.Slides[0];
                var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 500f, 400f, true);
                var series = chart.ChartData.Series[0];

                // Configure X error bars
                var errorBarsX = series.ErrorBarsXFormat;
                errorBarsX.IsVisible = true;
                errorBarsX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
                errorBarsX.Value = 0.5f;
                errorBarsX.Type = Aspose.Slides.Charts.ErrorBarType.Plus;
                errorBarsX.HasEndCap = true;

                // Configure Y error bars
                var errorBarsY = series.ErrorBarsYFormat;
                errorBarsY.IsVisible = true;
                errorBarsY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Percentage;
                errorBarsY.Value = 10f; // 10%
                errorBarsY.Type = Aspose.Slides.Charts.ErrorBarType.Plus;
                errorBarsY.HasEndCap = true;
                errorBarsY.Format.Line.Width = 2;

                // Save the presentation (required before exit)
                presentation.Save("ErrorBarsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                // Export each slide to a high‑resolution PNG image
                float scaleX = 2f; // 200% scaling for higher resolution
                float scaleY = 2f;
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    var s = presentation.Slides[i];
                    var image = s.GetImage(scaleX, scaleY);
                    var outputPath = $"slide_{i}.png";
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}