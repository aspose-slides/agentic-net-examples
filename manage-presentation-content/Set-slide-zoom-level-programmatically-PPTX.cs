using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideZoomDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Set slide and notes view zoom to 150%
            presentation.ViewProperties.SlideViewProperties.Scale = 150;
            presentation.ViewProperties.NotesViewProperties.Scale = 150;

            // Add a Zoom Frame on the first slide linking to the second slide
            if (presentation.Slides.Count > 1)
            {
                var targetSlide = presentation.Slides[1];
                var zoomFrame = presentation.Slides[0].Shapes.AddZoomFrame(100f, 100f, 200f, 200f, targetSlide);
                zoomFrame.ReturnToParent = true;
            }

            var outputPath = "output.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine($"Presentation saved to {outputPath}");
        }
    }
}