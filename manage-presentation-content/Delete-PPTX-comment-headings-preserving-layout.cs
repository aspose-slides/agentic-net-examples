using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteCommentHeadings
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation presentation = new Presentation("input.pptx");

                // Iterate through each slide in the presentation
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];

                    // Retrieve all comments on the current slide
                    IComment[] comments = slide.GetSlideComments(null);

                    // Remove each comment (including its replies)
                    foreach (IComment comment in comments)
                    {
                        comment.Remove();
                    }
                }

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}