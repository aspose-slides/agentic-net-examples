using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Retrieve comments from the slide
            Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);

            // Delete the first comment if any exist
            if (comments != null && comments.Length > 0)
            {
                Aspose.Slides.IComment commentToRemove = comments[0];
                commentToRemove.Remove();
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