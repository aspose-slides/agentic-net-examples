using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);

            Aspose.Slides.IHyperlinkQueries hyperlinkQueries = presentation.HyperlinkQueries;
            System.Collections.Generic.IList<Aspose.Slides.IHyperlinkContainer> clickContainers = hyperlinkQueries.GetHyperlinkClicks();

            foreach (Aspose.Slides.IHyperlinkContainer container in clickContainers)
            {
                Aspose.Slides.IHyperlink hyperlink = container.HyperlinkClick;
                if (hyperlink != null && hyperlink.ExternalUrl != null)
                {
                    Console.WriteLine("Hyperlink URL: " + hyperlink.ExternalUrl);
                }
            }

            // Save the (potentially unchanged) presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}