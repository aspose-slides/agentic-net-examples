using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchRenameCommentAuthors
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect three arguments: input presentation, mapping file, output presentation
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: BatchRenameCommentAuthors <input.pptx> <mapping.txt> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string mappingPath = args[1];
            string outputPath = args[2];

            // Verify input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file does not exist: " + inputPath);
                return;
            }

            if (!File.Exists(mappingPath))
            {
                Console.WriteLine("Mapping file does not exist: " + mappingPath);
                return;
            }

            // Load mapping file (oldName,newName per line)
            Dictionary<string, string> renameMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            try
            {
                string[] lines = File.ReadAllLines(mappingPath);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split(new char[] { ',' }, 2);
                    if (parts.Length == 2)
                    {
                        string oldName = parts[0].Trim();
                        string newName = parts[1].Trim();
                        if (!renameMap.ContainsKey(oldName))
                        {
                            renameMap.Add(oldName, newName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading mapping file: " + ex.Message);
                return;
            }

            // Load presentation and rename authors
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation. Possibly unsupported format. Details: " + ex.Message);
                return;
            }

            try
            {
                foreach (object authorObj in presentation.CommentAuthors)
                {
                    Aspose.Slides.ICommentAuthor author = (Aspose.Slides.ICommentAuthor)authorObj;
                    if (renameMap.ContainsKey(author.Name))
                    {
                        author.Name = renameMap[author.Name];
                    }
                }

                // Save the updated presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing presentation: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}