using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InkDemo
{
    class Program
    {
        static void Main()
        {
            // Define file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string hiddenPdfPath = "hidden.pdf";
            string visiblePdfPath = "visible.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Retrieve ink objects from the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];
            for (int i = 0; i < slide.Shapes.Count; i++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[i];
                Aspose.Slides.Ink.Ink ink = shape as Aspose.Slides.Ink.Ink;
                if (ink != null)
                {
                    // Example: output number of traces (if accessible)
                    // Console.WriteLine($"Ink shape '{ink.Name}' has {ink.Traces.Count} traces.");
                }
            }

            // Delete the first ink shape found (if any)
            for (int i = 0; i < slide.Shapes.Count; i++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[i];
                Aspose.Slides.Ink.Ink ink = shape as Aspose.Slides.Ink.Ink;
                if (ink != null)
                {
                    slide.Shapes.Remove(ink);
                    break;
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Export PDF with hidden ink
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.InkOptions.HideInk = true;
            pres.Save(hiddenPdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Export PDF with visible ink and custom rendering
            pdfOptions.InkOptions.HideInk = false;
            pdfOptions.InkOptions.InterpretMaskOpAsOpacity = false;
            pres.Save(visiblePdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Dispose the presentation
            pres.Dispose();
        }
    }
}