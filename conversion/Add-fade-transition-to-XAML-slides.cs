using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTransitionXamlGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputXamlPath = "SlideTransitions.xaml";
            string outputPresentationPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Build XAML representation
                    StringBuilder xamlBuilder = new StringBuilder();
                    xamlBuilder.AppendLine("<SlideTransitions>");

                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        // Get transition type and duration
                        Aspose.Slides.SlideShow.TransitionType transitionType = pres.Slides[i].SlideShowTransition.Type;
                        int duration = pres.Slides[i].SlideShowTransition.Duration;

                        // Create XAML element for the slide transition
                        xamlBuilder.AppendFormat(
                            "  <SlideTransition Index=\"{0}\" Type=\"{1}\" Duration=\"{2}\" />",
                            i,
                            transitionType.ToString(),
                            duration);
                        xamlBuilder.AppendLine();
                    }

                    xamlBuilder.AppendLine("</SlideTransitions>");

                    // Write XAML to file
                    File.WriteAllText(outputXamlPath, xamlBuilder.ToString());

                    // Save presentation (even if unchanged) before exit
                    pres.Save(outputPresentationPath, SaveFormat.Pptx);
                }

                Console.WriteLine("XAML file generated at: " + outputXamlPath);
                Console.WriteLine("Presentation saved at: " + outputPresentationPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}