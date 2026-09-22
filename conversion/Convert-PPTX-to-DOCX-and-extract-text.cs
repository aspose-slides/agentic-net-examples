// -----------------------------------------------------------------------------
// Example: Convert PPTX to DOCX and Extract Text Using Aspose.Slides and Aspose.Words
//
// Description:
// This console application loads a PowerPoint PPTX file with Aspose.Slides, extracts
// all textual content, creates a DOCX document using Aspose.Words via reflection,
// saves the DOCX, then reads the DOCX back to retrieve the text. The workflow
// demonstrates PPTX‑to‑DOCX conversion and text analysis without requiring compile‑time
// references to Aspose.Words, handling missing assemblies gracefully.
//
// Keywords:
// C#, PowerPoint, PPTX, DOCX, Aspose.Slides for .NET, Aspose.Words for .NET, text extraction, conversion
//
// Use Cases:
// - Automate conversion of presentation content into editable Word documents.
// - Perform bulk analysis of slide text by extracting it into a searchable format.
// - Integrate PPTX to DOCX pipelines in document management or content indexing systems.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;
using System.Reflection;

namespace AsposeSlidesWordExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Define input and output file names
            string inputFileName = "input.pptx";
            string outputDocxName = "output.docx";

            // Build full paths
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string inputFilePath = System.IO.Path.Combine(currentDirectory, inputFileName);
            string outputDocxPath = System.IO.Path.Combine(currentDirectory, outputDocxName);

            // Verify that the PPTX file exists
            if (!System.IO.File.Exists(inputFilePath))
            {
                Console.WriteLine("Input PPTX file not found: " + inputFilePath);
                return;
            }

            // Load the presentation and extract all text
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load PPTX file: " + ex.Message);
                return;
            }

            StringBuilder extractedBuilder = new StringBuilder();

            try
            {
                Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(
                    inputFilePath,
                    Aspose.Slides.TextExtractionArrangingMode.Unarranged);

                for (int i = 0; i < presentationText.SlidesText.Length; i++)
                {
                    Aspose.Slides.ISlideText slideText = presentationText.SlidesText[i];
                    extractedBuilder.AppendLine(slideText.Text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during text extraction: " + ex.Message);
                presentation.Dispose();
                return;
            }

            string extractedText = extractedBuilder.ToString();

            // Attempt to create a DOCX using Aspose.Words via reflection
            Type documentType = Type.GetType("Aspose.Words.Document, Aspose.Words");
            if (documentType == null)
            {
                Console.WriteLine("Aspose.Words assembly not found. Skipping DOCX creation.");
                presentation.Dispose();
                return;
            }

            object wordDocument = null;
            try
            {
                // Create a new empty Document
                wordDocument = Activator.CreateInstance(documentType);

                // Create a DocumentBuilder for the document
                Type builderType = Type.GetType("Aspose.Words.DocumentBuilder, Aspose.Words");
                ConstructorInfo builderCtor = builderType.GetConstructor(new Type[] { documentType });
                object builder = builderCtor.Invoke(new object[] { wordDocument });

                // Write the extracted text into the document
                MethodInfo writeMethod = builder.GetType().GetMethod("Write", new Type[] { typeof(string) });
                writeMethod.Invoke(builder, new object[] { extractedText });

                // Save the document as DOCX
                MethodInfo saveMethod = documentType.GetMethod("Save", new Type[] { typeof(string) });
                saveMethod.Invoke(wordDocument, new object[] { outputDocxPath });
            }
            catch (TargetInvocationException tie)
            {
                Console.WriteLine("Error during DOCX creation: " + tie.InnerException.Message);
                presentation.Dispose();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error during DOCX creation: " + ex.Message);
                presentation.Dispose();
                return;
            }

            // Load the generated DOCX and extract its text
            try
            {
                object loadedDoc = Activator.CreateInstance(documentType, new object[] { outputDocxPath });
                MethodInfo getTextMethod = documentType.GetMethod("GetText", Type.EmptyTypes);
                string docxText = (string)getTextMethod.Invoke(loadedDoc, null);

                Console.WriteLine("Extracted text from generated DOCX:");
                Console.WriteLine(docxText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading DOCX file: " + ex.Message);
            }

            // Clean up
            presentation.Dispose();
        }
    }
}
