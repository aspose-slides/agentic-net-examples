using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        using (Presentation pres = new Presentation(inputPath))
        {
            // Attempt to retrieve the first shape as an Ink object
            IInk inkShape = pres.Slides[0].Shapes[0] as IInk;
            if (inkShape != null)
            {
                IInkTrace[] traces = inkShape.Traces;
                if (traces.Length > 0)
                {
                    IInkBrush brush = traces[0].Brush;

                    // Set brush size (width and height in points)
                    brush.Size = new SizeF(5f, 5f);

                    // Set brush color with opacity (alpha = 128)
                    brush.Color = Color.FromArgb(128, Color.Blue);
                }
            }

            // Configure rendering options to interpret mask operations as opacity
            RenderingOptions renderingOpts = new RenderingOptions();
            renderingOpts.InkOptions.InterpretMaskOpAsOpacity = true;

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}