using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontModificationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Iterate through all slides
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Process only AutoShapes that contain a TextFrame
                        if (shape is Aspose.Slides.IAutoShape)
                        {
                            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                            if (autoShape.TextFrame != null)
                            {
                                // Iterate through all paragraphs
                                foreach (Aspose.Slides.IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                                {
                                    // Iterate through all portions (runs of text)
                                    foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                                    {
                                        // Set the font to Arial
                                        portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("Arial");
                                        // Set font size to 24 points
                                        portion.PortionFormat.FontHeight = 24;
                                        // Make the text bold
                                        portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
                                        // Make the text italic
                                        portion.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True;
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation as a new PPTX file
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Output any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}