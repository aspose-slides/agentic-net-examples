using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Output PDF file path
        string outputPdfPath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Iterate through slides and shapes to differentiate standard elements from ink objects
        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
        {
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                // Ink‑based objects are represented by Aspose.Slides.Ink.Ink
                if (shape is Aspose.Slides.Ink.Ink)
                {
                    Console.WriteLine("Ink object found on slide " + slide.SlideNumber);
                }
                else
                {
                    // Standard slide elements include AutoShape, PictureFrame, etc.
                    Console.WriteLine("Standard shape type: " + shape.GetType().Name);
                }
            }
        }

        // Export to PDF while hiding ink elements
        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
        pdfOptions.InkOptions.HideInk = true; // Hide ink in the exported PDF
        presentation.Save(outputPdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

        // Save the (potentially modified) presentation before exiting
        presentation.Save("modified.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}