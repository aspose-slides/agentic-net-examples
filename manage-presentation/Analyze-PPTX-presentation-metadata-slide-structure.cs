using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace AnalyzePresentation
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define input and output paths
                string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
                if (!Directory.Exists(dataDir))
                {
                    Directory.CreateDirectory(dataDir);
                }

                string inputFileName = "input.pptx";
                string inputPath = Path.Combine(dataDir, inputFileName);
                string outputFileName = "Analyzed_output.pptx";
                string outputPath = Path.Combine(dataDir, outputFileName);

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // ----- Metadata -----
                    Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
                    Console.WriteLine("=== Document Properties ===");
                    Console.WriteLine("Title: " + docProps.Title);
                    Console.WriteLine("Author: " + docProps.Author);
                    Console.WriteLine("Created: " + docProps.CreatedTime);
                    Console.WriteLine("Subject: " + docProps.Subject);
                    Console.WriteLine("Slides count: " + docProps.Slides);
                    Console.WriteLine("Notes count: " + docProps.Notes);
                    Console.WriteLine();

                    // ----- Slide Structure -----
                    Console.WriteLine("=== Slides Overview ===");
                    System.Int32 slideCount = presentation.Slides.Count;
                    for (System.Int32 i = 0; i < slideCount; i++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[i];
                        Console.WriteLine("Slide " + (i + 1) + " - Name: " + slide.Name);

                        // Notes text (if any)
                        Aspose.Slides.INotesSlideManager notesMgr = slide.NotesSlideManager;
                        Aspose.Slides.INotesSlide notesSlide = notesMgr.NotesSlide;
                        if (notesSlide != null && notesSlide.NotesTextFrame != null)
                        {
                            Console.WriteLine("  Notes: " + notesSlide.NotesTextFrame.Text);
                        }

                        // Text from shapes on the slide
                        Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);
                        foreach (Aspose.Slides.ITextFrame tf in textFrames)
                        {
                            Console.WriteLine("  Shape Text: " + tf.Text);
                        }
                    }
                    Console.WriteLine();

                    // ----- Raw Text Extraction (Unarranged) -----
                    Console.WriteLine("=== Raw Text Extraction (Unarranged) ===");
                    Aspose.Slides.IPresentationText rawText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(inputPath, Aspose.Slides.TextExtractionArrangingMode.Unarranged);
                    Aspose.Slides.ISlideText[] slidesText = rawText.SlidesText;
                    for (System.Int32 i = 0; i < slidesText.Length; i++)
                    {
                        Aspose.Slides.ISlideText slideText = slidesText[i];
                        Console.WriteLine("Slide " + (i + 1) + " Text: " + slideText.Text);
                        Console.WriteLine("  Layout Text: " + slideText.LayoutText);
                        Console.WriteLine("  Master Text: " + slideText.MasterText);
                        Console.WriteLine("  Notes Text: " + slideText.NotesText);
                        Console.WriteLine("  Comments Text: " + slideText.CommentsText);
                    }

                    // Save the presentation (no modifications, just to satisfy requirement)
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}