using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file paths
        string presentationPath = "MathParagraphDemo.pptx";
        string mathMlPath = "MathParagraphDemo.xml";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a mathematical shape
        IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Retrieve the MathParagraph from the shape
        IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build a simple equation: a + b = c
        string a = "a";
        string plus = "+";
        string b = "b";
        string equals = "=";
        string c = "c";

        mathParagraph.Add(
            new MathematicalText(a)
                .Join(plus)
                .Join(new MathematicalText(b))
                .Join(equals)
                .Join(new MathematicalText(c))
        );

        // Export the MathParagraph to MathML using a FileStream
        FileStream mathMlStream = null;
        try
        {
            mathMlStream = new FileStream(mathMlPath, FileMode.Create);
            mathParagraph.WriteAsMathMl(mathMlStream);
        }
        finally
        {
            if (mathMlStream != null)
            {
                mathMlStream.Close();
            }
        }

        // Save the presentation (handle unsupported format)
        try
        {
            pres.Save(presentationPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Dispose the presentation
        pres.Dispose();
    }
}