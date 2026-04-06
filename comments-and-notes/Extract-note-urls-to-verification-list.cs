using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // List to hold extracted URLs
        List<string> urlList = new List<string>();

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through each slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    // Access the notes slide for the current slide
                    Aspose.Slides.INotesSlide notesSlide = presentation.Slides[i].NotesSlideManager.NotesSlide;
                    if (notesSlide != null && notesSlide.NotesTextFrame != null)
                    {
                        string notesText = notesSlide.NotesTextFrame.Text;
                        if (!string.IsNullOrEmpty(notesText))
                        {
                            // Find URLs using a regular expression
                            MatchCollection matches = Regex.Matches(notesText, @"https?://[^\s]+");
                            foreach (Match match in matches)
                            {
                                urlList.Add(match.Value);
                            }
                        }
                    }
                }

                // Save the (potentially unchanged) presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Handle unsupported PPTX format
            Console.WriteLine("The file format is not supported (PPTX).");
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // Handle unsupported PPT format
            Console.WriteLine("The file format is not supported (PPT).");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        // Output the collected URLs for verification
        Console.WriteLine("Extracted URLs:");
        foreach (string url in urlList)
        {
            Console.WriteLine(url);
        }
    }
}