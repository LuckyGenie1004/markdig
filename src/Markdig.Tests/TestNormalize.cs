// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license.
// See the license.txt file in the project root for more information.

using System;
using NUnit.Framework;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using System.IO;
using Markdig.Renderers.Normalize;
using Markdig.Helpers;

namespace Markdig.Tests
{
    [TestFixture]
    public class TestNormalize
    {
        [Test]
        public void SyntaxCodeBlock()
        {
            AssertSyntax("````csharp\npublic void HelloWorld()\n{\n}\n````", new FencedCodeBlock(null)
            {
                FencedChar = '`',
                FencedCharCount = 4,
                Info = "csharp",
                Lines = new StringLineGroup(4)
                {
                    new StringSlice("public void HelloWorld()"),
                    new StringSlice("{"),
                    new StringSlice("}"),
                }
            });

            AssertSyntax("    public void HelloWorld()\n    {\n    }", new CodeBlock(null)
            {
                Lines = new StringLineGroup(4)
                {
                    new StringSlice("public void HelloWorld()"),
                    new StringSlice("{"),
                    new StringSlice("}"),
                }
            });
        }

        [Test]
        public void SyntaxHeadline()
        {
            AssertSyntax("## Headline", new HeadingBlock(null)
            {
                HeaderChar = '#',
                Level = 2,
                Inline = new ContainerInline().AppendChild(new LiteralInline("Headline")),
            });
        }

        [Test]
        public void SyntaxParagraph()
        {
            AssertSyntax("This is a normal paragraph", new ParagraphBlock()
            {
                Inline = new ContainerInline()
                    .AppendChild(new LiteralInline("This is a normal paragraph")),
            });

            AssertSyntax("This is a\nnormal\nparagraph", new ParagraphBlock()
            {
                Inline = new ContainerInline()
                    .AppendChild(new LiteralInline("This is a"))
                    .AppendChild(new LineBreakInline())
                    .AppendChild(new LiteralInline("normal"))
                    .AppendChild(new LineBreakInline())
                    .AppendChild(new LiteralInline("paragraph")),
            });
        }

        [Test]
        public void CodeBlock()
        {
            AssertNormalizeNoTrim("    public void HelloWorld();\n    {\n    }");
            AssertNormalizeNoTrim("    public void HelloWorld();\n    {\n    }\ntext after two newlines");
            AssertNormalizeNoTrim("````\npublic void HelloWorld();\n{\n}\n````\ntext after two newlines");
            AssertNormalizeNoTrim("````csharp\npublic void HelloWorld();\n{\n}\n````");
            AssertNormalizeNoTrim("````csharp hideNewKeyword=true\npublic void HelloWorld();\n{\n}\n````");
        }

        [Test]
        public void Heading()
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
        public void Backslash()
        {
            AssertNormalizeNoTrim("This is a hardline  \nAnd this is another hardline\\\nThis is standard newline");
            AssertNormalizeNoTrim("This is a line\nWith another line\nAnd a last line");
        }

        [Test]
        public void HtmlBlock()
        {
            /*AssertNormalizeNoTrim(@"<div id=""foo"" class=""bar
  baz"">
</ div >");*/ // TODO: Bug: Throws Exception during emit
        }

        [Test]
        public void Paragraph()
        {
            AssertNormalizeNoTrim("This is a plain paragraph");
            AssertNormalizeNoTrim(@"This
is
a
plain
paragraph");
        }

        [Test]
        public void ParagraphMulti()
        {
            AssertNormalizeNoTrim(@"line1

line2

line3");
        }

        [Test]
        public void ListUnordered()
        {
            AssertNormalizeNoTrim(@"- a
- b
- c");
        }

        [Test]
        public void ListOrdered()
        {
            AssertNormalizeNoTrim(@"1. a
2. b
3. c");
        }


        [Test]
        public void ListOrderedAndIntended()
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
        public void HeaderAndParagraph()
        {
            AssertNormalizeNoTrim(@"# heading

paragraph

paragraph2 without newlines");
        }


        [Test]
        public void QuoteBlock()
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
        public void ThematicBreak()
        {
            AssertNormalizeNoTrim("***\n");

            AssertNormalizeNoTrim("* * *\n", "***\n");
        }

        [Test]
        public void AutolinkInline()
        {
            AssertNormalizeNoTrim("This has a <auto.link.com>");
        }

        [Test]
        public void CodeInline()
        {
            AssertNormalizeNoTrim("This has a `HelloWorld()` in it");
            AssertNormalizeNoTrim(@"This has a ``Hello`World()`` in it");
        }

        [Test]
        public void EmphasisInline()
        {
            AssertNormalizeNoTrim("This is a plain **paragraph**");
            AssertNormalizeNoTrim("This is a plain *paragraph*");
            AssertNormalizeNoTrim("This is a plain _paragraph_");
            AssertNormalizeNoTrim("This is a plain __paragraph__");
            AssertNormalizeNoTrim("This is a pl*ai*n **paragraph**");
        }

        [Test]
        public void LineBreakInline()
        {
            AssertNormalizeNoTrim("normal\nline break");
            AssertNormalizeNoTrim("hard  \nline break");
            AssertNormalizeNoTrim("This is a hardline  \nAnd this is another hardline\\\nThis is standard newline");
            AssertNormalizeNoTrim("This is a line\nWith another line\nAnd a last line");
        }

        [Test]
        public void LinkInline()
        {
            AssertNormalizeNoTrim("This is a [link](http://company.com)");
            AssertNormalizeNoTrim("This is an ![image](http://company.com)");

            AssertNormalizeNoTrim(@"This is a [link](http://company.com ""Crazy Company"")");
            AssertNormalizeNoTrim(@"This is a [link](http://company.com ""Crazy \"" Company"")");
        }

        [Test]
        public void EscapeInline()
        {
            AssertNormalizeNoTrim("This is an escape \\* with another \\[");
        }

        [Test]
        public void HtmlEntityInline()
        {
            AssertNormalizeNoTrim("This is a &auml; blank");
        }

        [Test]
        public void HtmlInline()
        {
            AssertNormalizeNoTrim("foo <hr/> bar");
            AssertNormalizeNoTrim(@"foo <hr foo=""bar""/> bar");
        }


        [Test]
        public void SpaceBetweenNodes()
        {
            AssertNormalizeNoTrim("# Hello World\nFoobar is a better bar.",
                                  "# Hello World\n\nFoobar is a better bar.");
        }

        [Test]
        public void SpaceBetweenNodesEvenForHeadlines()
        {
            AssertNormalizeNoTrim("# Hello World\n## Chapter 1\nFoobar is a better bar.",
                                  "# Hello World\n\n## Chapter 1\n\nFoobar is a better bar.");
        }

        [Test]
        public void SpaceRemoveAtStartAndEnd()
        {
            AssertNormalizeNoTrim("\n\n# Hello World\n## Chapter 1\nFoobar is a better bar.\n\n",
                                  "# Hello World\n\n## Chapter 1\n\nFoobar is a better bar.");
        }

        [Test]
        public void SpaceShortenBetweenNodes()
        {
            AssertNormalizeNoTrim("# Hello World\n\n\n\nFoobar is a better bar.",
                                  "# Hello World\n\nFoobar is a better bar.");
        }

        [Test]
        public void BiggerSample()
        {
            var input = @"# Heading 1

This is a paragraph

This is another paragraph

- This is a list item 1
- This is a list item 2
- This is a list item 3

```C#
This is a code block
```

> This is a quote block

    This is an indented code block
    line 2 of indented
This is a last line
";
            var result = @"# Heading 1

This is a paragraph

This is another paragraph

- This is a list item 1
- This is a list item 2
- This is a list item 3

```C#
This is a code block
```
> This is a quote block

    This is an indented code block
    line 2 of indented
This is a last line";

            AssertNormalizeNoTrim(input, result);
        }

        private static void AssertSyntax(string expected, MarkdownObject syntax)
        {
            var writer = new StringWriter();
            var normalizer = new NormalizeRenderer(writer);
            var document = new MarkdownDocument();
            if (syntax is Block)
            {
                document.Add(syntax as Block);
            }
            else
            {
                throw new InvalidOperationException();
            }
            normalizer.Render(document);

            var actual = writer.ToString();

            Assert.AreEqual(expected, actual);
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