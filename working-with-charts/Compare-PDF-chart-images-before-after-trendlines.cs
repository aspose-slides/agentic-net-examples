// -----------------------------------------------------------------------------
// Example: Compare pdf chart images before after trendlines using C#
//
// Description:
// Demonstrates how to generate PDF images of a chart before and after adding
// a linear trendline using C# and Aspose.Slides for .NET. The example creates a
// clustered column chart, saves the presentation as PDF, adds a trendline to
// the first series, saves a second PDF, and then performs a byte‑wise comparison
// of the two PDF files. This pattern can be used to validate visual changes in
// chart rendering or to automate regression testing of presentation content.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Compare, Chart, Trendline,
// Images, Before, After, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate comparison of PDF chart images before and after applying trendlines.
// - Build C# tools for PowerPoint presentation processing and visual regression testing.
// - Generate or transform PPTX files and export them to PDF in .NET applications.
// - Validate chart rendering changes in automated CI pipelines.
// -----------------------------------------------------------------------------

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
        string outputPathBefore = "chart_before.pdf";
        string outputPathAfter = "chart_after.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Presentation pres = new Presentation(inputPath);
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

            // Save PDF before adding trend lines
            pres.Save(outputPathBefore, SaveFormat.Pdf);

            // Add a linear trend line to the first series
            ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
            trendline.DisplayEquation = false;
            trendline.DisplayRSquaredValue = false;

            // Save PDF after adding trend lines
            pres.Save(outputPathAfter, SaveFormat.Pdf);

            // Compare the two PDF files (byte-wise)
            byte[] beforeBytes = File.ReadAllBytes(outputPathBefore);
            byte[] afterBytes = File.ReadAllBytes(outputPathAfter);
            bool areIdentical = beforeBytes.Length == afterBytes.Length;
            if (areIdentical)
            {
                for (int i = 0; i < beforeBytes.Length; i++)
                {
                    if (beforeBytes[i] != afterBytes[i])
                    {
                        areIdentical = false;
                        break;
                    }
                }
            }

            Console.WriteLine(areIdentical ? "PDFs are identical." : "PDFs differ.");
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs or web services)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
