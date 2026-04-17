using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation and add a comment
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");
        author.Comments.AddComment("Sample comment", presentation.Slides[0], new PointF(0.5f, 0.5f), DateTime.Now);

        // Serialize comments to a binary file
        string binaryPath = "comments.bin";
        using (FileStream fs = new FileStream(binaryPath, FileMode.Create, FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            writer.Write(presentation.Slides.Count);
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);
                writer.Write(comments.Length);
                foreach (Aspose.Slides.IComment cmt in comments)
                {
                    writer.Write(cmt.Author.Name);
                    writer.Write(cmt.Author.Initials);
                    writer.Write(cmt.Text);
                    writer.Write(cmt.CreatedTime.Ticks);
                    writer.Write(cmt.Position.X);
                    writer.Write(cmt.Position.Y);
                }
            }
        }

        // Deserialize comments into a new presentation
        Aspose.Slides.Presentation newPresentation = new Aspose.Slides.Presentation();
        using (FileStream fs = new FileStream(binaryPath, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            int slideCount = reader.ReadInt32();
            while (newPresentation.Slides.Count < slideCount)
            {
                newPresentation.Slides.AddEmptySlide(newPresentation.LayoutSlides[0]);
            }

            for (int i = 0; i < slideCount; i++)
            {
                Aspose.Slides.ISlide slide = newPresentation.Slides[i];
                int commentCount = reader.ReadInt32();
                for (int j = 0; j < commentCount; j++)
                {
                    string authorName = reader.ReadString();
                    string authorInitials = reader.ReadString();
                    string text = reader.ReadString();
                    long ticks = reader.ReadInt64();
                    float posX = reader.ReadSingle();
                    float posY = reader.ReadSingle();

                    Aspose.Slides.ICommentAuthor desAuthor = newPresentation.CommentAuthors.AddAuthor(authorName, authorInitials);
                    desAuthor.Comments.AddComment(text, slide, new PointF(posX, posY), new DateTime(ticks));
                }
            }
        }

        // Save presentations with format handling
        try
        {
            presentation.Save("OriginalPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Error saving original presentation: " + ex.Message);
        }

        try
        {
            newPresentation.Save("ReconstructedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Error saving reconstructed presentation: " + ex.Message);
        }

        // Dispose resources
        presentation.Dispose();
        newPresentation.Dispose();
    }
}