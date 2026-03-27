using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCommentsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Retrieve all comments on the current slide (including replies)
                Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);

                // Remove each comment; this also removes its child replies
                for (int commentIndex = 0; commentIndex < comments.Length; commentIndex++)
                {
                    Aspose.Slides.IComment comment = comments[commentIndex];
                    comment.Remove();
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();

            Console.WriteLine("Comments removed and presentation saved to: " + outputPath);
        }
    }
}