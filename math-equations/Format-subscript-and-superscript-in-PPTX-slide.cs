using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FormatSubSuperscript
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape to host the text
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50f, 50f, 400f, 100f);

                // Access the text frame of the shape
                ITextFrame textFrame = shape.TextFrame;
                textFrame.Paragraphs.Clear();

                // Create a paragraph for superscript text
                IParagraph superParagraph = new Paragraph();

                // Normal text portion
                IPortion normalPortion = new Portion();
                normalPortion.Text = "E = mc";
                superParagraph.Portions.Add(normalPortion);

                // Superscript portion (e.g., squared)
                IPortion superscriptPortion = new Portion();
                superscriptPortion.PortionFormat.Escapement = 100f; // 100% superscript
                superscriptPortion.Text = "2";
                superParagraph.Portions.Add(superscriptPortion);

                // Create a paragraph for subscript text
                IParagraph subParagraph = new Paragraph();

                // Normal text portion
                IPortion normalPortion2 = new Portion();
                normalPortion2.Text = "H";
                subParagraph.Portions.Add(normalPortion2);

                // Subscript portion (e.g., subscript 2)
                IPortion subscriptPortion = new Portion();
                subscriptPortion.PortionFormat.Escapement = -100f; // -100% subscript
                subscriptPortion.Text = "2";
                subParagraph.Portions.Add(subscriptPortion);

                // Add paragraphs to the text frame
                textFrame.Paragraphs.Add(superParagraph);
                textFrame.Paragraphs.Add(subParagraph);

                // Save the presentation
                string outPath = "FormattedSubSuperscript.pptx";
                presentation.Save(outPath, SaveFormat.Pptx);

                // Open the generated file
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}