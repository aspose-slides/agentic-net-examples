using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCommentsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Topic to identify comments for removal
            string topic = "Confidential";

            // Iterate through all slides
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                // Retrieve all comments on the current slide
                Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);
                foreach (Aspose.Slides.IComment comment in comments)
                {
                    if (comment.Text != null && comment.Text.Contains(topic))
                    {
                        // Remove the comment and its replies
                        comment.Remove();
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}