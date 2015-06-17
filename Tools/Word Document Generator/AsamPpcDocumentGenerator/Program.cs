using System;
using System.IO;
using WordDocumentGenerator.Library;

namespace AsamPpcDocumentGenerator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Started execution of samples ...");
            Console.WriteLine("Generated documents will be saved to - " + Directory.GetCurrentDirectory ());
            Console.WriteLine();
            var generationInfo = GetDocumentGenerationInfo("AsamPpcGenerator", "1.0", "ASAMSection.docx", false);

            var sampleDocumentGenerator = new AsamPpcGenerator(generationInfo);
            var result = sampleDocumentGenerator.GenerateDocument(true);
            WriteOutputToFile("ASAM PPC R2.docx", "ASAMSection.docx", result);        

            Console.WriteLine();
            Console.WriteLine("Execution Completed.");
            Console.ReadKey();
        }

        /// <summary>
        /// Gets the document generation info.
        /// </summary>
        /// <param name="docType">Type of the doc.</param>
        /// <param name="docVersion">The doc version.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="useDataBoundControls">if set to <c>true</c> [use data bound controls].</param>
        /// <returns></returns>
        private static DocumentGenerationInfo GetDocumentGenerationInfo(string docType, string docVersion, string fileName, bool useDataBoundControls)
        {
            var generationInfo = new DocumentGenerationInfo();
            generationInfo.Metadata = new DocumentMetadata() { DocumentType = docType, DocumentVersion = docVersion };
            generationInfo.TemplateData = File.ReadAllBytes(fileName);
            generationInfo.IsDataBoundControls = useDataBoundControls;

            return generationInfo;
        }

        /// <summary>
        /// Writes the output to file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="templateName">Name of the template.</param>
        /// <param name="fileContents">The file contents.</param>
        private static void WriteOutputToFile(string fileName, string templateName, byte[] fileContents)
        {
            ConsoleColor consoleColor = Console.ForegroundColor;

            if (fileContents != null)
            {
                File.WriteAllBytes(fileName, fileContents);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(string.Format("Generation succeeded for template({0}) --> {1}", templateName, fileName));
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Format("Generation failed for template({0}) --> {1}", templateName, fileName));
            }

            Console.ForegroundColor = consoleColor;
        }
    }
}
