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
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        using (var pres = new Presentation(inputPath))
        {
            // Assume the Summary Zoom frame is the first shape on the first slide
            var zoomFrame = pres.Slides[0].Shapes[0] as ISummaryZoomFrame;
            if (zoomFrame != null)
            {
                var collection = zoomFrame.SummaryZoomCollection;
                if (pres.Sections.Count > 0)
                {
                    // Remove the initial (first) section from the Summary Zoom
                    collection.RemoveSummaryZoomSection(pres.Sections[0]);
                }
            }

            var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}