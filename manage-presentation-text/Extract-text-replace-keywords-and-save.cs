// -----------------------------------------------------------------------------
// Example: Extract text replace keywords and save using C#
//
// Description:
// Demonstrates how to extract text replace keywords and save using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Text, Replace, 
// Keywords, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extract text replace keywords and save.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.pptx";

        // Verify input file existence
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load presentation
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Replace all occurrences of the keyword
        FindResultCallback callback = new FindResultCallback();
        try
        {
            presentation.ReplaceText("keyword", "replacement", new Aspose.Slides.TextSearchOptions(), callback);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Replace operation failed: " + ex.Message);
        }

        // Save the updated presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Save operation failed: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
                presentation.Dispose();
        }
    }

    // Callback to collect replacement results
    public class FindResultCallback : Aspose.Slides.IFindResultCallback
    {
        public readonly System.Collections.Generic.List<WordInfo> Words = new System.Collections.Generic.List<WordInfo>();

        public System.Int32 Count
        {
            get { return Words.Count; }
        }

        public void FoundResult(Aspose.Slides.ITextFrame textFrame, System.String oldText, System.String foundText, System.Int32 textPosition)
        {
            Words.Add(new WordInfo(textFrame, oldText, foundText, textPosition));
        }
    }

    // Information about each replaced word
    public class WordInfo
    {
        public Aspose.Slides.ITextFrame TextFrame { get; }
        public System.String SourceText { get; }
        public System.String FoundText { get; }
        public System.Int32 TextPosition { get; }

        internal WordInfo(Aspose.Slides.ITextFrame textFrame, System.String sourceText, System.String foundText, System.Int32 textPosition)
        {
            TextFrame = textFrame;
            SourceText = sourceText;
            FoundText = foundText;
            TextPosition = textPosition;
        }
    }
}
