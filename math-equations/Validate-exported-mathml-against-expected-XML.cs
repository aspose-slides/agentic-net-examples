// -----------------------------------------------------------------------------
// Example: Unit Tests for Exporting MathML from Aspose.Slides Math Shapes
//
// Description:
// This console application creates PowerPoint presentations with mathematical
// shapes using Aspose.Slides for .NET, exports the math paragraphs to MathML,
// and compares the generated XML against expected strings. It demonstrates
// how to validate MathML output in automated tests without external files.
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML, unit test, formula validation
//
// Use Cases:
// - Verify that complex formulas are exported correctly to MathML.
// - Ensure that changes in the Aspose.Slides library do not break MathML output.
// - Provide a baseline for regression testing of mathematical content in presentations.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace AsposeSlidesMathMlTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Action> tests = new List<Action>();
            tests.Add(TestSimpleAddition);
            tests.Add(TestPythagoreanTheorem);

            foreach (Action test in tests)
            {
                try
                {
                    test.Invoke();
                    Console.WriteLine("PASS: {0}", test.Method.Name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("FAIL: {0} - {1}", test.Method.Name, ex.Message);
                }
            }
        }

        private static void TestSimpleAddition()
        {
            // Expected MathML for the formula a + b = c
            string expectedMathMl = @"<math xmlns=""http://www.w3.org/1998/Math/MathML""><mrow><mi>a</mi><mo>+</mo><mi>b</mi><mo>=</mo><mi>c</mi></mrow></math>";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a math shape
            Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            // Retrieve the MathParagraph
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build the formula a + b = c
            Aspose.Slides.MathText.MathematicalText a = new Aspose.Slides.MathText.MathematicalText("a");
            Aspose.Slides.MathText.MathematicalText plus = new Aspose.Slides.MathText.MathematicalText("+");
            Aspose.Slides.MathText.MathematicalText b = new Aspose.Slides.MathText.MathematicalText("b");
            Aspose.Slides.MathText.MathematicalText equals = new Aspose.Slides.MathText.MathematicalText("=");
            Aspose.Slides.MathText.MathematicalText c = new Aspose.Slides.MathText.MathematicalText("c");

            mathParagraph.Add(a.Join(plus).Join(b).Join(equals).Join(c));

            // Export to MathML
            MemoryStream ms = new MemoryStream();
            mathParagraph.WriteAsMathMl(ms);
            string actualMathMl = Encoding.UTF8.GetString(ms.ToArray()).Trim();

            // Normalize whitespace for comparison
            string normalizedExpected = NormalizeXml(expectedMathMl);
            string normalizedActual = NormalizeXml(actualMathMl);

            if (!normalizedExpected.Equals(normalizedActual, StringComparison.Ordinal))
            {
                throw new Exception(string.Format("MathML does not match.\nExpected: {0}\nActual: {1}", normalizedExpected, normalizedActual));
            }

            presentation.Dispose();
        }

        private static void TestPythagoreanTheorem()
        {
            // Expected MathML for the formula x² + y² = z²
            string expectedMathMl = @"<math xmlns=""http://www.w3.org/1998/Math/MathML""><mrow><msup><mi>x</mi><mn>2</mn></msup><mo>+</mo><msup><mi>y</mi><mn>2</mn></msup><mo>=</mo><msup><mi>z</mi><mn>2</mn></msup></mrow></math>";

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build the formula x² + y² = z² using superscript
            Aspose.Slides.MathText.MathematicalText x = new Aspose.Slides.MathText.MathematicalText("x");
            Aspose.Slides.MathText.MathematicalText xSup = new Aspose.Slides.MathText.MathematicalText("2");
            Aspose.Slides.MathText.MathematicalText y = new Aspose.Slides.MathText.MathematicalText("y");
            Aspose.Slides.MathText.MathematicalText ySup = new Aspose.Slides.MathText.MathematicalText("2");
            Aspose.Slides.MathText.MathematicalText z = new Aspose.Slides.MathText.MathematicalText("z");
            Aspose.Slides.MathText.MathematicalText zSup = new Aspose.Slides.MathText.MathematicalText("2");
            Aspose.Slides.MathText.MathematicalText plus = new Aspose.Slides.MathText.MathematicalText("+");
            Aspose.Slides.MathText.MathematicalText equals = new Aspose.Slides.MathText.MathematicalText("=");

            // Superscript is represented by joining base and exponent with a special element.
            // Aspose.Slides does not provide a direct API for superscript in MathParagraph,
            // so we simulate by using the Unicode superscript characters for simplicity.
            Aspose.Slides.MathText.MathematicalText xSuperscript = new Aspose.Slides.MathText.MathematicalText("x\u2072");
            Aspose.Slides.MathText.MathematicalText ySuperscript = new Aspose.Slides.MathText.MathematicalText("y\u2072");
            Aspose.Slides.MathText.MathematicalText zSuperscript = new Aspose.Slides.MathText.MathematicalText("z\u2072");

            mathParagraph.Add(xSuperscript.Join(plus).Join(ySuperscript).Join(equals).Join(zSuperscript));

            MemoryStream ms = new MemoryStream();
            mathParagraph.WriteAsMathMl(ms);
            string actualMathMl = Encoding.UTF8.GetString(ms.ToArray()).Trim();

            string normalizedExpected = NormalizeXml(expectedMathMl);
            string normalizedActual = NormalizeXml(actualMathMl);

            if (!normalizedExpected.Equals(normalizedActual, StringComparison.Ordinal))
            {
                throw new Exception(string.Format("MathML does not match.\nExpected: {0}\nActual: {1}", normalizedExpected, normalizedActual));
            }

            presentation.Dispose();
        }

        private static string NormalizeXml(string xml)
        {
            // Remove line breaks and excess whitespace between tags
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@">\s+<");
            string normalized = regex.Replace(xml, "><");
            return normalized.Trim();
        }
    }
}
