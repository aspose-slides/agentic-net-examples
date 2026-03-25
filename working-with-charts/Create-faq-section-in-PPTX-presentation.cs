using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle shape to hold the FAQ
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 400);
            shape.AddTextFrame("");
            shape.TextFrame.Paragraphs[0].Portions.Clear();

            // FAQ data
            string[] questions = new string[]
            {
                "What is Aspose.Slides?",
                "How do I add a shape?"
            };
            string[] answers = new string[]
            {
                "Aspose.Slides is a .NET library for creating, modifying, and converting PowerPoint files.",
                "Use Slides[0].Shapes.AddAutoShape method with the desired ShapeType."
            };

            // Add formatted question and answer portions
            for (int i = 0; i < questions.Length; i++)
            {
                // Question (bold, larger font)
                Aspose.Slides.IPortion questionPortion = new Aspose.Slides.Portion(questions[i] + "\n");
                questionPortion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
                questionPortion.PortionFormat.FontHeight = 24;
                shape.TextFrame.Paragraphs[0].Portions.Add(questionPortion);

                // Answer (regular, slightly smaller font)
                Aspose.Slides.IPortion answerPortion = new Aspose.Slides.Portion(answers[i] + "\n\n");
                answerPortion.PortionFormat.FontBold = Aspose.Slides.NullableBool.False;
                answerPortion.PortionFormat.FontHeight = 20;
                shape.TextFrame.Paragraphs[0].Portions.Add(answerPortion);
            }

            // Save the presentation
            string outputPath = "FAQPresentation_out.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine("Input file not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}