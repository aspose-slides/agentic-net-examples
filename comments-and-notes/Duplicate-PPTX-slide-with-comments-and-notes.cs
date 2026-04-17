using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideCloneExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Presentation pres = new Presentation(inputPath);
                ISlideCollection slides = pres.Slides;

                // Clone the first slide to the end of the collection
                ISlide newSlide = slides.AddClone(slides[0]);

                // Copy comments from the source slide to the new slide
                IComment[] sourceComments = slides[0].GetSlideComments(null);
                if (sourceComments != null && sourceComments.Length > 0)
                {
                    // Ensure there is at least one author to attach comments to
                    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Author", "A");
                    foreach (IComment srcComment in sourceComments)
                    {
                        author.Comments.AddModernComment(
                            srcComment.Text,
                            newSlide,
                            null,
                            srcComment.Position,
                            DateTime.Now);
                    }
                }

                // Copy notes from the source slide to the new slide
                INotesSlideManager srcNotesMgr = slides[0].NotesSlideManager;
                INotesSlide srcNotes = srcNotesMgr.NotesSlide;
                if (srcNotes != null && srcNotes.NotesTextFrame != null)
                {
                    INotesSlideManager destNotesMgr = newSlide.NotesSlideManager;
                    INotesSlide destNotes = destNotesMgr.AddNotesSlide();
                    destNotes.NotesTextFrame.Text = srcNotes.NotesTextFrame.Text;
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
                Console.WriteLine("Slide duplicated with comments and notes successfully.");
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}