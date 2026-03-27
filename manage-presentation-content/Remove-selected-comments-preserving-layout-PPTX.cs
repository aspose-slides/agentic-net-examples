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
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Get all comments on the current slide
                Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);

                // Iterate through comments and remove selected ones
                for (int commentIndex = 0; commentIndex < comments.Length; commentIndex++)
                {
                    Aspose.Slides.IComment comment = comments[commentIndex];

                    // Example condition: remove comments containing the word "RemoveMe"
                    if (comment.Text != null && comment.Text.Contains("RemoveMe"))
                    {
                        comment.Remove();
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();

            Console.WriteLine("Comments removed and presentation saved to: " + outputPath);
        }
    }
}