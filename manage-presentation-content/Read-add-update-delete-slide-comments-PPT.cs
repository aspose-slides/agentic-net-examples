using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideCommentsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string addOutputPath = "added_comments.pptx";
            string updateOutputPath = "updated_comments.pptx";
            string deleteOutputPath = "deleted_comments.pptx";

            // Ensure input file exists before proceeding
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Read existing comments
            ReadComments(inputPath);

            // Add a new comment
            AddComment(inputPath, addOutputPath);

            // Update the first comment's text
            UpdateComment(addOutputPath, updateOutputPath);

            // Delete the first comment
            DeleteComment(updateOutputPath, deleteOutputPath);
        }

        static void ReadComments(string filePath)
        {
            using (Presentation presentation = new Presentation(filePath))
            {
                Console.WriteLine("Reading comments from: " + filePath);
                foreach (object authorObj in presentation.CommentAuthors)
                {
                    CommentAuthor author = (CommentAuthor)authorObj;
                    foreach (object commentObj in author.Comments)
                    {
                        Comment comment = (Comment)commentObj;
                        Console.WriteLine("Slide " + comment.Slide.SlideNumber + ": " + comment.Text + " (Author: " + comment.Author.Name + ")");
                    }
                }
                // Presentation will be disposed automatically by using
            }
        }

        static void AddComment(string inputFile, string outputFile)
        {
            using (Presentation presentation = new Presentation(inputFile))
            {
                // Ensure there is at least one slide
                if (presentation.Slides.Count == 0)
                {
                    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                }

                // Add a new author
                ICommentAuthor author = presentation.CommentAuthors.AddAuthor("New Author", "NA");

                // Define comment position
                PointF position = new PointF(0.2f, 0.2f);

                // Add comment to the first slide
                author.Comments.AddComment("This is a newly added comment.", presentation.Slides[0], position, DateTime.Now);

                // Save the presentation
                presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }

        static void UpdateComment(string inputFile, string outputFile)
        {
            using (Presentation presentation = new Presentation(inputFile))
            {
                // Find the first comment across all authors
                Comment firstComment = null;
                foreach (object authorObj in presentation.CommentAuthors)
                {
                    CommentAuthor author = (CommentAuthor)authorObj;
                    foreach (object commentObj in author.Comments)
                    {
                        firstComment = (Comment)commentObj;
                        break;
                    }
                    if (firstComment != null) break;
                }

                if (firstComment != null)
                {
                    // Update the comment text
                    firstComment.Text = "Updated comment text.";
                }
                else
                {
                    Console.WriteLine("No comment found to update.");
                }

                // Save the presentation
                presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }

        static void DeleteComment(string inputFile, string outputFile)
        {
            using (Presentation presentation = new Presentation(inputFile))
            {
                // Find the first comment across all authors
                Comment commentToDelete = null;
                foreach (object authorObj in presentation.CommentAuthors)
                {
                    CommentAuthor author = (CommentAuthor)authorObj;
                    foreach (object commentObj in author.Comments)
                    {
                        commentToDelete = (Comment)commentObj;
                        break;
                    }
                    if (commentToDelete != null) break;
                }

                if (commentToDelete != null)
                {
                    // Remove the comment (and its replies if any)
                    commentToDelete.Remove();
                }
                else
                {
                    Console.WriteLine("No comment found to delete.");
                }

                // Save the presentation
                presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}