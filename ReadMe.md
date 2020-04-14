Tom Swift Under Milkwood - Kata
--------------------

This C# Library uses Trigram analysis to take a piece of text and generate a new piece of text.

Trigram analysis is very simple. Look at each set of three adjacent words in a document. Use the first two words of the set as a key, and remember the fact that the third word followed that key. Once you’ve finished, you know the list of individual words that can follow each two word sequence in the document.

To generate new text from this analysis, choose an arbitrary word pair as a starting point. Use these to look up a random next word (using the table above) and append this new word to the text so far. This now gives you a new word pair at the end of the text, so look up a potential next word based on these. Add this to the list, and so on. 

 In this one, what we’re experimenting with is not just the code, but the heuristics of processing the text. What do we do with punctuation? Paragraphs? Do we have to implement backtracking if we chose a next word that turns out to be a dead end?

Refer to http://codekata.com/kata/kata14-tom-swift-under-the-milkwood/ for more information.
