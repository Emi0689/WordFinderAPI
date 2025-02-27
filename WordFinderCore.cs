namespace WordFinder
{
    public class WordFinder
    {
        private readonly char[][] _matrix;
        private readonly int _rows;
        private readonly int _cols;

        public WordFinder(IEnumerable<string> matrix)
        {
            if (matrix == null || !matrix.Any())
                throw new ArgumentException("Matrix cannot be null or empty");

            _matrix = matrix.Select(row => row.ToCharArray()).ToArray();
            _rows = _matrix.Length;
            _cols = _matrix[0].Length;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            if (wordstream == null || !wordstream.Any())
                return Enumerable.Empty<string>();

            HashSet<string> foundWords = new();
            Dictionary<string, int> wordCount = new();

            foreach (var word in wordstream.Distinct()) //EF: find just the distinct
            {
                if (ExistsInMatrix(word))
                {
                    foundWords.Add(word);
                    wordCount[word] = wordCount.GetValueOrDefault(word, 0) + 1;
                }
            }
            //EF: return the top 10 most repeated words
            return foundWords.OrderByDescending(w => wordCount[w]).Take(10);
        }

        private bool ExistsInMatrix(string word)
        {
            int wordLen = word.Length;
            if (wordLen > _cols && wordLen > _rows)
                return false;

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    if (CheckHorizontal(i, j, word) || CheckVertical(i, j, word))
                        return true;
                }
            }
            return false;
        }

        private bool CheckHorizontal(int row, int col, string word)
        {
            //EF: If the word is larger than the number of rows and columns, it is immediately discarded.
            if (col + word.Length > _cols)
                return false;

            for (int i = 0; i < word.Length; i++)
            {
                if (_matrix[row][col + i] != word[i])
                    return false;
            }
            return true;
        }

        private bool CheckVertical(int row, int col, string word)
        {
            //EF: If the word is larger than the number of rows and columns, it is immediately discarded.
            if (row + word.Length > _rows)
                return false;

            for (int i = 0; i < word.Length; i++)
            {
                if (_matrix[row + i][col] != word[i])
                    return false;
            }
            return true;
        }
    }
}
