using System;
using System.Text.RegularExpressions;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("Input.pptx");
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\b[^\s]{10,}\b");
            presentation.HighlightRegex(regex, System.Drawing.Color.Yellow, null);
            presentation.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}