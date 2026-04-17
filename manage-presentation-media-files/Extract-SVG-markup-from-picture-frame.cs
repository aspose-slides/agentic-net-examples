using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputSvgPath = "picture.svg";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file '{inputPath}' does not exist.");
            return;
        }

        try
        {
            using (var pres = new Aspose.Slides.Presentation(inputPath))
            {
                var slide = pres.Slides[0];
                foreach (var shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.IPictureFrame)
                    {
                        using (var fs = new FileStream(outputSvgPath, FileMode.Create, FileAccess.Write))
                        {
                            shape.WriteAsSvg(fs);
                            Console.WriteLine($"SVG markup extracted to '{outputSvgPath}'.");
                        }
                        break;
                    }
                }

                // Save presentation before exiting
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}