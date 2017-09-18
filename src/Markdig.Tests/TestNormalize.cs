// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using System;
using NUnit.Framework;
using Markdig.Syntax;

namespace Markdig.Tests
{
    [TestFixture]
    public class TestNormalize
    {
        [Test]
        public void TestNormalizeRoundtripCodeBlock()
        {
            AssertNormalizeNoTrim("    public void HelloWorld();\n    {\n    }");
            AssertNormalizeNoTrim("    public void HelloWorld();\n    {\n    }\n\ntext after two newlines");
            AssertNormalizeNoTrim("````\npublic void HelloWorld();\n{\n}\n````\n\ntext after two newlines");
            AssertNormalizeNoTrim("````csharp\npublic void HelloWorld();\n{\n}\n````"); 
            AssertNormalizeNoTrim("````csharp hideNewKeyword=true\npublic void HelloWorld();\n{\n}\n````");
        }

        [Test]
        public void TestNormalizeRoundtripHeading()
        {
            AssertNormalizeNoTrim("# Heading");
            AssertNormalizeNoTrim("## Heading");
            AssertNormalizeNoTrim("### Heading");
            AssertNormalizeNoTrim("#### Heading");
            AssertNormalizeNoTrim("##### Heading");
            AssertNormalizeNoTrim("###### Heading");
            AssertNormalizeNoTrim("###### Heading\n\ntext after two newlines");

            AssertNormalizeNoTrim("Heading\n=======\n\ntext after two newlines", "# Heading\n\ntext after two newlines");
        }

        [Test]
        public void TestNormalizeRoundtripHtml()
        {
            /*AssertNormalizeNoTrim(@"<div id=""foo"" class=""bar
  baz"">
</ div >");*/ // TODO: Bug: Throws Exception during emit 
        }

        [Test]
        public void TestNormalizeRoundtripParagraph()
        {
            AssertNormalizeNoTrim("This is a plain paragraph");
            AssertNormalizeNoTrim(@"This
is
a
plain
paragraph");
        }

        [Test]
        public void TestNormalizeRoundtripParagraphMulti()
        {
            AssertNormalizeNoTrim(@"line1

line2

line3");
        }

        [Test]
        public void TestNormalizeRoundtripListUnordered()
        {
            AssertNormalizeNoTrim(@"- a
- b
- c");
        }

        [Test]
        public void TestNormalizeRoundtripListOrdered()
        {
            AssertNormalizeNoTrim(@"1. a
2. b
3. c");
        }


        [Test]
        public void TestNormalizeRoundtripListOrderedAndIntended()
        {
            AssertNormalizeNoTrim(@"1. a
2. b
   - foo
   - bar
     a) 1234
     b) 1324
3. c
4. c
5. c
6. c
7. c
8. c
9. c
10. c
    - Foo
    - Bar
11. c
12. c");
        }

        [Test]
        public void TestNormalizeRoundtripHeaderAndParagraph()
        {
            AssertNormalizeNoTrim(@"# heading

paragraph

paragraph2 without newlines");
        }


        [Test]
        public void TestNormalizeRoundtripQuoteBlock()
        {
            AssertNormalizeNoTrim(@"> test1
> 
> test2");

            AssertNormalizeNoTrim(@"> test1
> -foobar

asdf

> test2
> -foobar sen.");
        }

        [Test]
        public void TestNormalizeRoundtripThematicBreak()
        {
            AssertNormalizeNoTrim("***\n");

            AssertNormalizeNoTrim("* * *\n", "***\n");
        }

        [Test]
        public void TestNormalizeRoundtripAutolinkInline()
        {
            AssertNormalizeNoTrim("This has a <auto.link.com>");
        }

        [Test]
        public void TestNormalizeRoundtripCodeInline()
        {
            AssertNormalizeNoTrim("This has a `HelloWorld()` in it");
            AssertNormalizeNoTrim(@"This has a ``Hello`World()`` in it");
        }

        [Test]
        public void TestNormalizeRoundtripEmphasisInline()
        {
            AssertNormalizeNoTrim("This is a plain **paragraph**");
            AssertNormalizeNoTrim("This is a plain *paragraph*");
            AssertNormalizeNoTrim("This is a plain _paragraph_");
            AssertNormalizeNoTrim("This is a plain __paragraph__");
            AssertNormalizeNoTrim("This is a pl*ai*n **paragraph**");
        }

        [Test]
        public void TestNormalizeRoundtripLineBreakInline()
        {
            AssertNormalizeNoTrim("normal\nline break");
            AssertNormalizeNoTrim("hard  \nline break");
        }

        [Test]
        public void TestNormalizeRoundtripLinkInline()
        {
            AssertNormalizeNoTrim("This is a [link](http://company.com)");
            AssertNormalizeNoTrim("This is an ![image](http://company.com)");

            AssertNormalizeNoTrim(@"This is a [link](http://company.com ""Crazy Company"")");
            AssertNormalizeNoTrim(@"This is a [link](http://company.com ""Crazy \"" Company"")");
        }

        [Test]
        public void TestNormalizeRoundtripHtmlEntityInline()
        {
            AssertNormalizeNoTrim("This is a &auml; blank");
        }

        [Test]
        public void TestNormalizeRoundtripHtmlInline()
        {
            AssertNormalizeNoTrim("foo <hr/> bar");
            AssertNormalizeNoTrim(@"foo <hr foo=""bar""/> bar");
        }

        public void AssertNormalizeNoTrim(string input, string expected = null)
            => AssertNormalize(input, expected, false);

        public void AssertNormalize(string input, string expected = null, bool trim = true)
        {
            expected = expected ?? input;
            input = NormText(input, trim);
            expected = NormText(expected, trim);

            var result = Markdown.Normalize(input);
            result = NormText(result, trim);

            Console.WriteLine("```````````````````Source");
            Console.WriteLine(TestParser.DisplaySpaceAndTabs(input));
            Console.WriteLine("```````````````````Result");
            Console.WriteLine(TestParser.DisplaySpaceAndTabs(result));
            Console.WriteLine("```````````````````Expected");
            Console.WriteLine(TestParser.DisplaySpaceAndTabs(expected));
            Console.WriteLine("```````````````````");
            Console.WriteLine();

            TextAssert.AreEqual(expected, result);
        }

        private static string NormText(string text, bool trim)
        {
            if (trim)
            {
                text = text.Trim();
            }
            return text.Replace("\r\n", "\n").Replace('\r', '\n');
        }
    }
}