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
        string outputPresentationPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Process each slide
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                // Remove error bars from all charts on the slide
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                    if (chart != null)
                    {
                        for (int seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
                        {
                            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[seriesIndex];

                            Aspose.Slides.Charts.IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
                            if (errorBarsX != null)
                            {
                                errorBarsX.IsVisible = false;
                            }

                            Aspose.Slides.Charts.IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
                            if (errorBarsY != null)
                            {
                                errorBarsY.IsVisible = false;
                            }
                        }
                    }
                }

                // Convert the slide to PNG
                string pngPath = $"slide_{slideIndex}.png";
                using (Aspose.Slides.IImage slideImage = slide.GetImage())
                {
                    slideImage.Save(pngPath, Aspose.Slides.ImageFormat.Png);
                }
            }

            // Save the modified presentation
            pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs or I/O errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}