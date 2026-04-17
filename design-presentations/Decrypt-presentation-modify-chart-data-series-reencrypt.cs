using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        var inputPath = "protected.pptx";
        var outputPath = "modified.pptx";
        var password = "myPassword";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Open password‑protected presentation
            var loadOptions = new LoadOptions();
            loadOptions.Password = password;
            var presentation = new Presentation(inputPath, loadOptions);

            // Modify chart data series
            var slide = presentation.Slides[0];
            var chart = slide.Shapes[0] as IChart;
            if (chart != null && chart.ChartData.Series.Count > 0)
            {
                var series = chart.ChartData.Series[0];
                if (series.DataPoints.Count > 0)
                {
                    // Example: set first data point value to 75
                    series.DataPoints[0].Value.Data = 75;
                }
            }

            // Re‑encrypt and save
            presentation.ProtectionManager.Encrypt(password);
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}