
using System;
using NSubstitute;
using Xunit;
namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class HikerTest
    {
        [Fact]
        public void Converts_text_file_to_html()
        {
            var filename = "foobar.txt";
            var fileContents = $"<>&\"\'foo{Environment.NewLine}foo";
            var expectedText = "&lt;&gt;&amp;&quot;&quot;foo<br />foo";
            var fileReader = Substitute.For<IFileReader>();
            fileReader.Read(filename).Returns(fileContents);

            var sut = new UnicodeFileToHtmlTextConverter(fileReader);

            Assert.Equal(expectedText, sut.ConvertToHtml(filename));
        }
    }
}
