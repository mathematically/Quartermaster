namespace Mathematically.Quartermaster.Domain.Items
{
    public interface IItemTextSanityCheck
    {
        /// <summary>
        /// Applies a basic sanity check to the supplied text to determine if it looks like a PoE item.
        /// </summary>
        /// <param name="text">The text that potentially describes a PoE item.</param>
        /// <returns>true if the specified text is potentially PoE item text, else false.</returns>
        bool LooksLikeGameText(string text);
    }
}