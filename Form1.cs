using AxxonSoftTestTaskWinFormsApp.Models.Triangles;

namespace AxxonSoftTestTaskWinFormsApp
{
    public partial class Form1 : Form
    {
        Bitmap bmp;                             //Здесь рисуем

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(this.pbMain.ClientSize.Width, this.pbMain.ClientSize.Height);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            int[] arr = { 50, 100, 50, 200, 150, 300 };

            var triangle = new TriangleModel(arr);

            /// Здесь рисуем на битмап. А затем этот битмап назначаем свойству Image.
            /// Поскольку объекты Graphics нужно сразу уничтожать после использования,
            /// то всегда пользуемся конструкцией using. Она сама уничтожит объект при
            /// выходе.
            using (Graphics g = Graphics.FromImage(bmp))
            {
                /// Рисование на белом фоне. Делаем заливку белым цветом
                g.Clear(Color.Lime);
                //g.DrawLine(Pens.Black, 10, 10, 40, 40);
                g.FillPolygon(new SolidBrush(Color.Blue), triangle.Coordinates);

            }
            /// Назначаем наш Bitmap свойству Image
            this.pbMain.Image = bmp;




        }
    }
}