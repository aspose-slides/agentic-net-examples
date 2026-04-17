using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a math shape to the first slide
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Add sample math blocks
        mathParagraph.Add(new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("x")));
        mathParagraph.Add(new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("y")));

        // Iterate over each MathBlock and attempt to write it as MathML, skipping unsupported blocks
        for (int i = 0; i < mathParagraph.Count; i++)
        {
            Aspose.Slides.MathText.IMathBlock block = mathParagraph[i];
            try
            {
                using (FileStream fileStream = new FileStream($"Block{i}.xml", FileMode.Create, FileAccess.Write))
                {
                    block.WriteAsMathMl(fileStream);
                }
            }
            catch (NotSupportedException)
            {
                // Skip this block if MathML export is not supported
                continue;
            }
        }

        // Save the presentation
        presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
    }
}