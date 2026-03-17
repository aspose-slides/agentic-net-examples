using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationOverview
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation from a file
                Presentation presentation = new Presentation("input.pptx");

                // Get the total number of slides
                int slideCount = presentation.Slides.Count;
                Console.WriteLine("Slide count: " + slideCount);

                // Iterate through slides and display a simple title if available
                for (int i = 0; i < slideCount; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    string title = string.Empty;

                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                        {
                            title = autoShape.TextFrame.Text;
                            break;
                        }
                    }

                    Console.WriteLine("Slide " + (i + 1) + " title: " + title);
                }

                // Save the presentation preserving the original layout
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}