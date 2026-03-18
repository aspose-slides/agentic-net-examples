using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace TextBoxVerifier
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the presentation file
                string presentationPath = "input.pptx";

                // Load the presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    bool textBoxFound = false;

                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is an AutoShape
                            if (shape is IAutoShape)
                            {
                                IAutoShape autoShape = (IAutoShape)shape;

                                // Verify if the AutoShape is a text box
                                if (autoShape.IsTextBox)
                                {
                                    textBoxFound = true;
                                    break;
                                }
                            }
                        }

                        if (textBoxFound)
                        {
                            break;
                        }
                    }

                    // Output the verification result
                    if (textBoxFound)
                    {
                        Console.WriteLine("A text box shape was found in the presentation.");
                    }
                    else
                    {
                        Console.WriteLine("No text box shape was found in the presentation.");
                    }

                    // Save the presentation before exiting (optional: save to a new file)
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}