using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Set default proofing language for the presentation
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DefaultTextLanguage = "en-US";

            // Load the presentation with the specified load options
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx", loadOptions))
            {
                // Enable spell checking for all text portions
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.AutoShape)
                        {
                            Aspose.Slides.AutoShape autoShape = (Aspose.Slides.AutoShape)shape;
                            if (autoShape.TextFrame != null)
                            {
                                foreach (Aspose.Slides.IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                                {
                                    foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                                    {
                                        portion.PortionFormat.SpellCheck = true;
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}