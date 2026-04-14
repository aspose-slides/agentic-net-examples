using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file paths
            string presentationPath = "output.pptx";
            string chartImagePath = "chart_highres.jpg";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a clustered column chart to the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(
                    ChartType.ClusteredColumn,
                    50f,   // X position
                    50f,   // Y position
                    500f,  // Width
                    400f   // Height
                );

                // Obtain the chart image (default size)
                IImage chartImage = chart.GetImage();

                // Save the chart image as a high‑resolution JPEG (quality = 100)
                chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Jpeg, 100);

                // Save the presentation
                presentation.Save(presentationPath, SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}