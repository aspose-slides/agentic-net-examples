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
                // Load the presentation
                using (Presentation presentation = new Presentation("input.pptx"))
                {
                    // Get the first slide (adjust index as needed)
                    ISlide slide = presentation.Slides[0];

                    // Retrieve all comments on the slide
                    IComment[] slideComments = slide.GetSlideComments(null);

                    // Remove the first comment if any exist
                    if (slideComments.Length > 0)
                    {
                        IComment commentToRemove = slideComments[0];
                        commentToRemove.Remove();
                    }

                    // Save the modified presentation
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}