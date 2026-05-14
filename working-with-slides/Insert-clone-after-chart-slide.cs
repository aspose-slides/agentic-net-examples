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

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.ISlideCollection slides = presentation.Slides;
                int chartSlideIndex = -1;

                for (int i = 0; i < slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = slides[i];
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.Charts.IChart)
                        {
                            chartSlideIndex = i;
                            break;
                        }
                    }
                    if (chartSlideIndex != -1)
                        break;
                }

                if (chartSlideIndex != -1)
                {
                    Aspose.Slides.ISlide sourceSlide = slides[chartSlideIndex];
                    int insertIndex = chartSlideIndex + 1;
                    slides.InsertClone(insertIndex, sourceSlide);
                }
                else
                {
                    Console.WriteLine("No slide with a chart found.");
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
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