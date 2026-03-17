using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddCommentsAndNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Ensure there is at least one slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a comment author
                Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jane Doe", "JD");

                // Define comment position
                System.Drawing.PointF commentPosition = new System.Drawing.PointF();
                commentPosition.X = 0.2f;
                commentPosition.Y = 0.2f;

                // Add a comment to the first slide
                author.Comments.AddComment("This slide introduces the core concept.", slide, commentPosition, DateTime.Now);

                // Add a modern comment (optional, demonstrates rich comment)
                Aspose.Slides.IModernComment modernComment = author.Comments.AddModernComment(
                    "Consider updating the chart colors for better contrast.",
                    slide,
                    null,
                    new System.Drawing.PointF(100, 100),
                    DateTime.Now);
                modernComment.Status = Aspose.Slides.ModernCommentStatus.Active;

                // Add notes to the slide
                Aspose.Slides.INotesSlideManager notesManager = slide.NotesSlideManager;
                Aspose.Slides.INotesSlide notesSlide = notesManager.AddNotesSlide();
                notesSlide.NotesTextFrame.Text = "Speaker notes: Explain the main points highlighted in the slide.";

                // Save the presentation
                presentation.Save("AnnotatedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}