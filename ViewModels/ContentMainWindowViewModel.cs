using AxxonSoftTestTaskWinFormsApp.Models.Triangles;

namespace AxxonSoftTestTaskWinFormsApp.ViewModels
{

    /// <summary>
    /// Вьюмодель содержимого главного окна
    /// </summary>
    public class ContentMainWindowViewModel : AViewModelBase  
    {
        private IEnumerable<TriangleModel> _triangles;

        /// <summary>
        /// Список треугольников
        /// </summary>
        public IEnumerable<TriangleModel> Triangles { get => _triangles; set => _triangles = value; }


    }
}
