using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var slides = presentation.Slides;
                for (int i = 0; i < slides.Count; i++)
                {
                    var slide = slides[i];
                    var comments = slide.GetSlideComments(null);
                    foreach (var comment in comments)
                    {
                        comment.Remove();
                    }
                }
                presentation.Save("output_clean.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}