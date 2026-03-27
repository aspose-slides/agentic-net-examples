using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace AsposeSlidesColorControl
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Modify the background color of the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

            // Change the fill color of the first shape on the slide (if any)
            if (slide.Shapes.Count > 0)
            {
                Aspose.Slides.IShape shape = slide.Shapes[0];
                if (shape.FillFormat != null)
                {
                    shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    shape.FillFormat.SolidFillColor.Color = Color.Red;
                }
            }

            // Iterate through shapes to find a chart and change its first series color
            for (int i = 0; i < slide.Shapes.Count; i++)
            {
                Aspose.Slides.IShape shp = slide.Shapes[i];
                Aspose.Slides.Charts.IChart chart = shp as Aspose.Slides.Charts.IChart;
                if (chart != null && chart.ChartData.Series.Count > 0)
                {
                    chart.ChartData.Series[0].Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                    chart.ChartData.Series[0].Format.Fill.SolidFillColor.Color = Color.FromArgb(255, 0, 255, 0);
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}