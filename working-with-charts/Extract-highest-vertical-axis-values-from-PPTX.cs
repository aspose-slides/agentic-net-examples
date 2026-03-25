using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RetrieveChartAxisValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                if (!File.Exists(inputPath))
                {
                    throw new FileNotFoundException("Input file not found.", inputPath);
                }

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        if (shape is Aspose.Slides.Charts.IChart)
                        {
                            Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)shape;
                            chart.ValidateChartLayout();

                            double maxVerticalValue = chart.Axes.VerticalAxis.ActualMaxValue;

                            Console.WriteLine($"Slide {slideIndex + 1}, Chart {shapeIndex + 1}: Max Vertical Axis = {maxVerticalValue}");
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}