using AxxonSoftTestTaskWinFormsApp.Models.Triangles;

namespace AxxonSoftTestTaskWinFormsApp
{
    public partial class Form1 : Form
    {
        Bitmap bmp;                             //����� ������

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(this.pbMain.ClientSize.Width, this.pbMain.ClientSize.Height);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            int[] arr = { 50, 100, 50, 200, 150, 300 };

            var triangle = new TriangleModel(arr);

            /// ����� ������ �� ������. � ����� ���� ������ ��������� �������� Image.
            /// ��������� ������� Graphics ����� ����� ���������� ����� �������������,
            /// �� ������ ���������� ������������ using. ��� ���� ��������� ������ ���
            /// ������.
            using (Graphics g = Graphics.FromImage(bmp))
            {
                /// ��������� �� ����� ����. ������ ������� ����� ������
                g.Clear(Color.Lime);
                //g.DrawLine(Pens.Black, 10, 10, 40, 40);
                g.FillPolygon(new SolidBrush(Color.Blue), triangle.Coordinates);

            }
            /// ��������� ��� Bitmap �������� Image
            this.pbMain.Image = bmp;




        }
    }
}