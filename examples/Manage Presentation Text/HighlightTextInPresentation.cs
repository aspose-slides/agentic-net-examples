using System;
using System.Text.RegularExpressions;
using System.Drawing;

namespace HighlightTextWithRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string inputPath = "SamplePresentation.pptx";

            // Path to the output presentation
            string outputPath = "SamplePresentation-Highlighted.pptx";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Define the regular expression to match words with 10 or more characters
                Regex regex = new Regex(@"\b[^\s]{10,}\b");

                // Highlight all matches with blue color
                presentation.HighlightRegex(regex, Color.Blue, null);

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}