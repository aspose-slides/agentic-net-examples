using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // List of presentation files to analyze
        string[] presentationPaths = new string[] { "Presentation1.pptx", "Presentation2.pptx" };

        foreach (string path in presentationPaths)
        {
            // Check if the file exists
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found: " + path);
                continue;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(path);

                bool hasSubstitution = false;

                // Iterate over font substitutions
                foreach (Aspose.Slides.FontSubstitutionInfo substitution in pres.FontsManager.GetSubstitutions())
                {
                    if (!hasSubstitution)
                    {
                        Console.WriteLine("Font substitutions in " + path + ":");
                        hasSubstitution = true;
                    }
                    Console.WriteLine(substitution.OriginalFontName + " -> " + substitution.SubstitutedFontName);
                }

                if (!hasSubstitution)
                {
                    Console.WriteLine("No font substitutions in " + path + ".");
                }

                // Save the presentation before exiting (no changes made)
                pres.Save(path, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error processing file " + path + ": " + ex.Message);
            }
        }
    }
}