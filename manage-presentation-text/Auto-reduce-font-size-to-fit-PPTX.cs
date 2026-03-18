using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReduceFontSizeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                var presentation = new Presentation("input.pptx");

                // Iterate through all slides and shapes
                foreach (var slide in presentation.Slides)
                {
                    foreach (var shape in slide.Shapes)
                    {
                        // Process only AutoShapes that contain a TextFrame
                        if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                        {
                            // Set autofit mode to shrink text on overflow
                            autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Normal;
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}