using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load the presentation
            Presentation presentation = new Presentation("input.pptx");

            // Build HTML content from paragraph texts
            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine("<html>");
            htmlBuilder.AppendLine("<body>");

            foreach (ISlide slide in presentation.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    IAutoShape autoShape = shape as IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                        {
                            string text = paragraph.Text;
                            // Encode HTML entities
                            string encodedText = System.Net.WebUtility.HtmlEncode(text);
                            htmlBuilder.AppendLine("<p>" + encodedText + "</p>");
                        }
                    }
                }
            }

            htmlBuilder.AppendLine("</body>");
            htmlBuilder.AppendLine("</html>");

            // Save the HTML file
            File.WriteAllText("output.html", htmlBuilder.ToString());

            // Save the presentation before exiting (as required)
            presentation.Save("output_saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}