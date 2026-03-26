using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartImageExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file paths
            string presentationPath = "ChartPresentation.pptx";
            string chartImagePath = "ChartImage.png";

            // If output files already exist, delete them to avoid exceptions
            if (File.Exists(presentationPath))
            {
                File.Delete(presentationPath);
            }
            if (File.Exists(chartImagePath))
            {
                File.Delete(chartImagePath);
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f,   // X position
                50f,   // Y position
                500f,  // Width
                300f   // Height
            );

            // Export the chart as an image preserving its visual appearance
            Aspose.Slides.IImage chartImage = chart.GetImage();
            chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Png);

            // Save the presentation to disk
            presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();

            Console.WriteLine("Chart image saved to: " + chartImagePath);
            Console.WriteLine("Presentation saved to: " + presentationPath);
        }
    }
}