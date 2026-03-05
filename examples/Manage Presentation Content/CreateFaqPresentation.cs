using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape to hold the FAQ
        Aspose.Slides.IAutoShape faqShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 400);

        // Add a text frame with a title
        faqShape.AddTextFrame("Frequently Asked Questions");

        // Access the text frame
        Aspose.Slides.ITextFrame textFrame = faqShape.TextFrame;

        // Remove the default paragraph (the title placeholder)
        textFrame.Paragraphs.RemoveAt(0);

        // First question
        Aspose.Slides.Paragraph question1 = new Aspose.Slides.Paragraph();
        question1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        question1.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226); // bullet character
        question1.Text = "What is Aspose.Slides?";
        question1.ParagraphFormat.Indent = 20;
        question1.ParagraphFormat.Bullet.Color.Color = System.Drawing.Color.Black;
        question1.ParagraphFormat.Bullet.IsBulletHardColor = Aspose.Slides.NullableBool.True;
        textFrame.Paragraphs.Add(question1);

        // Answer to first question
        Aspose.Slides.Paragraph answer1 = new Aspose.Slides.Paragraph();
        answer1.Text = "Aspose.Slides is a .NET library for creating and manipulating PowerPoint files.";
        answer1.ParagraphFormat.Indent = 40;
        textFrame.Paragraphs.Add(answer1);

        // Second question
        Aspose.Slides.Paragraph question2 = new Aspose.Slides.Paragraph();
        question2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        question2.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226);
        question2.Text = "How to add a shape?";
        question2.ParagraphFormat.Indent = 20;
        question2.ParagraphFormat.Bullet.Color.Color = System.Drawing.Color.Black;
        question2.ParagraphFormat.Bullet.IsBulletHardColor = Aspose.Slides.NullableBool.True;
        textFrame.Paragraphs.Add(question2);

        // Answer to second question
        Aspose.Slides.Paragraph answer2 = new Aspose.Slides.Paragraph();
        answer2.Text = "Use slide.Shapes.AddAutoShape with the desired ShapeType and dimensions.";
        answer2.ParagraphFormat.Indent = 40;
        textFrame.Paragraphs.Add(answer2);

        // Save the presentation before exiting
        presentation.Save("FaqPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}