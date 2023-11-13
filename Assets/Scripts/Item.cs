[System.Serializable]
public class Item
{
    public static int Typefood = 1;
    public const int Typeflow = 2;

    public string Name;
    public string ImgUrl;
    public int Type;
    public int Count;
    public int Price;
    public int LvlWhenUnlock;
    public float TimeToReady;

    public Item(string name, string imgUrl, int count, int type, int price, int lvlWhenUnlock, float timeToReady)
    {
        Name = name;
        ImgUrl = imgUrl;
        Count = count;
        Type = type;
        Price = price;
        LvlWhenUnlock = lvlWhenUnlock;
        TimeToReady = timeToReady;
    }
}
