using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EncryptCommentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a comment author
                ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

                // Define a simple custom encryption algorithm (Caesar cipher with shift 1)
                string EncryptString(string input)
                {
                    char[] buffer = input.ToCharArray();
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        buffer[i] = (char)(buffer[i] + 1);
                    }
                    return new string(buffer);
                }

                // Original comment text
                string originalComment = "This is a confidential comment.";

                // Encrypt comment content
                string encryptedComment = EncryptString(originalComment);

                // Add the encrypted comment to the first slide
                PointF position = new PointF(100f, 100f);
                author.Comments.AddComment(encryptedComment, presentation.Slides[0], position, DateTime.Now);

                // Encrypt the entire presentation with a password
                string presentationPassword = "StrongPassword123";
                presentation.ProtectionManager.Encrypt(presentationPassword);

                // Save the presentation
                string outputPath = "EncryptedCommentsPresentation.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // Handle format not supported exception if needed
                // e.g., if (ex is Aspose.Slides.UnsupportedFileFormatException) { /* comment */ }
            }
        }
    }
}