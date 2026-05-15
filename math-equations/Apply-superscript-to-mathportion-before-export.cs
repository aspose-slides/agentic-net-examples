using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Add a math shape to the first slide
                IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

                // Retrieve the math paragraph from the first MathPortion
                IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Create base mathematical text
                IMathElement baseElement = new MathematicalText("E=mc");

                // Apply superscript to the base element
                IMathSuperscriptElement superscriptElement = baseElement.SetSuperscript("2");

                // Wrap the superscript element in a math block and add it to the paragraph
                IMathBlock mathBlock = new MathBlock(superscriptElement);
                mathParagraph.Add(mathBlock);

                // Save the presentation
                string outPath = "SuperscriptMath.pptx";
                presentation.Save(outPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + Path.GetFullPath(outPath));
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The requested file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling (e.g., file I/O, Aspose errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}