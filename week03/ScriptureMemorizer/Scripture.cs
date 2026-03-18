public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
       _reference = reference;
        string[] parts = text.Split(" ");

       foreach (string wordText in parts)
       {
           Word word = new Word(wordText);
           _words.Add(word);
       }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(_words.Count);
            Word word = _words[index];
            word.Hide();
        }

    }
    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + " - ";
        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }
        return result;
    }
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}