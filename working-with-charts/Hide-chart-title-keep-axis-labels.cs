using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Presentation pres = null;
        try
        {
            if (File.Exists(inputPath))
            {
                pres = new Presentation(inputPath);
            }
            else
            {
                pres = new Presentation();
                ISlide slide = pres.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);
                chart.HasTitle = false;
            }

            foreach (ISlide slide in pres.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    IChart chart = shape as IChart;
                    if (chart != null)
                    {
                        chart.HasTitle = false;
                    }
                }
            }

            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}