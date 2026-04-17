using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Add a math shape to the first slide
            Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0f, 0f, 300f, 50f);

            // Retrieve the math paragraph from the first portion
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Create a phantom element (base element "x") and wrap it in a MathBlock
            Aspose.Slides.MathText.IMathElement baseElement = new Aspose.Slides.MathText.MathematicalText("x");
            Aspose.Slides.MathText.MathPhantom phantom = new Aspose.Slides.MathText.MathPhantom(baseElement);
            Aspose.Slides.MathText.MathBlock phantomBlock = new Aspose.Slides.MathText.MathBlock(phantom);
            mathParagraph.Add(phantomBlock);

            // Add a normal math block with content "y"
            Aspose.Slides.MathText.MathBlock normalBlock = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("y"));
            mathParagraph.Add(normalBlock);

            // Diagnostic: write each MathML block to the console
            foreach (Aspose.Slides.MathText.IMathBlock block in mathParagraph)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    block.WriteAsMathMl(ms);
                    ms.Position = 0;
                    using (StreamReader reader = new StreamReader(ms))
                    {
                        string mathMl = reader.ReadToEnd();
                        Console.WriteLine("MathML:");
                        Console.WriteLine(mathMl);
                    }
                }
            }

            // Save the presentation, handling unsupported format exceptions
            try
            {
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
        }
    }
}