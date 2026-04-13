using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string presentationPath = "template.pptx";

        // Check if the input presentation exists
        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found: " + presentationPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(presentationPath))
            {
                // Simulated database fields
                Dictionary<string, string> dbFields = new Dictionary<string, string>
                {
                    { "EmployeeName", "John Doe" },
                    { "Department", "Sales" },
                    { "HireDate", DateTime.Now.ToShortDateString() }
                };

                // Map database fields to presentation tags
                foreach (KeyValuePair<string, string> kvp in dbFields)
                {
                    pres.CustomData.Tags[kvp.Key] = kvp.Value;
                }

                // Example: add a chart and set an external workbook (URL may be unavailable)
                try
                {
                    IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 300);
                    IChartData chartData = chart.ChartData;
                    // Cast to ChartData to access SetExternalWorkbook
                    ((ChartData)chartData).SetExternalWorkbook("http://example.com/data.xlsx", false);
                }
                catch (InvalidOperationException)
                {
                    // Format not supported or workbook unavailable
                    // Handle accordingly (e.g., log, fallback)
                }

                // Save the modified presentation
                string outputPath = "output.pptx";
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}