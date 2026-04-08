using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RevisionChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string presentationPath = "input.pptx";
            string vcsRevisionPath = "vcs_revision.txt";

            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    int builtInRevision = presentation.DocumentProperties.RevisionNumber;
                    Console.WriteLine("Built‑in revision number: " + builtInRevision);

                    int externalRevision = -1;
                    if (File.Exists(vcsRevisionPath))
                    {
                        string revText = File.ReadAllText(vcsRevisionPath).Trim();
                        int.TryParse(revText, out externalRevision);
                    }
                    else
                    {
                        Console.WriteLine("External revision file not found: " + vcsRevisionPath);
                    }

                    if (externalRevision >= 0)
                    {
                        if (builtInRevision != externalRevision)
                        {
                            Console.WriteLine("Revision mismatch! Built‑in: " + builtInRevision + ", VCS: " + externalRevision);
                        }
                        else
                        {
                            Console.WriteLine("Revisions match.");
                        }
                    }

                    // Save the presentation before exiting (could be to a new file)
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex) // Replaces non‑existent SlideException
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}