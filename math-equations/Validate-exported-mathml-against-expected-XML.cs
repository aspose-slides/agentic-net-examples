using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace MathMlUnitTestApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Test for formula "a+b=c"
                string formula = "a+b=c";
                string expectedMathMl = "<math xmlns=\"http://www.w3.org/1998/Math/MathML\"><mrow><mi>a</mi><mo>+</mo><mi>b</mi><mo>=</mo><mi>c</mi></mrow></math>";
                RunMathMlTest(formula, expectedMathMl);
            }
            catch (NotSupportedException ex)
            {
                // Handle unsupported format
                Console.WriteLine("Format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static void RunMathMlTest(string formula, string expectedMathMl)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Add a math shape to the first slide
                IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0f, 0f, 400f, 100f);

                // Retrieve the math paragraph from the shape
                IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Build the math block for the formula "a+b=c"
                MathBlock mathBlock = new MathBlock();
                mathBlock.Add(new MathematicalText("a"));
                mathBlock.Add(new MathematicalText("+"));
                mathBlock.Add(new MathematicalText("b"));
                mathBlock.Add(new MathematicalText("="));
                mathBlock.Add(new MathematicalText("c"));

                // Add the block to the paragraph
                mathParagraph.Add(mathBlock);

                // Export MathML to a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    mathParagraph.WriteAsMathMl(ms);
                    ms.Position = 0;
                    StreamReader reader = new StreamReader(ms);
                    string actualMathMl = reader.ReadToEnd().Trim();

                    // Compare the exported MathML with the expected XML
                    if (!actualMathMl.Equals(expectedMathMl, StringComparison.Ordinal))
                    {
                        throw new InvalidOperationException("MathML output does not match expected value for formula '" + formula + "'.");
                    }
                }

                // Save the presentation before exiting
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "MathMlTestOutput.pptx");
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}