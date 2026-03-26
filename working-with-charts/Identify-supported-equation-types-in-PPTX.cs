using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace IdentifySupportedEquationTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a math shape to host mathematical content
            Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0f, 0f, 720f, 150f);

            // Retrieve the math paragraph from the first portion (MathPortion)
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Create a fraction using MathematicalText.Divide (returns IMathFraction)
            Aspose.Slides.MathText.IMathFraction fraction = new Aspose.Slides.MathText.MathematicalText("x").Divide("y");

            // Add the fraction to the math paragraph
            mathParagraph.Add(new Aspose.Slides.MathText.MathBlock(fraction));

            // List all supported MathFractionTypes (fraction styles) in the console
            Console.WriteLine("Supported MathFractionTypes:");
            foreach (Aspose.Slides.MathText.MathFractionTypes type in Enum.GetValues(typeof(Aspose.Slides.MathText.MathFractionTypes)))
            {
                Console.WriteLine("- " + type);
            }

            // Save the presentation (required before exiting)
            presentation.Save("SupportedEquations.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}