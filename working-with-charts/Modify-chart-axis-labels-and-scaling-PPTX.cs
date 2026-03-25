using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartAxisCustomization
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Assume the first slide contains the chart
                Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

                // Find the first chart on the slide
                Aspose.Slides.Charts.IChart chart = null;
                foreach (Aspose.Slides.IShape shape in shapes)
                {
                    if (shape is Aspose.Slides.Charts.IChart)
                    {
                        chart = (Aspose.Slides.Charts.IChart)shape;
                        break;
                    }
                }

                if (chart != null)
                {
                    // Customize the vertical (value) axis
                    Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;
                    verticalAxis.IsAutomaticMaxValue = false;
                    verticalAxis.MaxValue = 200;
                    verticalAxis.IsAutomaticMinValue = false;
                    verticalAxis.MinValue = 0;
                    verticalAxis.LabelOffset = (ushort)50; // ushort value
                    verticalAxis.TickLabelPosition = Aspose.Slides.Charts.TickLabelPositionType.Low;
                    verticalAxis.NumberFormat = "0.0%";

                    // Customize the horizontal (category) axis
                    Aspose.Slides.Charts.IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                    horizontalAxis.IsAutomaticMajorUnit = false;
                    horizontalAxis.MajorUnit = 10;
                    horizontalAxis.LabelOffset = (ushort)30; // ushort value

                    // Recalculate layout if needed
                    chart.ValidateChartLayout();
                }

                // Save the modified presentation
                string outputPath = "output.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}