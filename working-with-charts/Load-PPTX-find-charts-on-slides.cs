using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        Aspose.Slides.Charts.IChart chart = slide.Shapes[j] as Aspose.Slides.Charts.IChart;
                        if (chart != null)
                        {
                            Console.WriteLine($"Found chart on slide {i + 1}, shape index {j}, type {chart.Type}");
                        }
                    }
                }

                // Save the presentation after processing
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (ArgumentException ex)
        {
            // Format not supported or other argument issues
            Console.WriteLine("Error loading presentation: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}