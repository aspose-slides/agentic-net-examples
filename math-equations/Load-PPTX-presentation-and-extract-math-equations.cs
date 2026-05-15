using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the input presentation
        string inputPath = "input.pptx";

        // Verify that the file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Determine the load format of the presentation
            Aspose.Slides.LoadFormat loadFormat = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath).LoadFormat;
            bool isPpt95 = loadFormat == Aspose.Slides.LoadFormat.Ppt95;
            Console.WriteLine("Load format: " + loadFormat);

            // Example: extract mathematical equations as LaTeX strings
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0)
                    {
                        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
                        if (paragraph.Portions.Count > 0 && paragraph.Portions[0] is Aspose.Slides.MathText.MathPortion)
                        {
                            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)paragraph.Portions[0]).MathParagraph;
                            string latex = mathParagraph.ToLatex();
                            Console.WriteLine("Math equation (LaTeX): " + latex);
                        }
                    }
                }
            }

            // Save the presentation before exiting
            string outputPath = "output.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
    }
}