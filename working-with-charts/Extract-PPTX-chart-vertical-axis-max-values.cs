using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ChartAxisAnalysis
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Paths to input and output files
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Process only chart shapes
                        if (shape is Aspose.Slides.Charts.IChart)
                        {
                            Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)shape;

                            // Validate layout to obtain actual axis values
                            chart.ValidateChartLayout();

                            // Access the vertical axis
                            Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;

                            // Retrieve the actual maximum value
                            double actualMax = verticalAxis.ActualMaxValue;

                            Console.WriteLine($"Slide {slideIndex + 1}, Chart {shapeIndex + 1}: Vertical Axis Actual Max = {actualMax}");
                        }
                    }
                }

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}