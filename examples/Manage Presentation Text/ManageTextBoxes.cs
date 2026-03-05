using System;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Retrieve all text boxes on the slide
        Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

        // Iterate through each text box
        for (int i = 0; i < textFrames.Length; i++)
        {
            Aspose.Slides.ITextFrame textFrame = textFrames[i];

            // Ensure the text frame contains at least one paragraph and portion
            if (textFrame.Paragraphs.Count > 0 && textFrame.Paragraphs[0].Portions.Count > 0)
            {
                Aspose.Slides.IPortion portion = textFrame.Paragraphs[0].Portions[0];

                // Output original text
                Console.WriteLine("TextBox {0}: {1}", i, portion.Text);

                // Modify the text
                portion.Text = "Updated Text " + i;
            }
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}