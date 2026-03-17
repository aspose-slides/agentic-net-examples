using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AnalyzeInkAnnotations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths – adjust as needed
            string inputPath = "input.pptx";
            string outputPptxPath = "output.pptx";
            string outputPdfVisibleInkPath = "output_visible_ink.pdf";
            string outputPdfHiddenInkPath = "output_hidden_ink.pdf";

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through slides and shapes
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    Console.WriteLine($"Slide {slideIndex + 1}:");

                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape is an Ink annotation
                        Aspose.Slides.Ink.Ink inkShape = shape as Aspose.Slides.Ink.Ink;
                        if (inkShape != null)
                        {
                            // Ink specific properties
                            Console.WriteLine($"  Ink Annotation - Name: {inkShape.Name}, Position: ({inkShape.X}, {inkShape.Y}), Size: ({inkShape.Width} x {inkShape.Height})");
                            Console.WriteLine($"  Ink Traces Count: {inkShape.Traces.Length}");
                        }
                        else
                        {
                            // Standard shape properties
                            Console.WriteLine($"  Standard Shape - Type: {shape.GetType().Name}, Name: {shape.Name}, Position: ({shape.X}, {shape.Y}), Size: ({shape.Width} x {shape.Height})");
                        }
                    }
                }

                // Example: configure Ink options for export
                // Hide ink when exporting to PDF (visible ink PDF)
                Aspose.Slides.Export.PdfOptions pdfOptionsVisible = new Aspose.Slides.Export.PdfOptions();
                pdfOptionsVisible.InkOptions.HideInk = false;
                presentation.Save(outputPdfVisibleInkPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptionsVisible);

                // Hide ink when exporting to PDF (hidden ink PDF)
                Aspose.Slides.Export.PdfOptions pdfOptionsHidden = new Aspose.Slides.Export.PdfOptions();
                pdfOptionsHidden.InkOptions.HideInk = true;
                presentation.Save(outputPdfHiddenInkPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptionsHidden);

                // Save the presentation (PPTX) before exiting
                presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}