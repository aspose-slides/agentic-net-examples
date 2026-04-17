using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            var pres = new Presentation(inputPath);
            var slides = pres.Slides;

            // Clone the first slide to position index 2
            var clonedSlide = slides.InsertClone(2, slides[0]);

            // Lock all shapes on the cloned slide (placeholder for actual lock implementation)
            foreach (var shape in clonedSlide.Shapes)
            {
                // Example: shape.LockAspectRatio = true;
                // Example: shape.IsLocked = true;
            }

            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex) when (ex is NotSupportedException || ex is Aspose.Slides.PptxEditException)
        {
            // Format not supported
            Console.WriteLine("File format not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}