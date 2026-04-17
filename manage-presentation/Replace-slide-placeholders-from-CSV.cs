using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides.Export;

namespace PlaceholderReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPresentationPath = "input.pptx";
            string csvPath = "data.csv";
            string outputPresentationPath = "output.pptx";

            // Verify input files exist
            if (!File.Exists(inputPresentationPath))
            {
                Console.WriteLine("Input presentation file not found.");
                return;
            }
            if (!File.Exists(csvPath))
            {
                Console.WriteLine("CSV data file not found.");
                return;
            }

            // Read CSV data into a dictionary (PlaceholderType -> Replacement Text)
            Dictionary<string, string> placeholderValues = new Dictionary<string, string>();
            try
            {
                string[] lines = File.ReadAllLines(csvPath);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split(',');
                    if (parts.Length >= 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();
                        placeholderValues[key] = value;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading CSV: " + ex.Message);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPresentationPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other loading errors
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Replace placeholder text on each slide based on CSV values
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
                    {
                        Aspose.Slides.PlaceholderType placeholderType = shape.Placeholder.Type;
                        string placeholderKey = placeholderType.ToString();
                        if (placeholderValues.ContainsKey(placeholderKey))
                        {
                            string newText = placeholderValues[placeholderKey];
                            ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = newText;
                        }
                    }
                }
            }

            // Save the modified presentation
            try
            {
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
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
}