using System;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using FluentAssertions;

namespace Markdown.Tests
{
    [TestFixture]
    public class MdShould
    {
        private Md md;
        [SetUp]
        public void SetUp()
        {
            md = new Md();
        }

        [TestCase("_testword_tsd", "<em>testword</em>tsd", TestName = "Замена одинарных подчеркиваний")]
        [TestCase("__testword__tsd", "<strong>testword</strong>tsd", TestName = "Замена двойных подчеркиваний")]
        [TestCase("test\\_lol\\__word", "test_lol__word", TestName = "Проверка экранирования")]
        [TestCase("__test_word_tsd__", "<strong>test<em>word</em>tsd</strong>", TestName = "Одинарное выделение внутри двойного")]
        [TestCase("_test__word__tsd_", "<em>test__word__tsd</em>", TestName = "Двойное выделение внутри одинарного")]
        [TestCase("__testword_tsd", "__testword_tsd", TestName = "Непарное выделение")]
        [TestCase("_12_3", "_12_3", TestName = "Подчерки внутри текста с цифрами")]
        [TestCase("_ testword_", "_ testword_", TestName = "Пробел после открывающего подчеркивания")]
        [TestCase("_testword _", "_testword _", TestName = "Пробел перед закрывающим подчеркиванием")]
        [TestCase("#testword", "<h1>testword</h1>", TestName = "Заголовок")]
        [TestCase("_testword _", "_testword _", TestName = "Пробел перед закрывающим двойным подчеркиванием")]
        [TestCase("_ testword_", "_ testword_", TestName = "Пробел после открывающего двойного подчеркивания")]
        [TestCase("test\n***\nword", "test\n<hr/>\nword", TestName = "Горизонтальный разделитель")]
        [TestCase("``test`word``", "<code>test`word</code>", TestName = "Выделение кода")]
        public void RenderToHtml_CorrectTranslation(string input, string output)
        {
            md.RenderToHtml(input).Should().Be(output);
        }

        [TestFixture]
        public class MdTimeShouldBeLinear
        {
            private Md md;
            private string testStrings;

            [SetUp]
            public void SetUp()
            {
                md = new Md();
            }

            [Test, Timeout(100)]
            public void CheckTime()
            {
                var testStrings = TakeStringsFromFileWithName("testStrings2000");
                var stopWatch = new Stopwatch();
                for (var counter = 0; counter < 10; counter++)
                {
                    stopWatch.Restart();
                    md.RenderToHtml(testStrings);
                    stopWatch.Stop();
                }
                (stopWatch.Elapsed.Milliseconds).Should().BeLessThan(10);
            }

            private string TakeStringsFromFileWithName(string fileName)
            {
                var context = TestContext.CurrentContext;
                var combine = Path.Combine(
                    Directory.GetParent(context.TestDirectory).Parent.FullName,
                    fileName + ".txt"
                );
                return TakeStringsFromFile(combine);
            }

            private string TakeStringsFromFile(string path)
            {
                var resStr = "";
                using (var textReader = new StreamReader(path))
                {
                    string currStr;
                    while ((currStr = textReader.ReadLine()) != null)
                        resStr += currStr;
                }
                return resStr;
            }
        }
    }
}
