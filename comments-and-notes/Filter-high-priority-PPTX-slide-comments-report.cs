using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CommentFilterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all comment authors
                foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)
                {
                    // Iterate through each comment of the current author
                    foreach (Aspose.Slides.IComment comment in author.Comments)
                    {
                        // Filter high‑priority comments (example: text contains "[High]")
                        if (comment.Text != null && comment.Text.Contains("[High]"))
                        {
                            // Generate report entry
                            Console.WriteLine("Slide {0}: {1} (Author: {2})",
                                comment.Slide.SlideNumber,
                                comment.Text,
                                author.Name);
                        }
                    }
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}