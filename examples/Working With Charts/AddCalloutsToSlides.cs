using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape that will act as a callout
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);

        // Access the text frame of the shape
        Aspose.Slides.ITextFrame textFrame = shape.TextFrame;
        textFrame.Paragraphs.Clear();

        // Create a paragraph with superscript text
        Aspose.Slides.IParagraph superPar = new Aspose.Slides.Paragraph();
        Aspose.Slides.IPortion portion1 = new Aspose.Slides.Portion();
        portion1.Text = "Title";
        superPar.Portions.Add(portion1);
        Aspose.Slides.IPortion superPortion = new Aspose.Slides.Portion();
        superPortion.PortionFormat.Escapement = 10000; // superscript
        superPortion.Text = "TM";
        superPar.Portions.Add(superPortion);

        // Create a paragraph with subscript text
        Aspose.Slides.IParagraph subPar = new Aspose.Slides.Paragraph();
        Aspose.Slides.IPortion portion2 = new Aspose.Slides.Portion();
        portion2.Text = "A";
        subPar.Portions.Add(portion2);
        Aspose.Slides.IPortion subPortion = new Aspose.Slides.Portion();
        subPortion.PortionFormat.Escapement = -5000; // subscript
        subPortion.Text = "i";
        subPar.Portions.Add(subPortion);

        // Add the paragraphs to the text frame
        textFrame.Paragraphs.Add(superPar);
        textFrame.Paragraphs.Add(subPar);

        // Save the presentation
        string outPath = "AddCallouts.pptx";
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Open the generated file
        Process.Start(new ProcessStartInfo(outPath) { UseShellExecute = true });
    }
}