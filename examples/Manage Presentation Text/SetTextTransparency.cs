using System;
using System.Drawing;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Paths for input and output presentations
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the existing presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add an AutoShape if none exists (for demonstration)
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);
        shape.AddTextFrame("Transparent Text");

        // Access the first portion of the first paragraph
        Aspose.Slides.IPortion portion = shape.TextFrame.Paragraphs[0].Portions[0];

        // Ensure the fill type is solid before setting the color
        portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;

        // Set the text color with 50% transparency (alpha = 128)
        portion.PortionFormat.FillFormat.SolidFillColor.Color =
            System.Drawing.Color.FromArgb(128, portion.PortionFormat.FillFormat.SolidFillColor.Color);

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}