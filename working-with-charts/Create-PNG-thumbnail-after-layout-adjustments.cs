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