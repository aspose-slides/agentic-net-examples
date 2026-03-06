using System;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output PPTX file paths
            System.String inputPath = "input.pptx";
            System.String outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Retrieve the first shape as a chart
            Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)slide.Shapes[0];

            // Set the chart data range
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
    }
}