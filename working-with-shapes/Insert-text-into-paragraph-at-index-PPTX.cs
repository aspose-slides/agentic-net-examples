using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the existing presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Assume the first shape contains a TextFrame
                Aspose.Slides.IAutoShape shape = slide.Shapes[0] as Aspose.Slides.IAutoShape;

                if (shape != null && shape.TextFrame != null && shape.TextFrame.Paragraphs.Count > 0)
                {
                    // Get the first paragraph
                    Aspose.Slides.IParagraph paragraph = shape.TextFrame.Paragraphs[0];

                    // Define the index at which the new text segment will be inserted
                    int insertIndex = 1; // zero‑based index

                    // Create a new portion with the desired text
                    Aspose.Slides.IPortion newPortion = new Aspose.Slides.Portion("Inserted Text");

                    // Preserve formatting from an existing portion (previous portion if possible)
                    Aspose.Slides.IPortion referencePortion = paragraph.Portions[insertIndex > 0 ? insertIndex - 1 : 0];
                    newPortion.PortionFormat.FontHeight = referencePortion.PortionFormat.FontHeight;
                    newPortion.PortionFormat.FontBold = referencePortion.PortionFormat.FontBold;

                    // Insert the new portion into the paragraph at the specified index
                    paragraph.Portions.Insert(insertIndex, newPortion);
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