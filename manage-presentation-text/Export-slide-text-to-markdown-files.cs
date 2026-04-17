using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main(string[] args)
    {
        // Define input presentation path
        string inputPath = "input.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through each slide
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];

                // Determine slide title from CenteredTitle placeholder
                string title = "Slide_" + (i + 1).ToString();
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
                    {
                        if (shape.Placeholder.Type == Aspose.Slides.PlaceholderType.CenteredTitle)
                        {
                            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                            if (autoShape.TextFrame != null)
                            {
                                title = autoShape.TextFrame.Text;
                            }
                        }
                    }
                }

                // Extract all text boxes from the slide
                StringBuilder sb = new StringBuilder();
                Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);
                foreach (Aspose.Slides.ITextFrame tf in textFrames)
                {
                    sb.AppendLine(tf.Text);
                }

                // Prepare markdown content
                string markdownContent = sb.ToString();

                // Create a safe file name for the markdown file
                char[] invalidChars = Path.GetInvalidFileNameChars();
                foreach (char c in invalidChars)
                {
                    title = title.Replace(c.ToString(), "_");
                }
                string outputPath = title + ".md";

                // Write markdown file
                File.WriteAllText(outputPath, markdownContent);
            }

            // Save the presentation before exiting
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}