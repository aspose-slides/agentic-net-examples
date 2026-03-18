using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertSlideLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the existing presentation
                using (Presentation presentation = new Presentation("input.pptx"))
                {
                    // Iterate through all slides and add a numeric label
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];

                        // Add a rectangle shape to serve as the label
                        IAutoShape label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 20);

                        // Set the label text to the slide number
                        label.TextFrame.Text = slide.SlideNumber.ToString();

                        // Optional: format the text (font size)
                        label.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 12;
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