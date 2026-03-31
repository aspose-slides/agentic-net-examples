using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

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
                if (presentation.Slides.Count == 0)
                {
                    Console.WriteLine("Presentation contains no slides.");
                    return;
                }

                Aspose.Slides.ISlide slide = presentation.Slides[0];
                if (slide.Shapes.Count == 0)
                {
                    Console.WriteLine("Slide contains no shapes.");
                    return;
                }

                Aspose.Slides.IShape shape = slide.Shapes[0];
                Aspose.Slides.Ink.IInk ink = shape as Aspose.Slides.Ink.IInk;
                if (ink != null && ink.Traces != null && ink.Traces.Length > 0)
                {
                    Aspose.Slides.Ink.IInkBrush brush = ink.Traces[0].Brush;
                    try
                    {
                        // Attempt to set an invalid brush size (below minimum)
                        brush.Size = new SizeF(0f, 0f);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine("Brush size is below the allowed minimum: " + ex.Message);
                        // Set to a safe minimum size
                        brush.Size = new SizeF(0.1f, 0.1f);
                    }
                }
                else
                {
                    Console.WriteLine("No ink shape with traces found on the first slide.");
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}