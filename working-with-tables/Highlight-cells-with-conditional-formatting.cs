using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TablePlaceholderReplacement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string presentationPath = "input.pptx";
            string csvPath = "data.csv";
            string outputPath = "output.pptx";

            // Verify that the input files exist
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            if (!File.Exists(csvPath))
            {
                Console.WriteLine("CSV file not found: " + csvPath);
                return;
            }

            // Load CSV data into a dictionary (placeholder -> replacement)
            Dictionary<string, string> placeholderMap = new Dictionary<string, string>();
            using (StreamReader reader = new StreamReader(csvPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();
                        if (!placeholderMap.ContainsKey(key))
                        {
                            placeholderMap.Add(key, value);
                        }
                    }
                }
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath);

                // Iterate through all slides
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Process only table shapes
                        if (shape is Aspose.Slides.ITable)
                        {
                            Aspose.Slides.ITable table = (Aspose.Slides.ITable)shape;

                            // Iterate through rows and columns of the table
                            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                            {
                                for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
                                {
                                    Aspose.Slides.ICell cell = table[rowIndex, colIndex];
                                    if (cell != null && cell.TextFrame != null)
                                    {
                                        string cellText = cell.TextFrame.Text;

                                        // Replace placeholders with CSV values
                                        foreach (KeyValuePair<string, string> kvp in placeholderMap)
                                        {
                                            if (cellText.Contains(kvp.Key))
                                            {
                                                cellText = cellText.Replace(kvp.Key, kvp.Value);
                                            }
                                        }

                                        cell.TextFrame.Text = cellText;
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported or other processing error
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}