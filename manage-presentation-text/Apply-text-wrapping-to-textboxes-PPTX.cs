using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ApplyTextWrapping
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through each slide in the presentation
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Retrieve all text boxes (text frames) on the current slide
                        ITextFrame[] textFrames = SlideUtil.GetAllTextBoxes(slide);

                        // Apply text wrapping to each text frame
                        foreach (ITextFrame textFrame in textFrames)
                        {
                            ITextFrameFormat textFrameFormat = textFrame.TextFrameFormat;
                            textFrameFormat.WrapText = NullableBool.True;
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}