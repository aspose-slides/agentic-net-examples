using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            Presentation presentation = new Presentation("input.pptx");

            // Configure fallback font for saving
            HtmlOptions htmlOptions = new HtmlOptions();
            htmlOptions.DefaultRegularFont = "Arial";

            // Save the presentation with the fallback font applied
            presentation.Save("output.html", SaveFormat.Html, htmlOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}