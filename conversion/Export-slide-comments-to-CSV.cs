using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideCommentsExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string outputCsvPath = "comments.csv";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Prepare CSV writer
                using (StreamWriter writer = new StreamWriter(outputCsvPath, false, Encoding.UTF8))
                {
                    // Write CSV header
                    writer.WriteLine("Author,Timestamp,Comment");

                    // Iterate over comment authors
                    foreach (object commentAuthorObj in presentation.CommentAuthors)
                    {
                        Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)commentAuthorObj;

                        // Iterate over comments of the author
                        foreach (object commentObj in author.Comments)
                        {
                            Aspose.Slides.Comment comment = (Aspose.Slides.Comment)commentObj;

                            // Escape commas in comment text
                            string escapedText = comment.Text.Replace("\"", "\"\"");
                            escapedText = "\"" + escapedText + "\"";

                            // Write CSV line
                            writer.WriteLine($"{author.Name},{comment.CreatedTime},{escapedText}");
                        }
                    }
                }

                // Save presentation before exit (no modifications made)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose presentation
                presentation.Dispose();

                Console.WriteLine("Comments exported to CSV successfully.");
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment (if applicable)
                // // Format not supported.
            }
        }
    }
}