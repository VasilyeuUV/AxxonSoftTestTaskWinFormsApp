namespace AxxonSoftTestTaskWinFormsApp.Models.Triangles
{
    /// <summary>
    /// Модель треугольника
    /// </summary>
    public class TriangleModel : ASquareableGeometricFigureBase
    {
        private const int _APEXESCOUNT = 3;                 // - количество вершин фигуры


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="coords"></param>
        public TriangleModel(IEnumerable<int> coords) : base(coords)
        {
            if (!CheckValidation()
                || CheckCollinear()
                )
                throw new InvalidDataException("The number of coordinates is wrong");
        }


        /// <summary>
        /// Координаты вершины А треугольника
        /// </summary>
        public Point A => Coordinates[0];

        /// <summary>
        /// Координаты вершины B треугольника
        /// </summary>
        public Point B => Coordinates[1];

        /// <summary>
        /// Координаты вершины C треугольника
        /// </summary>
        public Point C => Coordinates[2];



        //####################################################################################################################
        #region ASquareableGeometricFigureBase

        protected override bool CheckValidation()
        {
            return Coordinates.Length == _APEXESCOUNT;
        }


        protected override bool CheckCollinear()
        {
            return Coordinates.Where(p => p.X == A.X).Count() == _APEXESCOUNT
                   || Coordinates.Where(p => p.Y == A.Y).Count() == _APEXESCOUNT;
        }


        protected override double GetSquare()
        {
            return Math.Abs((B.X - A.X) * (C.Y - A.Y) - (C.X - A.X) * (B.Y - A.Y)) / 2;
        }

        #endregion // ASquareableGeometricFigureBase


    }
}
