using AxxonSoftTestTaskWinFormsApp.Interfaces.GeometricInterfaces;

namespace AxxonSoftTestTaskWinFormsApp.Models.Triangles
{
    /// <summary>
    /// Модель треугольника, который может содержать в себе площадные фигуры
    /// </summary>
    public class ParentTriangleModel : TriangleModel, IParental<ASquareableGeometricFigureBase>
    {
        private IEnumerable<ASquareableGeometricFigureBase>? _childs;


        ///// <summary>
        ///// Площадные фигуры, находящиеся внутри
        ///// </summary>
        //public IEnumerable<ASquareableGeometricFigureBase>? ChildFigures { get; set; }


        //###################################################################################################################
        #region TriangleModel


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="coords"></param>
        public ParentTriangleModel(IEnumerable<int> coords) : base(coords)
        {
        }

        #endregion // TriangleModel



        //###################################################################################################################
        #region IParental<ASquareableGeometricFigureBase>

        public IEnumerable<ASquareableGeometricFigureBase>? Childs
        {
            get 
            { 
                if (_childs == null) 
                    _childs = new List<ASquareableGeometricFigureBase>();
                return _childs; 
            }
        }

        #endregion // IParental<ASquareableGeometricFigureBase>

    }
}
