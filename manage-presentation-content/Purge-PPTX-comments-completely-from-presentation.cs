using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCommentsExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load the presentation
                var presentation = new Aspose.Slides.Presentation("input.pptx");

                // Iterate through each slide and remove all comments
                foreach (var slide in presentation.Slides)
                {
                    // Retrieve comments on the current slide
                    var comments = slide.GetSlideComments(null);
                    // Remove each comment
                    foreach (var comment in comments)
                    {
                        comment.Remove();
                    }
                }

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}