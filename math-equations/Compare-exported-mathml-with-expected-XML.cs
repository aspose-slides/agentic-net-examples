using System;
using System.IO;
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

        // Get the MathParagraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build the formula a + b = c
        mathParagraph.Add(
            new Aspose.Slides.MathText.MathematicalText("a")
                .Join("+")
                .Join(
                    new Aspose.Slides.MathText.MathematicalText("b")
                        .Join("=")
                        .Join(new Aspose.Slides.MathText.MathematicalText("c"))
                )
        );

        // Export MathML to a memory stream
        System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
        mathParagraph.WriteAsMathMl(memoryStream);
        memoryStream.Position = 0;
        System.IO.StreamReader reader = new System.IO.StreamReader(memoryStream);
        string actualMathMl = reader.ReadToEnd();

        // Expected MathML (simplified representation)
        string expectedMathMl = "<math xmlns=\"http://www.w3.org/1998/Math/MathML\"><mrow><mi>a</mi><mo>+</mo><mi>b</mi><mo>=</mo><mi>c</mi></mrow></math>";

        // Compare the exported MathML with the expected XML
        if (actualMathMl.Trim() == expectedMathMl.Trim())
        {
            Console.WriteLine("Test passed.");
        }
        else
        {
            Console.WriteLine("Test failed.");
            Console.WriteLine("Expected: " + expectedMathMl);
            Console.WriteLine("Actual:   " + actualMathMl);
        }

        // Save the presentation before exiting
        presentation.Save("MathTest.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}