using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a Math shape to host the equation
            Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(0, 0, 500, 50);

            // Retrieve the MathParagraph from the shape
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Create a MathBlock (e.g., "x+y") and add it to the paragraph
            Aspose.Slides.MathText.MathBlock mathBlock = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("x+y"));
            mathParagraph.Add(mathBlock);

            // Export the MathParagraph (which contains the MathBlock) to MathML using a MemoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                mathParagraph.WriteAsMathMl(memoryStream);
                memoryStream.Position = 0;
                using (StreamReader reader = new StreamReader(memoryStream))
                {
                    string mathMl = reader.ReadToEnd();
                    Console.WriteLine("MathML Output:");
                    Console.WriteLine(mathMl);
                }
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other exceptions
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}