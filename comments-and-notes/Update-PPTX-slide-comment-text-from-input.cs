using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IComment[] slideComments = slide.GetSlideComments(null);

            if (slideComments.Length == 0)
            {
                Console.WriteLine("No comments found on the first slide.");
            }
            else
            {
                Aspose.Slides.IComment comment = slideComments[0];
                Console.Write("Enter new comment text: ");
                string newText = Console.ReadLine();
                comment.Text = newText;
                Console.WriteLine("Comment updated.");
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
            // Format not supported comment (if applicable)
        }
    }
}