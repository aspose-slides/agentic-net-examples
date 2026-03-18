using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            var presentation = new Aspose.Slides.Presentation(inputPath);
            var slide = presentation.Slides[0];

            Aspose.Slides.Charts.IChart chart = null;
            foreach (var shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.Charts.IChart)
                {
                    chart = (Aspose.Slides.Charts.IChart)shape;
                    break;
                }
            }

            if (chart != null)
            {
                // Adjust legend font size
                chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}