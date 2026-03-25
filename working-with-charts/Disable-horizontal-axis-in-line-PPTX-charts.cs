using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the input PPTX file
        string inputPath = "input.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Presentation presentation = new Presentation(inputPath))
        {
            // Iterate through all slides
            foreach (ISlide slide in presentation.Slides)
            {
                // Iterate through all shapes on the slide
                foreach (IShape shape in slide.Shapes)
                {
                    // Process only chart shapes
                    if (shape is Aspose.Slides.Charts.Chart)
                    {
                        Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)shape;

                        // Apply only to line charts
                        if (chart.Type == Aspose.Slides.Charts.ChartType.Line)
                        {
                            // Get the horizontal axis
                            IAxis horizontalAxis = chart.Axes.HorizontalAxis;

                            // Hide the axis
                            horizontalAxis.IsVisible = false;

                            // Hide the axis line by setting its fill to NoFill
                            horizontalAxis.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                        }
                    }
                }
            }

            // Save the modified presentation
            string outputPath = "output.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}