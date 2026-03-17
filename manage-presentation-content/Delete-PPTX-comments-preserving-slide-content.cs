using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteCommentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[i];

                        // Retrieve all comments on the current slide
                        Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);

                        // Remove each comment
                        foreach (Aspose.Slides.IComment comment in comments)
                        {
                            comment.Remove();
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}