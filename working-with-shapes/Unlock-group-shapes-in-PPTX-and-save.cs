using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            var pres = new Presentation(inputPath);
            foreach (var slide in pres.Slides)
            {
                foreach (var shape in slide.Shapes)
                {
                    if (shape is IGroupShape groupShape)
                    {
                        var lockObj = groupShape.GroupShapeLock;
                        lockObj.AspectRatioLocked = false;
                        lockObj.GroupingLocked = false;
                        lockObj.PositionLocked = false;
                        lockObj.RotationLocked = false;
                        lockObj.SelectLocked = false;
                        lockObj.SizeLocked = false;
                        lockObj.UngroupingLocked = false;
                    }
                }
            }
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}