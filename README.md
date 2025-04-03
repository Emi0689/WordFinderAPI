This is an API that receives a list of words as an array and tries to find a certain number of words in that array (WordFinder).

![image](https://github.com/user-attachments/assets/9b4324b4-31af-4201-8bbb-091a10227dcd)

The WordFinder constructor receives a set of strings which represents a character matrix. The
matrix size does not exceed 64x64, all strings contain the same number of characters. The
"Find" method should return the top 10 most repeated words from the word stream found in the
matrix. If no words are found, the "Find" method should return an empty set of strings. If any
word in the word stream is found more than once within the stream, the search results
should count it only once
