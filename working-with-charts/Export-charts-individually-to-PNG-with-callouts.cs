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
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                int slideCount = pres.Slides.Count;
                for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                    int shapeCount = slide.Shapes.Count;
                    int chartIndex = 0;
                    for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
                    {
                        Aspose.Slides.Charts.IChart chart = slide.Shapes[shapeIndex] as Aspose.Slides.Charts.IChart;
                        if (chart != null)
                        {
                            Aspose.Slides.IImage chartImage = chart.GetImage();
                            string outFile = $"Chart_Slide{slideIndex + 1}_Chart{chartIndex + 1}.png";
                            chartImage.Save(outFile, Aspose.Slides.ImageFormat.Png);
                            chartIndex++;
                        }
                    }
                }

                // Save the presentation before exit
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}