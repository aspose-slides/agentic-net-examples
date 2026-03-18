using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to hold the FAQ text
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 400);
            shape.AddTextFrame("FAQ");
            shape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

            // Define questions and answers
            string[] questions = { "What is Aspose.Slides?", "How do I add text?" };
            string[] answers = { "A library for PowerPoint manipulation.", "Use IAutoShape.AddTextFrame and modify portions." };

            for (int i = 0; i < questions.Length; i++)
            {
                // Question paragraph
                Aspose.Slides.Paragraph qParagraph = new Aspose.Slides.Paragraph();
                Aspose.Slides.Portion qPortion = new Aspose.Slides.Portion(questions[i]);
                qPortion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
                qPortion.PortionFormat.FontHeight = 24f;
                qParagraph.Portions.Add(qPortion);
                shape.TextFrame.Paragraphs.Add(qParagraph);

                // Answer paragraph
                Aspose.Slides.Paragraph aParagraph = new Aspose.Slides.Paragraph();
                Aspose.Slides.Portion aPortion = new Aspose.Slides.Portion(answers[i]);
                aPortion.PortionFormat.FontHeight = 18f;
                aParagraph.Portions.Add(aPortion);
                shape.TextFrame.Paragraphs.Add(aParagraph);
            }

            // Save the presentation
            presentation.Save("FAQ.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}