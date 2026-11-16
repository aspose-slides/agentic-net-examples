// -----------------------------------------------------------------------------
// Example: Insert Clone After Chart Slide Using Aspose.Slides for .NET
//
// Description:
// This console program creates a sample PPTX file with a chart if none exists,
// locates the first slide containing a chart, inserts a cloned copy of that slide
// immediately after it, and saves the result. It demonstrates slide cloning and
// chart handling with Aspose.Slides for .NET in C#.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert Clone Chart Slide
//
// Use Cases:
// - Automate duplication of chart slides in presentation workflows.
// - Build tools that modify PPTX files by cloning specific content.
// - Validate slide structures after programmatic changes.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            if (!File.Exists(inputPath))
            {
                // Create a sample presentation with a chart slide
                using (Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation())
                {
                    Aspose.Slides.ISlideCollection slideCollection = samplePres.Slides;
                    Aspose.Slides.ISlide chartSlide = slideCollection.AddEmptySlide(samplePres.Slides[0].LayoutSlide);
                    Aspose.Slides.Charts.IChart chart = chartSlide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.ISlideCollection slides = presentation.Slides;
                int chartSlideIndex = -1;

                for (int i = 0; i < slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = slides[i];
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[j];
                        if (shape is Aspose.Slides.Charts.IChart)
                        {
                            chartSlideIndex = i;
                            break;
                        }
                    }
                    if (chartSlideIndex != -1)
                    {
                        break;
                    }
                }

                if (chartSlideIndex != -1)
                {
                    Aspose.Slides.ISlide sourceSlide = slides[chartSlideIndex];
                    int insertIndex = chartSlideIndex + 1;
                    slides.InsertClone(insertIndex, sourceSlide);
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    Console.WriteLine("Clone inserted and saved to " + outputPath);
                }
                else
                {
                    Console.WriteLine("No slide with a chart found.");
                    Environment.Exit(1);
                }
            }
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The file format is not supported.");
            Environment.Exit(1);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
