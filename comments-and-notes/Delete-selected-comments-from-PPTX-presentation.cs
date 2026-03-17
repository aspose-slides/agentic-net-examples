using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteCommentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source presentation
                string inputPath = "input.pptx";
                // Path to the output presentation
                string outputPath = "output.pptx";

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Retrieve comments on the current slide
                        IComment[] comments = slide.GetSlideComments(null);

                        // Process each comment
                        foreach (IComment comment in comments)
                        {
                            // Example condition: delete comments authored by "John Doe" or containing specific text
                            if (comment.Author != null && comment.Author.Name == "John Doe")
                            {
                                comment.Remove();
                            }
                            else if (comment.Text != null && comment.Text.Contains("Delete me"))
                            {
                                comment.Remove();
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}