using System;
using System.IO;
using Aspose.Slides.Export;

namespace FAQPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // FAQ data
            string[] questions = new string[] { "What is Aspose.Slides?", "How to create a presentation?" };
            string[] answers = new string[] { "A .NET library for working with PowerPoint files.", "Instantiate the Presentation class and add slides." };

            for (int i = 0; i < questions.Length; i++)
            {
                // Use the first slide or add a new one
                Aspose.Slides.ISlide slide;
                if (i == 0)
                {
                    slide = presentation.Slides[0];
                }
                else
                {
                    slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                }

                // Add a textbox shape
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 400);
                shape.TextFrame.Text = "";

                // Add question paragraph
                Aspose.Slides.Paragraph questionParagraph = new Aspose.Slides.Paragraph();
                Aspose.Slides.Portion questionPortion = new Aspose.Slides.Portion("Q: " + questions[i]);
                questionParagraph.Portions.Add(questionPortion);
                shape.TextFrame.Paragraphs.Add(questionParagraph);

                // Add answer paragraph
                Aspose.Slides.Paragraph answerParagraph = new Aspose.Slides.Paragraph();
                Aspose.Slides.Portion answerPortion = new Aspose.Slides.Portion("A: " + answers[i]);
                answerParagraph.Portions.Add(answerPortion);
                shape.TextFrame.Paragraphs.Add(answerParagraph);
            }

            // Save the presentation
            string outputPath = "FAQPresentation.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}