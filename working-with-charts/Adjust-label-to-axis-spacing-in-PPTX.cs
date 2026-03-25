using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Find the first chart on the slide
            Aspose.Slides.Charts.IChart chart = null;
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.Charts.IChart)
                {
                    chart = (Aspose.Slides.Charts.IChart)shape;
                    break;
                }
            }

            if (chart != null)
            {
                // Adjust the distance of axis labels from the horizontal axis
                Aspose.Slides.Charts.IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                horizontalAxis.LabelOffset = (ushort)50; // 5% distance

                // Adjust the distance of axis labels from the vertical axis (optional)
                Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;
                verticalAxis.LabelOffset = (ushort)30; // 3% distance
            }
            else
            {
                Console.WriteLine("No chart found in the first slide.");
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}