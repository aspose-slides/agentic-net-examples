// -----------------------------------------------------------------------------
// Example: Read revision number and compare with VCS using C#
//
// Description:
// Demonstrates how to read the built‑in revision number from a PowerPoint
// presentation, retrieve an external revision number stored in a VCS file,
// compare the two values, and report any mismatches. The example also shows
// how to save the presentation after processing using Aspose.Slides for .NET.
// This pattern can be used to integrate version‑control checks into automated
// PowerPoint workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Revision Number, VCS,
// Compare, Presentation Processing, Office Automation, Document Properties
//
// Use Cases:
// - Verify that a presentation's internal revision matches the version‑control
//   revision before publishing.
// - Build command‑line tools that enforce revision consistency across files.
// - Automate validation steps in CI/CD pipelines for PowerPoint assets.
// - Generate reports on revision discrepancies for documentation teams.
// -----------------------------------------------------------------------------
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
