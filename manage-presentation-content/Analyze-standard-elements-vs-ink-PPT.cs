using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the presentation
        using (var pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through each slide
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                var slide = pres.Slides[i];
                Console.WriteLine($"Slide {i + 1}:");

                // Iterate through each shape on the slide
                foreach (var shape in slide.Shapes)
                {
                    // Check if the shape is an Ink annotation
                    if (shape is Ink inkShape)
                    {
                        Console.WriteLine($"  Ink shape - Name: {inkShape.Name}, Traces: {inkShape.Traces.Length}");

                        // Example: display the InkEffect of the first trace, if any
                        if (inkShape.Traces.Length > 0)
                        {
                            var brush = inkShape.Traces[0].Brush;
                            Console.WriteLine($"    InkEffect: {brush.InkEffect}");
                        }
                    }
                    else
                    {
                        // Standard shape handling
                        Console.WriteLine($"  Standard shape - Type: {shape.GetType().Name}, Name: {shape.Name}");
                    }
                }
            }

            // Save the presentation (preserve original format)
            pres.Save("output.pptx", SaveFormat.Pptx);

            // Example: export to PDF while showing Ink elements
            var pdfOptions = new PdfOptions();
            pdfOptions.InkOptions.HideInk = false; // Show Ink in the exported PDF
            pres.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
        }
    }
}