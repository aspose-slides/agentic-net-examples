using System;
using Aspose.Slides;
using Aspose.Slides.MathText;

namespace WorkingWithCharts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape that will host the mathematical equation
            Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(0f, 0f, 720f, 150f);

            // Retrieve the MathParagraph from the first portion of the shape
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Create a MathBlock using the constructor that takes a single IMathElement to avoid ambiguity
            Aspose.Slides.MathText.MathBlock mathBlock = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("x"));

            // Add the MathBlock to the MathParagraph
            mathParagraph.Add(mathBlock);

            // Save the presentation as PDF
            presentation.Save("MathEquations.pdf", Aspose.Slides.Export.SaveFormat.Pdf);
        }
    }
}