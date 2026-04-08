using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DocumentPropertiesBackup
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string backupCsvPath = "properties_backup.csv";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);
                IDocumentProperties documentProperties = presentation.DocumentProperties;

                // Create CSV backup
                using (StreamWriter writer = new StreamWriter(backupCsvPath, false, Encoding.UTF8))
                {
                    // Header
                    writer.WriteLine("PropertyName,PropertyValue");

                    // Built-in writable properties
                    writer.WriteLine("Author," + EscapeCsv(documentProperties.Author));
                    writer.WriteLine("Title," + EscapeCsv(documentProperties.Title));
                    writer.WriteLine("Subject," + EscapeCsv(documentProperties.Subject));
                    writer.WriteLine("Category," + EscapeCsv(documentProperties.Category));
                    writer.WriteLine("Comments," + EscapeCsv(documentProperties.Comments));
                    writer.WriteLine("Company," + EscapeCsv(documentProperties.Company));
                    writer.WriteLine("Manager," + EscapeCsv(documentProperties.Manager));
                    writer.WriteLine("Keywords," + EscapeCsv(documentProperties.Keywords));
                    writer.WriteLine("CreatedTime," + documentProperties.CreatedTime.ToString("o"));
                    writer.WriteLine("LastSavedTime," + documentProperties.LastSavedTime.ToString("o"));
                    writer.WriteLine("LastPrinted," + documentProperties.LastPrinted.ToString("o"));
                    writer.WriteLine("LastSavedBy," + EscapeCsv(documentProperties.LastSavedBy));
                    writer.WriteLine("ContentStatus," + EscapeCsv(documentProperties.ContentStatus));
                    writer.WriteLine("ContentType," + EscapeCsv(documentProperties.ContentType));
                    writer.WriteLine("HyperlinkBase," + EscapeCsv(documentProperties.HyperlinkBase));
                    writer.WriteLine("PresentationFormat," + EscapeCsv(documentProperties.PresentationFormat));
                    writer.WriteLine("RevisionNumber," + documentProperties.RevisionNumber);
                    writer.WriteLine("TotalEditingTime," + documentProperties.TotalEditingTime);

                    // Custom properties
                    for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
                    {
                        string customName = documentProperties.GetCustomPropertyName(i);
                        object customValue = documentProperties[customName];
                        writer.WriteLine(EscapeCsv(customName) + "," + EscapeCsv(customValue?.ToString() ?? string.Empty));
                    }
                }

                // Perform bulk edits (example: update some built-in properties)
                documentProperties.Author = "New Author";
                documentProperties.Title = "New Title";
                documentProperties.Subject = "New Subject";

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Backup completed and presentation saved.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Helper method to escape CSV fields
        private static string EscapeCsv(string field)
        {
            if (field == null)
                return string.Empty;

            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r"))
            {
                string escaped = field.Replace("\"", "\"\"");
                return "\"" + escaped + "\"";
            }
            else
            {
                return field;
            }
        }
    }
}