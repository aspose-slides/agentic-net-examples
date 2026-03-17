using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate over comment authors in reverse order to safely remove them
                for (int i = presentation.CommentAuthors.Count - 1; i >= 0; i--)
                {
                    ICommentAuthor author = presentation.CommentAuthors[i];
                    // Remove all comments belonging to this author
                    author.Comments.Clear();
                    // Remove the author from the collection
                    author.Remove();
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}