using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCommentExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var presentationPath = "input.pptx";
                var outputPath = "output.pptx";
                var slideIndex = 0; // zero‑based index of the slide
                var commentTextToRemove = "Sample comment";

                using (var presentation = new Aspose.Slides.Presentation(presentationPath))
                {
                    var slide = presentation.Slides[slideIndex];

                    // Retrieve all comments on the slide
                    var comments = slide.GetSlideComments(null);
                    foreach (var comment in comments)
                    {
                        if (comment.Text == commentTextToRemove)
                        {
                            // Remove the matching comment
                            comment.Remove();
                            break;
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}