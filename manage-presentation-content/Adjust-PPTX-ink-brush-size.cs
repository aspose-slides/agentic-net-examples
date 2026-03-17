using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Access the first shape on the first slide and treat it as an Ink object
            Aspose.Slides.IShape shape = pres.Slides[0].Shapes[0];
            Aspose.Slides.Ink.Ink ink = shape as Aspose.Slides.Ink.Ink;

            if (ink != null && ink.Traces.Length > 0)
            {
                Aspose.Slides.Ink.IInkBrush brush = ink.Traces[0].Brush;
                // Adjust the brush size (width and height in points)
                brush.Size = new System.Drawing.SizeF(5f, 5f);
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}