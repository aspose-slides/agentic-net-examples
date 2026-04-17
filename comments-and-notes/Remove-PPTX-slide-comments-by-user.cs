using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteCommentsByAuthor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Author name whose comments should be deleted
            string targetAuthorName = "John Doe";

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Find the author object matching the target name
                CommentAuthor targetAuthor = null;
                foreach (object authorObj in presentation.CommentAuthors)
                {
                    CommentAuthor author = (CommentAuthor)authorObj;
                    if (author.Name == targetAuthorName)
                    {
                        targetAuthor = author;
                        break;
                    }
                }

                if (targetAuthor != null)
                {
                    // Iterate through all slides and remove comments by the target author
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        IComment[] comments = slide.GetSlideComments(targetAuthor);
                        for (int commentIndex = 0; commentIndex < comments.Length; commentIndex++)
                        {
                            comments[commentIndex].Remove();
                        }
                    }

                    // Optionally remove the author from the collection
                    targetAuthor.Remove();
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation object
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle format not supported or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the exception is due to an unsupported format, comment accordingly
                // Format not supported.
            }
        }
    }
}