// -----------------------------------------------------------------------------
// Example: Summarize tag usage per slide to XLSX using C#
//
// Description:
// Demonstrates how to enumerate tags on each slide of a PowerPoint presentation
// and write the per‑slide tag count to an Excel workbook (XLSX) using Aspose.Slides
// for .NET together with Aspose.Cells. The example loads a PPTX file, extracts the
// tag collection from every slide, and creates a simple spreadsheet that can be
// further processed or reported.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Aspose.Cells, Summarize, Tag Usage,
// Slide, XLSX, Presentation Processing, Office Automation
//
// Use Cases:
// - Generate reports of custom tag usage across presentation slides.
// - Integrate PowerPoint metadata extraction into .NET data‑analysis pipelines.
// - Automate creation of Excel summaries for presentation audits or migrations.
// - Provide developers with a reusable pattern for combining Aspose.Slides and
//   Aspose.Cells in console utilities.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Cells;

namespace TagSummaryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = "Data";
            string presentationPath = Path.Combine(dataDir, "input.pptx");
            string outputXlsxPath = Path.Combine(dataDir, "TagSummary.xlsx");

            // Verify the presentation file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(presentationPath))
            {
                // Prepare data for Excel: first row contains headers
                List<object[]> rows = new List<object[]>();
                rows.Add(new object[] { "SlideNumber", "TagCount" });

                // Iterate through slides and count tags
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    int slideNumber = i + 1; // Human‑readable slide number
                    int tagCount = presentation.Slides[i].Tags.Count; // Actual tag count

                    rows.Add(new object[] { slideNumber, tagCount });
                }

                // Create an Excel workbook using Aspose.Cells
                Workbook workbook = new Workbook();
                Worksheet sheet = workbook.Worksheets[0];
                sheet.Name = "Tag Summary";

                // Populate the worksheet with the collected data
                for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
                {
                    object[] row = rows[rowIndex];
                    for (int colIndex = 0; colIndex < row.Length; colIndex++)
                    {
                        sheet.Cells[rowIndex, colIndex].PutValue(row[colIndex]);
                    }
                }

                // Save the workbook as XLSX
                workbook.Save(outputXlsxPath, SaveFormat.Xlsx);
                Console.WriteLine("Tag usage summary written to: " + outputXlsxPath);
            }
        }
    }
}
