using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTextReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputHtmlPath = "report.html";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Extract raw text including comments using Unarranged mode
                IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                    inputPath,
                    TextExtractionArrangingMode.Unarranged);

                // Build HTML report
                StringBuilder htmlBuilder = new StringBuilder();
                htmlBuilder.AppendLine("<!DOCTYPE html>");
                htmlBuilder.AppendLine("<html><head><meta charset=\"UTF-8\"><title>Slide Text Report</title></head><body>");
                htmlBuilder.AppendLine("<h1>Presentation Text Report</h1>");

                ISlideText[] slidesText = presentationText.SlidesText;
                for (int i = 0; i < slidesText.Length; i++)
                {
                    ISlideText slideText = slidesText[i];
                    htmlBuilder.AppendLine($"<section>");
                    htmlBuilder.AppendLine($"<h2>Slide {i + 1}</h2>");
                    htmlBuilder.AppendLine("<h3>Slide Text</h3>");
                    htmlBuilder.AppendLine($"<p>{System.Web.HttpUtility.HtmlEncode(slideText.Text)}</p>");

                    htmlBuilder.AppendLine("<h3>Comments Text</h3>");
                    htmlBuilder.AppendLine($"<p>{System.Web.HttpUtility.HtmlEncode(slideText.CommentsText)}</p>");

                    htmlBuilder.AppendLine("<h3>Layout Text</h3>");
                    htmlBuilder.AppendLine($"<p>{System.Web.HttpUtility.HtmlEncode(slideText.LayoutText)}</p>");
                    htmlBuilder.AppendLine($"</section>");
                }

                htmlBuilder.AppendLine("</body></html>");

                // Write HTML to file
                File.WriteAllText(outputHtmlPath, htmlBuilder.ToString(), Encoding.UTF8);
                Console.WriteLine($"HTML report generated at: {outputHtmlPath}");
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other extraction errors
                // Format not supported
                Console.WriteLine("An error occurred during text extraction: " + ex.Message);
                return;
            }

            // Load presentation and save (as per lifecycle rule)
            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    pres.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any saving errors
                Console.WriteLine("An error occurred while saving the presentation: " + ex.Message);
            }
        }
    }
}