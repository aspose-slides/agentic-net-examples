using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directories and file paths
            string dataDir = "Data";
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");
            string pdfHiddenPath = Path.Combine(dataDir, "output_hidden.pdf");
            string pdfVisiblePath = Path.Combine(dataDir, "output_visible.pdf");

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a slide and a line shape (used here as a placeholder for ink)
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.IAutoShape lineShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

            // Save the presentation (ink visible)
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Load the presentation to retrieve ink annotations
            Aspose.Slides.Presentation loadedPres = new Aspose.Slides.Presentation(outputPath);
            Aspose.Slides.ISlide loadedSlide = loadedPres.Slides[0];
            if (loadedSlide.Shapes.Count > 0)
            {
                Aspose.Slides.IShape firstShape = loadedSlide.Shapes[0];
                // Attempt to cast the shape to an Ink object
                Aspose.Slides.Ink.IInk ink = firstShape as Aspose.Slides.Ink.IInk;
                if (ink != null)
                {
                    Aspose.Slides.Ink.IInkTrace[] traces = ink.Traces;
                    Console.WriteLine("Ink shape contains {0} trace(s).", traces.Length);
                }
                else
                {
                    Console.WriteLine("First shape is not an Ink shape.");
                }
            }

            // Modify InkOptions to hide ink when exporting to PDF
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.InkOptions.HideInk = true;
            loadedPres.Save(pdfHiddenPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Show ink in PDF and change rendering mode
            pdfOptions.InkOptions.HideInk = false;
            pdfOptions.InkOptions.InterpretMaskOpAsOpacity = false;
            loadedPres.Save(pdfVisiblePath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Dispose resources
            pres.Dispose();
            loadedPres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: {0}", ex.Message);
        }
    }
}