public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
       //to be implemented
    }

    public void HideRandomWords(int numberToHide)
    {
        //to be implemented
    }
    public string GetDisplayText()
    {
        return "";
    }
    public bool IsCompletelyHidden()
    {
        return false;
    }
}