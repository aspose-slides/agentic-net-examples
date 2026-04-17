using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load presentation with exception handling for unsupported formats or other errors
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Format not supported or other loading error
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Iterate through each slide
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[i];
            Aspose.Slides.INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;
            bool hasBullet = false;

            // Check if notes slide exists and contains at least one bullet point
            if (notesSlide != null && notesSlide.NotesTextFrame != null)
            {
                foreach (Aspose.Slides.Paragraph paragraph in notesSlide.NotesTextFrame.Paragraphs)
                {
                    Aspose.Slides.IBulletFormatEffectiveData bulletEff = paragraph.ParagraphFormat.Bullet.GetEffective();
                    if (bulletEff.Type != Aspose.Slides.BulletType.None)
                    {
                        hasBullet = true;
                        break;
                    }
                }
            }

            if (hasBullet)
            {
                // Apply a transition only when notes contain bullet points
                slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                slide.SlideShowTransition.AdvanceOnClick = true;
                slide.SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds
            }
            else
            {
                Console.WriteLine($"Slide {i + 1} notes do not contain bullet points. Transition not applied.");
            }
        }

        // Save the modified presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
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