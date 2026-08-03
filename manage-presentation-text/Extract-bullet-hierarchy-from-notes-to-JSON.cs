// -----------------------------------------------------------------------------
// Example: Extract bullet hierarchy from notes to JSON using C#
//
// Description:
// Demonstrates how to extract bullet hierarchy from slide notes to JSON using
// C# and Aspose.Slides for .NET. The example loads a presentation, reads the
// notes text frames, captures each paragraph's text and bullet level, and
// outputs the hierarchy as a JSON array. This pattern can be used to automate
// PPTX workflows, validate note content, or integrate presentation data into
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Bullet, Hierarchy,
// Notes, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of bullet hierarchy from slide notes to JSON.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ExtractBulletHierarchy
{
    class Program
    {
        // Model for JSON output
        public class ParagraphInfo
        {
            public string Text { get; set; }
            public int Level { get; set; }
        }

        public class SlideInfo
        {
            public int SlideNumber { get; set; }
            public List<ParagraphInfo> Paragraphs { get; set; }
        }

        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify file existence
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // format not supported
                Console.WriteLine("The file format is not supported (PPTX).");
                return;
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // format not supported
                Console.WriteLine("The file format is not supported (PPT).");
                return;
            }
            catch (Exception ex)
            {
                // Other errors
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Collect bullet hierarchy from notes
            List<SlideInfo> slidesData = new List<SlideInfo>();

            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                Aspose.Slides.INotesSlideManager notesMgr = slide.NotesSlideManager;
                Aspose.Slides.INotesSlide notesSlide = notesMgr.NotesSlide;

                if (notesSlide != null && notesSlide.NotesTextFrame != null)
                {
                    SlideInfo slideInfo = new SlideInfo
                    {
                        SlideNumber = i + 1,
                        Paragraphs = new List<ParagraphInfo>()
                    };

                    foreach (Aspose.Slides.IParagraph paragraph in notesSlide.NotesTextFrame.Paragraphs)
                    {
                        ParagraphInfo paraInfo = new ParagraphInfo
                        {
                            Text = paragraph.Text,
                            // Depth indicates bullet level (0 = top level)
                            Level = paragraph.ParagraphFormat.Depth
                        };
                        slideInfo.Paragraphs.Add(paraInfo);
                    }

                    slidesData.Add(slideInfo);
                }
            }

            // Serialize to JSON
            string jsonOutput = JsonSerializer.Serialize(slidesData, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(jsonOutput);

            // Save presentation before exit (no modifications, just re‑save)
            try
            {
                Aspose.Slides.Export.SaveFormat saveFmt = SlideUtil.ToSaveFormat(presentation.SourceFormat);
                presentation.Save(inputPath, saveFmt);
            }
            catch (Exception ex)
            {
                // Handle any save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                // Release resources
                presentation.Dispose();
            }
        }
    }
}
