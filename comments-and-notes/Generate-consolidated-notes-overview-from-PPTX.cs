using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace NotesOverviewApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load the presentation
                var presentationPath = "input.pptx";
                using (var presentation = new Aspose.Slides.Presentation(presentationPath))
                {
                    var notesBuilder = new StringBuilder();

                    // Iterate through each slide and extract notes
                    for (var i = 0; i < presentation.Slides.Count; i++)
                    {
                        var slide = presentation.Slides[i];
                        var notesManager = slide.NotesSlideManager;
                        var notesSlide = notesManager.NotesSlide;

                        if (notesSlide != null && notesSlide.NotesTextFrame != null)
                        {
                            var notesText = notesSlide.NotesTextFrame.Text;
                            notesBuilder.AppendLine($"Slide {slide.SlideNumber}:");
                            notesBuilder.AppendLine(notesText);
                            notesBuilder.AppendLine();
                        }
                        else
                        {
                            notesBuilder.AppendLine($"Slide {slide.SlideNumber}: (No notes)");
                            notesBuilder.AppendLine();
                        }
                    }

                    // Save the consolidated notes to a text file
                    File.WriteAllText("NotesOverview.txt", notesBuilder.ToString());

                    // Save the presentation before exiting
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}