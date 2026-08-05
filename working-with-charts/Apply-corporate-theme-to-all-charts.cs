// -----------------------------------------------------------------------------
// Example: Apply corporate theme to all charts using C#
//
// Description:
// Demonstrates how to apply a corporate color theme to all charts in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example loads an existing
// PPTX (or creates a sample one if missing), updates each chart series to use the
// corporate color, and saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Corporate, Theme, Charts,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying a corporate color scheme to all charts in presentations.
// - Build C# tools for batch updating PowerPoint files.
// - Ensure brand consistency across generated PPTX reports.
// - Validate and transform chart formatting in .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ChartThemeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                // Input file does not exist, create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
                // Add a sample chart to demonstrate theme change
                Aspose.Slides.Charts.IChart sampleChart = pres.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 400, 300);
                // Save the newly created presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle loading exceptions (e.g., unsupported format)
                // Format not supported
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            Color corporateColor = Color.FromArgb(0, 112, 192); // Example corporate blue

            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                    if (chart != null)
                    {
                        foreach (Aspose.Slides.Charts.IChartSeries series in chart.ChartData.Series)
                        {
                            series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                            series.Format.Fill.SolidFillColor.Color = corporateColor;
                        }
                    }
                }
            }

            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle saving exceptions (e.g., unsupported format)
                // Format not supported
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }
    }
}
