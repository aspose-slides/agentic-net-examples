// -----------------------------------------------------------------------------
// Example: Create PNG thumbnail of a chart after layout adjustments using C#
//
// Description:
// Demonstrates how to add a chart to a PowerPoint slide, validate its layout,
// generate a PNG thumbnail of the chart, and save the presentation using
// Aspose.Slides for .NET. The example is a self‑contained console application
// that can be used to automate chart thumbnail creation and presentation
// processing workflows.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Chart, PNG, Thumbnail, Layout,
// Validation, Presentation Automation, Office Automation
//
// Use Cases:
// - Generate PNG thumbnails of charts after layout validation.
// - Automate PowerPoint chart processing in C# applications.
// - Build tools that create visual previews of slides or charts.
// - Integrate chart thumbnail generation into reporting or publishing pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesChartThumbnail
{
    public class Program
    {
        public static void Main()
        {
            // Define file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Create or load presentation
            Presentation pres = null;
            try
            {
                if (File.Exists(inputPath))
                {
                    pres = new Presentation(inputPath);
                }
                else
                {
                    pres = new Presentation();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading or creating presentation: " + ex.Message);
                return;
            }

            try
            {
                // Access first slide (creates one if presentation is new)
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);

                // Example layout adjustment: validate chart layout
                chart.ValidateChartLayout();

                // Generate PNG thumbnail of the chart after layout adjustments
                IImage chartImage = chart.GetImage();
                string chartThumbnailPath = "chart_thumbnail.png";
                chartImage.Save(chartThumbnailPath, ImageFormat.Png);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested image format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing chart: " + ex.Message);
            }

            try
            {
                // Save the presentation before exit
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested save format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }
    }
}
