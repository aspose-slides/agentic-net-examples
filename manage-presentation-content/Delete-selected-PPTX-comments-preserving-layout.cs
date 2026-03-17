using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCommentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source presentation
                string sourcePath = "input.pptx";
                // Path to the output presentation
                string outputPath = "output.pptx";

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath);

                // Define the author name whose comments should be removed
                string authorToRemove = "AuthorToRemove";

                // Iterate through all slides
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];

                    // Find the comment author matching the specified name
                    Aspose.Slides.ICommentAuthor matchingAuthor = null;
                    foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)
                    {
                        if (author.Name == authorToRemove)
                        {
                            matchingAuthor = author;
                            break;
                        }
                    }

                    // If the author exists, retrieve their comments on the current slide
                    if (matchingAuthor != null)
                    {
                        Aspose.Slides.IComment[] comments = slide.GetSlideComments(matchingAuthor);
                        // Remove each comment belonging to the author
                        foreach (Aspose.Slides.IComment comment in comments)
                        {
                            comment.Remove();
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}