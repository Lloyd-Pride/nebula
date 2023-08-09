public static string Likes(List<string> names)
{
    if (names.Count == 0)
    {
        return "no one likes this";
    }
    else if (names.Count == 1)
    {
        return $"{names[0]} likes this";
    }
    else
    {
        string firstName = names[0];
        string others = string.Join(", ", names.Skip(1));
        return $"{firstName}, {others} and {names.Count - 2} others like this";
    }
}