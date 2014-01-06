namespace Mathematically.Quartermaster.Domain.Parser
{
    public interface IItemTextChecker
    {
        /// <summary>
        /// Applies a basic sanity check to the supplied text to determine if it looks like a PoE item.
        /// </summary>
        /// <param name="itemText">The text that potentially describes a PoE item.</param>
        /// <returns>true if the specified text is potentially PoE item text, else false.</returns>
        bool LooksLikeGameText(string itemText);
    }
}