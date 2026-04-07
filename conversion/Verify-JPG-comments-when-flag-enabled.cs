using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputJpg = "slide_1.jpg";
            string outputPres = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Add a comment author and a comment to the first slide
                    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Test Author", "TA");
                    author.Comments.AddComment(
                        "This is a test comment",
                        presentation.Slides[0],
                        new System.Drawing.PointF(0.2f, 0.2f),
                        DateTime.Now);

                    // Configure rendering options to include comments
                    RenderingOptions renderingOptions = new RenderingOptions();
                    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
                    layoutOptions.CommentsPosition = CommentsPositions.Right;
                    renderingOptions.SlidesLayoutOptions = layoutOptions;

                    // Export the first slide as JPG with comments
                    IImage image = presentation.Slides[0].GetImage(renderingOptions, 1f, 1f);
                    image.Save(outputJpg, ImageFormat.Jpeg);

                    // Save the presentation before exiting
                    presentation.Save(outputPres, SaveFormat.Pptx);
                }

                // Verify that the JPG file was created
                if (File.Exists(outputJpg))
                {
                    long fileSize = new FileInfo(outputJpg).Length;
                    Console.WriteLine("JPG exported successfully. Size: " + fileSize + " bytes.");
                }
                else
                {
                    Console.WriteLine("Failed to export JPG.");
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}