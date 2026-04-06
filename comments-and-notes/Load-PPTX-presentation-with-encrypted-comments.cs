using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path and password for encrypted comments
        string inputPath = "encrypted_comments.pptx";
        string password = "privateKeyPassword";
        string outputPath = "decrypted_output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation with the provided password
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.Password = password;
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

            // Access and display slide comments
            foreach (object authorObj in presentation.CommentAuthors)
            {
                Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)authorObj;
                foreach (object commentObj in author.Comments)
                {
                    Aspose.Slides.Comment comment = (Aspose.Slides.Comment)commentObj;
                    Console.WriteLine("Author: " + author.Name + " - Comment: " + comment.Text);
                }
            }

            // Save the decrypted presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}