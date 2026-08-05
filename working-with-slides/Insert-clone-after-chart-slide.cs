// -----------------------------------------------------------------------------
// Example: Insert clone after chart slide using C#
//
// Description:
// Demonstrates how to insert a clone of a slide that contains a chart immediately
// after that slide using C# and Aspose.Slides for .NET. The example shows the
// required presentation-processing steps for PowerPoint files and produces the
// requested output in a standalone console application. Developers can use this
// pattern to automate PPTX workflows, validate results, or integrate presentation
// logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Clone, After, Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of a cloned slide following a chart slide.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

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
