using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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
        mathParagraph.Add(new MathBlock(new MathematicalText("x")));
        mathParagraph.Add(new MathBlock(new MathematicalText("y")));

        // Iterate over each math block and attempt to write it as MathML
        for (int i = 0; i < mathParagraph.Count; i++)
        {
            Aspose.Slides.MathText.IMathBlock block = mathParagraph[i];
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    block.WriteAsMathMl(stream);
                    // Example: save each block's MathML to a separate file
                    string fileName = "block_" + i + ".xml";
                    File.WriteAllBytes(fileName, stream.ToArray());
                }
            }
            catch (NotSupportedException)
            {
                // Skip this block if MathML export is not supported
                continue;
            }
        }

        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}