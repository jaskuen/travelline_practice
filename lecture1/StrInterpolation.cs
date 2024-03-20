public class StrInterpolate
{
    public static void Main(string[] args)
    {
        string name = "Victor";
        string surname = "Borge";

        string fullname = $"{name} {surname}";

        Console.WriteLine(fullname);
    }
}