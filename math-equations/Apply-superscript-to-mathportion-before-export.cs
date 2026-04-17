using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "math_superscript.pptx";

            // Delete existing file if it exists
            if (File.Exists(outputPath))
            {
                try
                {
                    File.Delete(outputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to delete existing file: " + ex.Message);
                }
            }

            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Add a math shape to the first slide
                    IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 400, 100);

                    // Retrieve the math paragraph from the first portion
                    IMathParagraph mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

                    // Create a superscript element: "c" with superscript "2"
                    IMathSuperscriptElement superscriptElement = new MathematicalText("c").SetSuperscript("2");

                    // Wrap the superscript element in a MathBlock
                    MathBlock superscriptBlock = new MathBlock(superscriptElement);

                    // Add the block to the math paragraph
                    mathParagraph.Add(superscriptBlock);

                    // Save the presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}