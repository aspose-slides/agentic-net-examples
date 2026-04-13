using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the last slide (the presentation initially contains one slide)
            Aspose.Slides.ISlide lastSlide = presentation.Slides[presentation.Slides.Count - 1];

            // Add a rectangle shape that will contain the footnote text
            Aspose.Slides.IAutoShape footnoteShape = lastSlide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                50, 400, 500, 30);

            // Ensure the shape has a text frame
            footnoteShape.AddTextFrame(" ");

            // Access the text frame
            Aspose.Slides.ITextFrame textFrame = footnoteShape.TextFrame;

            // Clear any default paragraphs
            textFrame.Paragraphs.Clear();

            // Create a paragraph for the footnote
            Aspose.Slides.IParagraph footnoteParagraph = new Aspose.Slides.Paragraph();

            // Normal portion (e.g., "Reference")
            Aspose.Slides.IPortion normalPortion = new Aspose.Slides.Portion();
            normalPortion.Text = "Reference";
            footnoteParagraph.Portions.Add(normalPortion);

            // Subscript portion (e.g., "1")
            Aspose.Slides.IPortion subscriptPortion = new Aspose.Slides.Portion();
            subscriptPortion.Text = "1";
            // Set Escapement to a negative value to render as subscript
            subscriptPortion.PortionFormat.Escapement = -0.5f;
            footnoteParagraph.Portions.Add(subscriptPortion);

            // Add the paragraph to the text frame
            textFrame.Paragraphs.Add(footnoteParagraph);

            // Save the presentation
            string outPath = "SubscriptFootnote_out.pptx";
            presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Open the saved file
            Process.Start(new ProcessStartInfo(outPath) { UseShellExecute = true });
        }
    }
}