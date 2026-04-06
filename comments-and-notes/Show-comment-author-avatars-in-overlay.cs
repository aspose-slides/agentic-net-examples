using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output_with_avatars.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            // Load existing presentation
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or loading errors
            // Format not supported
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Add a new empty slide
        Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Add a comment author
        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

        // Define comment position
        System.Drawing.PointF commentPosition = new System.Drawing.PointF(200f, 150f);

        // Add a comment to the slide
        Aspose.Slides.IComment comment = author.Comments.AddComment("This is a sample comment.", slide, commentPosition, DateTime.Now);

        // Path to the author's avatar image
        string avatarPath = "avatar_john.png";

        if (File.Exists(avatarPath))
        {
            // Load avatar image into presentation
            byte[] avatarBytes = File.ReadAllBytes(avatarPath);
            Aspose.Slides.IPPImage avatarImage = presentation.Images.AddImage(avatarBytes);

            // Calculate avatar placement (offset to the left of the comment bubble)
            float avatarX = comment.Position.X - 30f;
            float avatarY = comment.Position.Y;
            float avatarWidth = 20f;
            float avatarHeight = 20f;

            // Add avatar picture frame to the slide
            slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, avatarX, avatarY, avatarWidth, avatarHeight, avatarImage);
        }
        else
        {
            Console.WriteLine("Avatar image not found: " + avatarPath);
        }

        try
        {
            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            // Ensure resources are released
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}