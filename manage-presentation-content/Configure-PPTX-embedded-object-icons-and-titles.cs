using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConfigureEmbeddedObjectIcons
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source presentation
                string sourcePath = "input.pptx";
                // Path to the output presentation
                string outputPath = "output.pptx";

                // Load the presentation
                using (Presentation pres = new Presentation(sourcePath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            // Cast shape to OleObjectFrame if possible
                            OleObjectFrame oleObject = slide.Shapes[shapeIndex] as OleObjectFrame;
                            if (oleObject != null)
                            {
                                // Display the OLE object as an icon
                                oleObject.IsObjectIcon = true;

                                // Set a custom title for the icon
                                oleObject.SubstitutePictureTitle = "Custom OLE Icon Title";
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}