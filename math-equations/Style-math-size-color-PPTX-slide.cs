using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace StyledMathExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Add a mathematical shape to the first slide
                Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(50f, 50f, 500f, 50f);

                // Retrieve the math paragraph from the shape
                Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Create formatted mathematical text elements
                Aspose.Slides.MathText.IMathematicalText aText = new Aspose.Slides.MathText.MathematicalText("a");
                aText.Format.FontHeight = 32f;
                aText.Format.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                aText.Format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

                Aspose.Slides.MathText.IMathematicalText bText = new Aspose.Slides.MathText.MathematicalText("b");
                bText.Format.FontHeight = 32f;
                bText.Format.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                bText.Format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Green;

                Aspose.Slides.MathText.IMathematicalText cText = new Aspose.Slides.MathText.MathematicalText("c");
                cText.Format.FontHeight = 32f;
                cText.Format.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cText.Format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

                // Build the mathematical block: a + b = c
                Aspose.Slides.MathText.IMathBlock mathBlock = new Aspose.Slides.MathText.MathBlock(aText)
                    .Join(new Aspose.Slides.MathText.MathematicalText("+"))
                    .Join(bText)
                    .Join(new Aspose.Slides.MathText.MathematicalText("="))
                    .Join(cText);

                // Add the block to the paragraph
                mathParagraph.Add(mathBlock);

                // Save the presentation
                pres.Save("StyledMath.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}