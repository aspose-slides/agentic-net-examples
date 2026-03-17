using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideCommentsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = "sample.pptx";

                // Add a comment
                AddComment(filePath, "John Doe", "JD", "This is a new comment.", 0, 0.2f, 0.2f);

                // Read comments
                ReadComments(filePath);

                // Update a comment
                UpdateComment(filePath, "John Doe", 0, "This is a new comment.", "Updated comment text.");

                // Delete a comment
                DeleteComment(filePath, "John Doe", 0, "Updated comment text.");

                // Final read to confirm deletion
                ReadComments(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void ReadComments(string filePath)
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
            {
                foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)
                {
                    foreach (Aspose.Slides.IComment comment in author.Comments)
                    {
                        Console.WriteLine($"Slide {comment.Slide.SlideNumber}: \"{comment.Text}\" (Author: {author.Name})");
                    }
                }
            }
        }

        static void AddComment(string filePath, string authorName, string authorInitials, string text, int slideIndex, float posX, float posY)
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
            {
                Aspose.Slides.ICommentAuthor targetAuthor = null;
                foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)
                {
                    if (author.Name == authorName)
                    {
                        targetAuthor = author;
                        break;
                    }
                }

                if (targetAuthor == null)
                {
                    targetAuthor = presentation.CommentAuthors.AddAuthor(authorName, authorInitials);
                }

                System.Drawing.PointF position = new System.Drawing.PointF(posX, posY);
                targetAuthor.Comments.AddComment(text, presentation.Slides[slideIndex], position, DateTime.Now);

                presentation.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }

        static void UpdateComment(string filePath, string authorName, int slideIndex, string oldText, string newText)
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
            {
                foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)
                {
                    if (author.Name == authorName)
                    {
                        foreach (Aspose.Slides.IComment comment in author.Comments)
                        {
                            if (comment.Slide.SlideNumber == slideIndex + 1 && comment.Text == oldText)
                            {
                                comment.Text = newText;
                                break;
                            }
                        }
                    }
                }

                presentation.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }

        static void DeleteComment(string filePath, string authorName, int slideIndex, string text)
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
            {
                foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)
                {
                    if (author.Name == authorName)
                    {
                        foreach (Aspose.Slides.IComment comment in author.Comments)
                        {
                            if (comment.Slide.SlideNumber == slideIndex + 1 && comment.Text == text)
                            {
                                comment.Remove();
                                break;
                            }
                        }
                    }
                }

                presentation.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}