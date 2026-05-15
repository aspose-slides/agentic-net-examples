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
        using (Presentation presentation = new Presentation())
        {
            // Add a math shape to the first slide
            IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
            IMathParagraph mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

            // Build a simple math block: x + y
            MathBlock mathBlock = new MathBlock();
            mathBlock.Add(new MathematicalText("x"));
            mathBlock.Add(new MathematicalText("+"));
            mathBlock.Add(new MathematicalText("y"));
            mathParagraph.Add(mathBlock);

            // Write the math block as MathML to a file, ensuring the stream is closed
            string outputPath = "mathml_output.xml";
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
                mathBlock.WriteAsMathMl(fileStream);
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

            // Save the presentation before exiting
            presentation.Save("math_presentation.pptx", SaveFormat.Pptx);
        }
    }
}