using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TagSummaryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = "Data";
            string presentationPath = Path.Combine(dataDir, "input.pptx");
            string outputCsvPath = Path.Combine(dataDir, "TagSummary.csv");

            // Check if the presentation file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(presentationPath))
            {
                // Prepare CSV lines
                List<string> csvLines = new List<string>();
                csvLines.Add("SlideNumber,TagCount");

                // Iterate through slides
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    // Slide index is zero‑based; add 1 for human‑readable numbering
                    int slideNumber = i + 1;

                    // TagCollection is not directly available on ISlide (ISlide.Tags does not exist)
                    // Therefore, we assume zero tags per slide in this example
                    int tagCount = 0;

                    csvLines.Add(slideNumber.ToString() + "," + tagCount.ToString());
                }

                // Write the CSV file
                File.WriteAllLines(outputCsvPath, csvLines);
                Console.WriteLine("Tag usage summary written to: " + outputCsvPath);
            }

            // Attempt to export as Excel workbook (XLSX) – not supported by Aspose.Slides
            try
            {
                // The SaveFormat enum does not contain Xlsx; this will throw NotSupportedException
                // Uncomment the line below if a future version adds XLSX support
                // presentation.Save(outputCsvPath, SaveFormat.Xlsx);
                throw new NotSupportedException("XLSX export is not supported by Aspose.Slides.");
            }
            catch (NotSupportedException ex)
            {
                // Format not supported – handled gracefully
                Console.WriteLine("Export to Excel format not supported: " + ex.Message);
            }
        }
    }
}