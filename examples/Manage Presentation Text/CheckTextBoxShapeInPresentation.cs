using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace PresentationTextCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the presentation from a file
            var presentationPath = "input.pptx";
            using (var presentation = new Aspose.Slides.Presentation(presentationPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    var slide = presentation.Slides[slideIndex];

                    // Get all text boxes on the current slide
                    var textBoxes = SlideUtil.GetAllTextBoxes(slide);

                    // If any text box is found, modify its text
                    if (textBoxes != null && textBoxes.Length > 0)
                    {
                        // Example modification: set the text of the first text box
                        textBoxes[0].Text = "Checked and updated";
                    }
                }

                // Save the presentation after modifications
                var outputPath = "output.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}