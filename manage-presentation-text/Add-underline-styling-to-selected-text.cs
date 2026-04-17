using System;
using System.IO;
using System.Globalization;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
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
            Presentation pres = new Presentation(inputPath);
            foreach (ISlide slide in pres.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    IAutoShape autoShape = shape as IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        string originalText = autoShape.TextFrame.Text;
                        if (!string.IsNullOrEmpty(originalText) && originalText == originalText.ToUpper())
                        {
                            string[] words = originalText.Split(' ');
                            StringBuilder sb = new StringBuilder();
                            for (int i = 0; i < words.Length; i++)
                            {
                                if (words[i].Length > 0)
                                {
                                    string lower = words[i].ToLower(CultureInfo.CurrentCulture);
                                    string title = char.ToUpper(lower[0], CultureInfo.CurrentCulture) + lower.Substring(1);
                                    sb.Append(title);
                                }
                                if (i < words.Length - 1)
                                    sb.Append(' ');
                            }
                            autoShape.TextFrame.Text = sb.ToString();
                        }
                    }
                }
            }

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}