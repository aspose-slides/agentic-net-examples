using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // FAQ data
            string[] questions = new string[]
            {
                "What is Aspose.Slides?",
                "How do I add a chart?"
            };

            string[] answers = new string[]
            {
                "Aspose.Slides is a .NET library for creating and manipulating PowerPoint files.",
                "Use the Shapes.AddChart method with appropriate parameters."
            };

            // Layout settings (use float literals)
            float left = 50f;
            float top = 50f;
            float width = 600f;
            float questionHeight = 30f;
            float answerHeight = 60f;
            float verticalSpacing = 15f;

            for (int i = 0; i < questions.Length; i++)
            {
                // Add question textbox
                Aspose.Slides.IAutoShape questionShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    left,
                    top,
                    width,
                    questionHeight);
                questionShape.TextFrame.Text = questions[i];
                // Style question (bold, larger font)
                questionShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
                questionShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 18;

                // Move down for answer
                top += questionHeight + verticalSpacing;

                // Add answer textbox
                Aspose.Slides.IAutoShape answerShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    left,
                    top,
                    width,
                    answerHeight);
                answerShape.TextFrame.Text = answers[i];
                // Style answer (regular, smaller font)
                answerShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold = Aspose.Slides.NullableBool.False;
                answerShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 14;

                // Prepare top position for next question
                top += answerHeight + verticalSpacing * 2;
            }

            // Save the presentation
            presentation.Save("FaqPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}