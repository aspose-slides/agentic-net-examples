using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCommentsByHeading
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths and the heading to search for
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string heading = "SPECIFIED_HEADING";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through each slide in the presentation
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Retrieve all comments on the current slide (null author to get all)
                Aspose.Slides.IComment[] slideComments = slide.GetSlideComments(null);

                // Iterate backwards to safely remove comments while iterating
                for (int commentIndex = slideComments.Length - 1; commentIndex >= 0; commentIndex--)
                {
                    Aspose.Slides.IComment comment = slideComments[commentIndex];

                    // Check if the comment text contains the specified heading
                    if (!string.IsNullOrEmpty(comment.Text) && comment.Text.Contains(heading))
                    {
                        // Remove the comment and its replies
                        comment.Remove();
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("Comments containing the heading have been removed. Saved to: " + outputPath);
        }
    }
}