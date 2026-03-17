using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;
using System.Drawing;

public class Program
{
    public static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Assume the first shape on the first slide is an Ink shape
            Aspose.Slides.IShape shape = presentation.Slides[0].Shapes[0];
            Aspose.Slides.Ink.IInk ink = shape as Aspose.Slides.Ink.IInk;

            if (ink != null)
            {
                // Modify the first trace's brush color to red
                Aspose.Slides.Ink.IInkTrace[] traces = ink.Traces;
                if (traces.Length > 0)
                {
                    Aspose.Slides.Ink.IInkBrush brush = traces[0].Brush;
                    brush.Color = Color.Red;
                }

                // Remove the Ink shape from the slide (demonstrating removal)
                presentation.Slides[0].Shapes.Remove(shape);
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}