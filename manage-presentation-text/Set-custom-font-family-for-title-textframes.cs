using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Theme;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Set custom font for title placeholders via the master theme
                Aspose.Slides.Theme.IFontScheme fontScheme = presentation.MasterTheme.FontScheme;
                fontScheme.Major.LatinFont = new Aspose.Slides.FontData("Arial Black");

                // Ensure each title shape explicitly uses the new font
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null && autoShape.Placeholder != null && autoShape.Placeholder.Type == Aspose.Slides.PlaceholderType.Title)
                        {
                            foreach (Aspose.Slides.IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                            {
                                foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                                {
                                    portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("Arial Black");
                                }
                            }
                        }
                    }
                }

                // Save the presentation before exit
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format exception
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}