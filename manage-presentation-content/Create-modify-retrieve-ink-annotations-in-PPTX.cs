using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pdf";

        // Ensure the input file exists; create a simple presentation if it does not.
        if (!File.Exists(inputPath))
        {
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];
                // Add a line shape as a placeholder for an ink annotation.
                slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
                pres.Save(inputPath, SaveFormat.Pptx);
            }
        }

        // Load the presentation.
        using (Presentation pres = new Presentation(inputPath))
        {
            // Retrieve ink annotations on the first slide, if any.
            foreach (IShape shape in pres.Slides[0].Shapes)
            {
                Ink inkShape = shape as Ink;
                if (inkShape != null)
                {
                    IInkTrace[] traces = inkShape.Traces;
                    Console.WriteLine("Ink shape contains {0} trace(s).", traces.Length);
                }
            }

            // Modify rendering options to hide ink when exporting.
            RenderingOptions renderingOpts = new RenderingOptions();
            renderingOpts.InkOptions.HideInk = true;

            // Save the presentation as PDF with the modified ink options.
            pres.Save(outputPath, SaveFormat.Pdf, renderingOpts);
        }
    }
}