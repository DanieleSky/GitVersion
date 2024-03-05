namespace GitVersion.Core.Tests;

public static class MockCollectionExtensions
{
    private static IEnumerator<T> GetEnumerator<T>(params T[] itemsToReturn)
    {
        foreach (var item in itemsToReturn)
        {
            yield return item;
        }
    }

    public static void MockCollectionReturn<T>(this IEnumerable<T> items, params T[] itemsToReturn)
        => items.GetEnumerator().Returns(_ => GetEnumerator(itemsToReturn));
}
