using System;
using Aspose.Slides.Export;

namespace RetrieveChartAxisMaxValue
{
    class Program
    {
        static void Main()
        {
            try
            {
                var inputPath = "input.pptx";
                var outputPath = "output.pptx";

                // Load presentation
                var presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through slides and shapes
                foreach (var slide in presentation.Slides)
                {
                    foreach (var shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.Charts.IChart chart)
                        {
                            // Ensure layout is validated to get actual axis values
                            chart.ValidateChartLayout();

                            // Access vertical axis and retrieve actual maximum value
                            var verticalAxis = chart.Axes.VerticalAxis;
                            var actualMax = verticalAxis.ActualMaxValue;

                            Console.WriteLine($"Slide {slide.SlideNumber}, Chart '{chart.Name}': Vertical Axis Actual Max Value = {actualMax}");
                        }
                    }
                }

                // Save presentation before exit
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}