using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape to hold the text
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

                // Access the text frame of the shape and clear any default paragraphs
                Aspose.Slides.ITextFrame textFrame = shape.TextFrame;
                textFrame.Paragraphs.Clear();

                // Create a paragraph for superscript text (e.g., E = mc²)
                Aspose.Slides.IParagraph superPar = new Aspose.Slides.Paragraph();

                // Base text "E = mc"
                Aspose.Slides.IPortion basePortion = new Aspose.Slides.Portion();
                basePortion.Text = "E = mc";
                superPar.Portions.Add(basePortion);

                // Superscript "2"
                Aspose.Slides.IPortion superscriptPortion = new Aspose.Slides.Portion();
                superscriptPortion.PortionFormat.Escapement = 100; // 100% = superscript
                superscriptPortion.Text = "2";
                superPar.Portions.Add(superscriptPortion);

                // Create a paragraph for subscript text (e.g., H₂O)
                Aspose.Slides.IParagraph subPar = new Aspose.Slides.Paragraph();

                // Base text "H"
                Aspose.Slides.IPortion basePortion2 = new Aspose.Slides.Portion();
                basePortion2.Text = "H";
                subPar.Portions.Add(basePortion2);

                // Subscript "2"
                Aspose.Slides.IPortion subscriptPortion = new Aspose.Slides.Portion();
                subscriptPortion.PortionFormat.Escapement = -100; // -100% = subscript
                subscriptPortion.Text = "2";
                subPar.Portions.Add(subscriptPortion);

                // Add both paragraphs to the text frame
                textFrame.Paragraphs.Add(superPar);
                textFrame.Paragraphs.Add(subPar);

                // Save the presentation
                string outPath = "SuperscriptSubscript_out.pptx";
                presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Open the generated file
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outPath) { UseShellExecute = true });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}