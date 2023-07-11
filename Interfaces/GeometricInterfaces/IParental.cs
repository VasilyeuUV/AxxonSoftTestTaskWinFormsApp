namespace AxxonSoftTestTaskWinFormsApp.Interfaces.GeometricInterfaces
{
    /// <summary>
    /// Контракт родительского объекта
    /// </summary>
    public interface IParental<out T> where T : class
    {
        /// <summary>
        /// Объекты, принадлежащие родителю
        /// </summary>
        IEnumerable<T>? Childs { get; }
    }
}
