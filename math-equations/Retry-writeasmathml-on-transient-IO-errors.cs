using System;
using System.IO;
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a math shape to the first slide
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Add a simple fraction to the paragraph
        Aspose.Slides.MathText.MathBlock fraction = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("x").Divide("y"));
        mathParagraph.Add(fraction);

        // Write MathML to a file with retry logic for transient I/O errors
        string mathMlPath = "mathml.xml";
        int maxRetries = 3;
        int attempt = 0;
        bool success = false;
        while (attempt < maxRetries && !success)
        {
            try
            {
                using (FileStream stream = new FileStream(mathMlPath, FileMode.Create, FileAccess.Write))
                {
                    mathParagraph.WriteAsMathMl(stream);
                }
                success = true;
            }
            catch (IOException)
            {
                attempt++;
                if (attempt >= maxRetries)
                {
                    Console.WriteLine("Failed to write MathML after multiple attempts.");
                }
                else
                {
                    Thread.Sleep(500); // Wait before retrying
                }
            }
        }

        // Save the presentation
        try
        {
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported.");
        }
        finally
        {
            presentation.Dispose();
        }
    }
}