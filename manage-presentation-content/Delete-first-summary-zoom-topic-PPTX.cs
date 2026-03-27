using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        using (var pres = new Presentation(inputPath))
        {
            var slide = pres.Slides[0];
            var zoomFrame = slide.Shapes[0] as ISummaryZoomFrame;
            if (zoomFrame == null)
            {
                Console.WriteLine("Summary Zoom Frame not found.");
                return;
            }

            var collection = zoomFrame.SummaryZoomCollection;
            if (pres.Sections.Count > 0)
            {
                var firstSection = pres.Sections[0];
                collection.RemoveSummaryZoomSection(firstSection);
            }

            var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}