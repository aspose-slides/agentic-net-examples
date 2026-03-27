using System;
using System.IO;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Aspose.Slides.Presentation pres;
        if (File.Exists(inputPath))
        {
            pres = new Aspose.Slides.Presentation(inputPath);
        }
        else
        {
            pres = new Aspose.Slides.Presentation();
            pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
            pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
        }

        Aspose.Slides.ICommentAuthor author = pres.CommentAuthors.AddAuthor("John Doe", "JD");
        System.Drawing.PointF position = new System.Drawing.PointF(0.2f, 0.2f);

        for (int i = 0; i < pres.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = pres.Slides[i];
            string commentText = $"Comment for slide {i + 1}";
            author.Comments.AddComment(commentText, slide, position, DateTime.Now);
        }

        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}