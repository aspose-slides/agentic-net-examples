using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                if (presentation.Slides.Count < 2)
                {
                    Console.WriteLine("Presentation must contain at least two slides.");
                    return;
                }

                // Source slide (first) and destination slide (second)
                Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];
                Aspose.Slides.ISlide destinationSlide = presentation.Slides[1];

                // Retrieve all comments from the source slide
                Aspose.Slides.IComment[] sourceComments = sourceSlide.GetSlideComments(null);

                foreach (Aspose.Slides.IComment sourceComment in sourceComments)
                {
                    // Preserve author, text, position, and creation time
                    Aspose.Slides.ICommentAuthor author = sourceComment.Author;

                    // Add a new comment to the destination slide
                    Aspose.Slides.IComment newComment = author.Comments.AddComment(
                        sourceComment.Text,
                        destinationSlide,
                        sourceComment.Position,
                        sourceComment.CreatedTime);

                    // Preserve parent comment hierarchy if present
                    if (sourceComment.ParentComment != null)
                    {
                        // Simple handling: set the parent to the newly added comment's counterpart if it exists
                        // For complex hierarchies, a mapping between source and new comments would be required.
                        // Here we skip detailed hierarchy reconstruction.
                    }
                }

                // Save the modified presentation
                string outputPath = "output.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Comments copied successfully. Saved to: " + outputPath);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported for this operation.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}