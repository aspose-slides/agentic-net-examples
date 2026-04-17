using System;
using System.IO;
using System.Text;
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace SlidesBackupApp
{
    class Program
    {
        // Interval for backup in milliseconds (e.g., 1 minute)
        private const int BackupInterval = 60000;

        static void Main(string[] args)
        {
            // Paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string backupPath = "backup.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load presentation (may throw NotSupportedException for unsupported formats)
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Set up periodic backup using a timer
            Timer backupTimer = new Timer(state =>
            {
                try
                {
                    PerformBackup(presentation, backupPath);
                }
                catch (Exception ex)
                {
                    // Handle any exception that may occur during backup (e.g., network issues)
                    Console.WriteLine("Backup failed: " + ex.Message);
                }
            }, null, 0, BackupInterval);

            Console.WriteLine("Press Enter to exit and save the presentation...");
            Console.ReadLine();

            // Dispose timer
            backupTimer.Dispose();

            // Save presentation before exit
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Clean up
            presentation.Dispose();
        }

        // Extracts comments and notes from the presentation and writes them to a backup file
        private static void PerformBackup(Aspose.Slides.Presentation pres, string backupFilePath)
        {
            StringBuilder sb = new StringBuilder();

            // Iterate through slides
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[i];
                sb.AppendLine($"--- Slide {i + 1} ---");

                // Get all comments on the slide
                Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);
                foreach (Aspose.Slides.IComment comment in comments)
                {
                    sb.AppendLine($"Comment by {comment.Author.Name} at {comment.CreatedTime}: {comment.Text}");
                }

                // Get notes text if a notes slide exists
                Aspose.Slides.INotesSlideManager notesManager = slide.NotesSlideManager;
                Aspose.Slides.INotesSlide notesSlide = notesManager.NotesSlide;
                if (notesSlide != null && notesSlide.NotesTextFrame != null)
                {
                    sb.AppendLine("Notes: " + notesSlide.NotesTextFrame.Text);
                }

                sb.AppendLine();
            }

            // Simulate cloud storage upload by writing to a file
            // In a real scenario, replace this with actual cloud SDK calls wrapped in try-catch
            File.WriteAllText(backupFilePath, sb.ToString());
            Console.WriteLine("Backup completed at " + DateTime.Now);
        }
    }
}