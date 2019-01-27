// Generated: 21. 01. 2019 14:26:34

// --------------------------------
//               Media
// --------------------------------

using System;
using NUnit.Framework;

namespace Markdig.Tests.Specs.Media
{
    [TestFixture]
    public class TestExtensionsMediaLinks
    {
        // # Extensions
        // 
        // Adds support for media links:
        // 
        // ## Media links
        //  
        // Allows to embed audio/video links to popular website:
        [Test]
        public void ExtensionsMediaLinks_Example001()
        {
            // Example 1
            // Section: Extensions / Media links
            //
            // The following Markdown:
            //     ![Video1](https://www.youtube.com/watch?v=mswPy5bt3TQ)
            //     
            //     ![Video2](https://vimeo.com/8607834)
            //     
            //     ![Video3](https://sample.com/video.mp4)
            //     
            //     ![Audio4](https://music.yandex.ru/album/411845/track/4402274)
            //     
            //     ![Video5](https://ok.ru/video/26870090463)
            //
            // Should be rendered as:
            //     <p><iframe src="https://www.youtube.com/embed/mswPy5bt3TQ" width="500" height="281" frameborder="0" allowfullscreen=""></iframe></p>
            //     <p><iframe src="https://player.vimeo.com/video/8607834" width="500" height="281" frameborder="0" allowfullscreen=""></iframe></p>
            //     <p><video width="500" height="281" controls=""><source type="video/mp4" src="https://sample.com/video.mp4"></source></video></p>
            //     <p><iframe src="https://music.yandex.ru/iframe/#track/4402274/411845/" width="500" height="281" frameborder="0"></iframe></p>
            //     <p><iframe src="https://ok.ru/videoembed/26870090463" width="500" height="281" frameborder="0" allowfullscreen=""></iframe></p>

            Console.WriteLine("Example 1\nSection Extensions / Media links\n");
            TestParser.TestSpec("![Video1](https://www.youtube.com/watch?v=mswPy5bt3TQ)\n\n![Video2](https://vimeo.com/8607834)\n\n![Video3](https://sample.com/video.mp4)\n\n![Audio4](https://music.yandex.ru/album/411845/track/4402274)\n\n![Video5](https://ok.ru/video/26870090463)", "<p><iframe src=\"https://www.youtube.com/embed/mswPy5bt3TQ\" width=\"500\" height=\"281\" frameborder=\"0\" allowfullscreen=\"\"></iframe></p>\n<p><iframe src=\"https://player.vimeo.com/video/8607834\" width=\"500\" height=\"281\" frameborder=\"0\" allowfullscreen=\"\"></iframe></p>\n<p><video width=\"500\" height=\"281\" controls=\"\"><source type=\"video/mp4\" src=\"https://sample.com/video.mp4\"></source></video></p>\n<p><iframe src=\"https://music.yandex.ru/iframe/#track/4402274/411845/\" width=\"500\" height=\"281\" frameborder=\"0\"></iframe></p>\n<p><iframe src=\"https://ok.ru/videoembed/26870090463\" width=\"500\" height=\"281\" frameborder=\"0\" allowfullscreen=\"\"></iframe></p>", "medialinks|advanced+medialinks");
        }
    }
}
