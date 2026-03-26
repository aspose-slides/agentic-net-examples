using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Aspose.Slides.Presentation pres;
            if (File.Exists(inputPath))
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                pres = new Aspose.Slides.Presentation();
            }

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a Pie chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie,
                50f,   // X position
                50f,   // Y position
                500f,  // Width
                400f   // Height
            );

            // Customize data labels (using the "customize-data-label" rule)
            // Enable leader lines for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

            // Show value for the first data label
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;

            // Show category name for the second data label
            chart.ChartData.Series[0].Labels[1].DataLabelFormat.ShowCategoryName = true;

            // Set a custom separator for the third data label
            chart.ChartData.Series[0].Labels[2].DataLabelFormat.Separator = " - ";

            // Save the presentation (using the required save rule)
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}