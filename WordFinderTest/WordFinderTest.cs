
namespace WordFinderTest
{
    public class WordFinderTest
    {
        [Fact]
        public void FindWords_ShouldReturnCorrectWords()
        {
            var matrix = new List<string> { "chill", "wind", "cold" };
            var wordFinder = new WordFinder.WordFinder(matrix);
            var wordstream = new List<string> { "chill", "hot", "wind", "cold", "cold" };

            var result = wordFinder.Find(wordstream);

            Assert.Contains("chill", result);
            Assert.Contains("wind", result);
            Assert.Contains("cold", result);
            Assert.DoesNotContain("hot", result);
        }

        [Fact]
        public void FindWords_ShouldDetectHorizontalWords()
        {
            var matrix = new List<string> { "hello", "world", "abcde" };
            var wordFinder = new WordFinder.WordFinder(matrix);
            var wordstream = new List<string> { "hello", "world", "abcde", "test" };

            var result = wordFinder.Find(wordstream);

            Assert.Contains("hello", result);
            Assert.Contains("world", result);
            Assert.Contains("abcde", result);
            Assert.DoesNotContain("test", result);
        }

        [Fact]
        public void FindWords_ShouldDetectVerticalWords()
        {
            var matrix = new List<string> { "hxa", "eyb", "lzc", "lod" };
            var wordFinder = new WordFinder.WordFinder(matrix);
            var wordstream = new List<string> { "hell", "lod" };

            var result = wordFinder.Find(wordstream);

            Assert.Contains("hell", result);
            Assert.Contains("lod", result);
        }
    }
}