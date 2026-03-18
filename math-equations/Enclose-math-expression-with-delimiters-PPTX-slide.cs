using System;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Add a math shape to the first slide
                    IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0f, 0f, 720f, 150f);

                    // Retrieve the math paragraph from the first portion
                    IMathParagraph mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

                    // Create a mathematical text element
                    MathematicalText mathText = new MathematicalText("x+1");

                    // Create a math block with the text element (cast to resolve overload ambiguity)
                    MathBlock mathBlock = new MathBlock((IMathElement)mathText);

                    // Enclose the block in parentheses
                    mathBlock.Enclose();

                    // Add the block to the math paragraph
                    mathParagraph.Add(mathBlock);

                    // Save the presentation
                    presentation.Save("EnclosedMath.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}