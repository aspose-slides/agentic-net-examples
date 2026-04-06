using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        Presentation presentation = null;
        try
        {
            presentation = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Retrieve comments from SharePoint list (placeholder implementation)
        List<Tuple<string, string, string>> sharePointComments = new List<Tuple<string, string, string>>();
        try
        {
            // Each tuple contains: SlideTitle, AuthorName, CommentText
            sharePointComments.Add(new Tuple<string, string, string>("Title 1", "Alice", "First comment"));
            sharePointComments.Add(new Tuple<string, string, string>("Title 2", "Bob", "Second comment"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error accessing SharePoint: " + ex.Message);
        }

        // Create or retrieve comment authors
        Dictionary<string, ICommentAuthor> authors = new Dictionary<string, ICommentAuthor>();
        foreach (Tuple<string, string, string> item in sharePointComments)
        {
            string authorName = item.Item2;
            if (!authors.ContainsKey(authorName))
            {
                ICommentAuthor author = presentation.CommentAuthors.AddAuthor(authorName, authorName.Substring(0, 1));
                authors.Add(authorName, author);
            }
        }

        // Define comment position and timestamp
        PointF position = new PointF(0.2f, 0.2f);
        DateTime now = DateTime.Now;

        // Attach comments to slides matching the title
        foreach (ISlide slide in presentation.Slides)
        {
            string slideTitle = string.Empty;
            if (slide.Shapes.Count > 0 && slide.Shapes[0] is IAutoShape)
            {
                IAutoShape shape = (IAutoShape)slide.Shapes[0];
                if (shape.TextFrame != null)
                {
                    slideTitle = shape.TextFrame.Text;
                }
            }

            foreach (Tuple<string, string, string> item in sharePointComments)
            {
                if (item.Item1.Equals(slideTitle, StringComparison.OrdinalIgnoreCase))
                {
                    ICommentAuthor author = authors[item.Item2];
                    author.Comments.AddComment(item.Item3, slide, position, now);
                }
            }
        }

        // Save the updated presentation
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
                presentation.Dispose();
        }
    }
}