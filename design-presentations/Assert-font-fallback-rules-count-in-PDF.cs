using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontFallbackTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the fallback rules collection from the FontsManager
                IFontFallBackRulesCollection rulesCollection = presentation.FontsManager.FontFallBackRulesCollection;

                // Add a fallback rule
                FontFallBackRule rule = new FontFallBackRule(0x400, 0x4FF, "Times New Roman");
                rulesCollection.Add(rule);

                // Assert that the collection contains the expected number of rules
                int expectedCount = 1;
                int actualCount = rulesCollection.Count;
                if (actualCount != expectedCount)
                {
                    throw new InvalidOperationException("FontFallBackRulesCollection count mismatch. Expected: " + expectedCount + ", Actual: " + actualCount);
                }

                // Save the presentation (PDF format as an example)
                try
                {
                    presentation.Save("FontFallbackTest.pdf", SaveFormat.Pdf);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., file I/O)
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}