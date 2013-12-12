using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoicesParser;
using NUnit.Framework;
using Autofac;

namespace InvoicesParses.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        private IInvoiceParser _invoiceParser;

        [TestFixtureSetUp]
        public void SetUp()
        {
            var invoiceParserContainerCreator = new InvoiceParserContainerCreator();
            var container = invoiceParserContainerCreator.GetContainer();
            _invoiceParser = container.Resolve<IInvoiceParser>();
        }

        [TestCase("input_user_story_1.txt", "output_user_story_1.txt")]
        [TestCase("input_user_story_2.txt", "output_user_story_2.txt")]
        public void Parse_UserStoryFile_ParsingAsExpectedFile(string inputFilename, string expectedFilename)
        {
            var inputLines = File.ReadAllLines(inputFilename);
            var expectedOutputLines = File.ReadAllLines(expectedFilename);

            var outputLines = _invoiceParser.Parse(inputLines);

            Assert.That(outputLines, Is.EqualTo(expectedOutputLines));
        }
    }
}
