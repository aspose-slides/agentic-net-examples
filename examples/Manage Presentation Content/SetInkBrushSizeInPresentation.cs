using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.ppt";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Get the first shape on the first slide and cast it to an Ink object
        Aspose.Slides.Ink.IInk ink = (Aspose.Slides.Ink.IInk)pres.Slides[0].Shapes[0];

        // Retrieve the ink traces
        Aspose.Slides.Ink.IInkTrace[] traces = ink.Traces;

        // Get the brush of the first trace and set its size
        Aspose.Slides.Ink.InkBrush brush = (Aspose.Slides.Ink.InkBrush)traces[0].Brush;
        brush.Size = new SizeF(5f, 10f);

        // Save the modified presentation in PPT format
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);

        // Release resources
        pres.Dispose();
    }
}