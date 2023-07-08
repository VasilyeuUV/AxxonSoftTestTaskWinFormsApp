using AxxonSoftTestTaskWinFormsApp.Interfaces.GeometricInterfaces;

namespace AxxonSoftTestTaskWinFormsApp.Models
{

    public abstract class ASquareableGeometricFigureBase : AGeometricFigure2DBase, ISquareable
    {

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="coords"></param>
        protected ASquareableGeometricFigureBase(IEnumerable<int> coords) : base(coords)
        {
            S = GetSquare();
        }



        //############################################################################################################
        #region ISquareable

        public double S { get; private set; }

        #endregion // ISquareable


        /// <summary>
        /// Метод вычисления площади 2D фигуры
        /// </summary>
        /// <returns></returns>
        protected abstract double GetSquare();


        /// <summary>
        /// Проверка фигуры на коллинеарность 
        /// (когда координаты располагаются на одной линии). 
        /// Такие фигуры не могут быть коллинеарными
        /// </summary>
        /// <returns></returns>
        protected abstract bool CheckCollinear();
    }
}
