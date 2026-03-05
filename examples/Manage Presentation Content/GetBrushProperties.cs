using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Assume the first shape is an Ink shape
        Aspose.Slides.Ink.IInk ink = slide.Shapes[0] as Aspose.Slides.Ink.IInk;
        if (ink != null)
        {
            // Get all ink traces
            Aspose.Slides.Ink.IInkTrace[] traces = ink.Traces;
            if (traces.Length > 0)
            {
                // Get the brush of the first trace
                Aspose.Slides.Ink.IInkBrush brush = traces[0].Brush;

                // Display current brush properties
                Console.WriteLine("Current Brush Color: " + brush.Color.ToString());
                Console.WriteLine("Current Brush Size: " + brush.Size.ToString());
                Console.WriteLine("Ink Effect: " + brush.InkEffect.ToString());

                // Modify brush properties
                brush.Color = Color.Red;
                brush.Size = new SizeF(5f, 5f);
            }
        }

        // Save the modified presentation
        pres.Save(outputPath, SaveFormat.Pptx);
        pres.Dispose();
    }
}