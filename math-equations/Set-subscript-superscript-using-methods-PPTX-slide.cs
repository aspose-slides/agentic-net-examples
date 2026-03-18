using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add a math shape to host the equation
                    Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(50, 50, 400, 50);

                    // Retrieve the math paragraph from the first portion of the shape
                    Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                    // Create a base mathematical element "x"
                    Aspose.Slides.MathText.IMathElement baseElement = new Aspose.Slides.MathText.MathematicalText("x");

                    // Apply superscript "2" to the base element
                    Aspose.Slides.MathText.IMathSuperscriptElement superscriptElement = baseElement.SetSuperscript("2");

                    // Apply subscript "i" to the same base element
                    Aspose.Slides.MathText.IMathSubscriptElement subscriptElement = baseElement.SetSubscript("i");

                    // Add the superscript block to the paragraph
                    Aspose.Slides.MathText.MathBlock superscriptBlock = new Aspose.Slides.MathText.MathBlock(superscriptElement);
                    mathParagraph.Add(superscriptBlock);

                    // Add the subscript block to the paragraph
                    Aspose.Slides.MathText.MathBlock subscriptBlock = new Aspose.Slides.MathText.MathBlock(subscriptElement);
                    mathParagraph.Add(subscriptBlock);

                    // Save the presentation
                    string outPath = "SetSubSuperscriptMethods_out.pptx";
                    presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

                    // Open the generated file
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outPath) { UseShellExecute = true });
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}