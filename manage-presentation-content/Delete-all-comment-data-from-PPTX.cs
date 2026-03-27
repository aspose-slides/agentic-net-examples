using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCommentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_no_comments.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides and remove their comments
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                Aspose.Slides.IComment[] slideComments = slide.GetSlideComments(null);

                for (int commentIndex = 0; commentIndex < slideComments.Length; commentIndex++)
                {
                    Aspose.Slides.IComment comment = slideComments[commentIndex];

                    // Navigate to the top-most parent comment before removal
                    while (comment.ParentComment != null)
                    {
                        comment = comment.ParentComment;
                    }

                    // Remove the comment and all its replies
                    comment.Remove();
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();

            Console.WriteLine("All comments have been removed. Saved to: " + outputPath);
        }
    }
}