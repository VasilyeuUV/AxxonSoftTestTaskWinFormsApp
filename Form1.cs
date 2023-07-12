using AxxonSoftTestTaskWinFormsApp.Models.Triangles;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace AxxonSoftTestTaskWinFormsApp
{
    public partial class Form1 : Form
    {
        Bitmap bmp;                             //Здесь рисуем


        private readonly int[,] canvas = new int[1000, 1000];



        public Form1()
        {
            InitializeComponent();

            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.RowHeadersWidth = 70;

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            IEnumerable<int[]> trianglesCoords = new List<int[]>
            {
                new int[] {90, 30, 90, 40, 80, 40 },
                new int[] {150, 130, 0, 90, 100, 0 },
                new int[] {20, 80, 80, 70, 50, 100 },
                new int[] {60, 100, 120, 80, 140, 120 },
                new int[] {100, 100, 120, 100, 120, 90 },
                new int[] {30, 70, 100, 10, 110, 60 },
                new int[] {60, 50, 60, 60, 90, 60 },
                new int[] {100, 20, 100, 50, 70, 40 },

            };

            List<TriangleModel> triangles = new List<TriangleModel>();
            foreach (var item in trianglesCoords)
            {
                triangles.Add(new TriangleModel(item));
            }
            var orderedTriangles = triangles.OrderByDescending(t => t.S);


            var maxTriangle = triangles.FirstOrDefault(t => t.S == triangles.Max(t => t.S));


            var minX = maxTriangle?.Coordinates.Min(p => p.X);
            var maxX = maxTriangle?.Coordinates.Max(p => p.X);
            var minY = maxTriangle?.Coordinates.Min(p => p.Y);
            var maxY = maxTriangle?.Coordinates.Max(p => p.Y);


            var colors = new Color[]
            {
                Color.AntiqueWhite, Color.Blue, Color.Red, Color.Yellow, Color.Azure, Color.CadetBlue, Color.DarkSalmon,  Color.Orange
            };



            var minAllX = (int)triangles?.Min(p => p.Coordinates.Min(c => c.X));
            var maxAllX = (int)triangles?.Max(p => p.Coordinates.Max(c => c.X));
            var minAllY = (int)triangles?.Min(p => p.Coordinates.Min(c => c.Y));
            var maxAllY = (int)triangles?.Max(p => p.Coordinates.Max(c => c.Y));

            bmp = new Bitmap(maxAllX, maxAllY);
            var pixelFormat = bmp.PixelFormat.ToString();
            Rectangle rect = new Rectangle(minAllX, minAllY, maxAllX, maxAllY);


            var intRectangle = new int[maxAllX * maxAllY];
            int[,] arr22 = new int[maxAllX, maxAllY];


            //int[] arr = { 0, 200, 100, 100, 200, 50 };
            //var triangle = new TriangleModel(arr);

            /// Здесь рисуем на битмап. А затем этот битмап назначаем свойству Image.
            /// Поскольку объекты Graphics нужно сразу уничтожать после использования,
            /// то всегда пользуемся конструкцией using. Она сама уничтожит объект при
            /// выходе.
            using (Graphics g = Graphics.FromImage(bmp))
            {
                /// Рисование на белом фоне. Делаем заливку белым цветом
                //g.Clear(Color.Transparent);
                //g.DrawLine(Pens.Black, 10, 10, 40, 40);

                var i = -1;
                foreach (var triangle in orderedTriangles)
                {
                    g.Clear(Color.Transparent);

                    var color = colors[++i];
                    g.FillPolygon(new SolidBrush(color), triangle.Coordinates);


                    BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
                    byte[] rgbValues = new byte[bytes];
                    Marshal.Copy(ptr, rgbValues, 0, bytes);
                    for (int counter = 0, k = 0; counter < rgbValues.Length; counter += 4, k++)
                    {
                        if (
                            rgbValues[counter] != 0               // blue
                            || rgbValues[counter + 1] != 0        // green
                            || rgbValues[counter + 2] != 0        // red
                            )
                            ++intRectangle[k];
                    }

                    Marshal.Copy(rgbValues, 0, ptr, bytes);
                    bmp.UnlockBits(bmpData);

                    g.FillPolygon(new SolidBrush(color), triangle.Coordinates);
                }


            }

            var maxValue = intRectangle.Max();

            /// Назначаем наш Bitmap свойству Image
            this.pbMain.Image = bmp;


            //for (int i = 0; i < bmp.Width; i++)
            //{
            //    for (int j = 0; j < bmp.Height; j++)
            //    {
            //        Color pixel = bmp.GetPixel(i, j);
            //    }
            //}


            int m = 0, n = 0;
            foreach (var item in intRectangle)
            {
                arr22[m, n] = item;

                if (++m >= maxAllX)
                {
                    m = 0;
                    ++n;
                }

            }


            var a = arr22.GetLength(0) - 1;
            var b = arr22.GetLength(1) - 1;



            var isIntersection = (from j in Enumerable.Range(1, arr22.GetLength(1) - 2)
                                  from i in Enumerable.Range(1, arr22.GetLength(0) - 2)
                                  where Math.Abs(arr22[i, j] - arr22[i - 1, j]) > 1
                                     || Math.Abs(arr22[i, j] - arr22[i + 1, j]) > 1
                                     || Math.Abs(arr22[i, j] - arr22[i, j - 1]) > 1
                                     || Math.Abs(arr22[i, j] - arr22[i, j + 1]) > 1
                                     || Math.Abs(arr22[i, j] - arr22[i - 1, j - 1]) > 1
                                     || Math.Abs(arr22[i, j] - arr22[i - 1, j + 1]) > 1
                                     || Math.Abs(arr22[i, j] - arr22[i + 1, j - 1]) > 1
                                     || Math.Abs(arr22[i, j] - arr22[i + 1, j + 1]) > 1
                                  select (i, j))
                                .FirstOrDefault() == default;







            //var pixelFormat = bmp.PixelFormat.ToString();
            //Rectangle rect = new Rectangle(minAllX, minAllY, maxAllX, maxAllY);
            //BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            //IntPtr ptr = bmpData.Scan0;
            //int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            //byte[] rgbValues = new byte[bytes];
            //Marshal.Copy(ptr, rgbValues, 0, bytes);
            //for (int counter = 0, i = 0; counter < rgbValues.Length; counter += 4, i++)
            //{
            //    if (
            //        rgbValues[counter] != 0               // blue
            //        || rgbValues[counter + 1] != 0        // green
            //        || rgbValues[counter + 2] != 0        // red
            //        )
            //        ++intRectangle[i];
            //}

                                 //Marshal.Copy(rgbValues, 0, ptr, bytes);
                                 //bmp.UnlockBits(bmpData);


            var arr = BitConverter.ToInt32(ImageToByteArray(bmp));
            var arr2 = ImageToByteArray(bmp);


            this.dataGridView1.RowCount = maxAllY;
            this.dataGridView1.ColumnCount = maxAllX;

            foreach (DataGridViewColumn column in this.dataGridView1.Columns)
                column.Width = 10;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
                row.Height = 10;


            for (int i = 0; i < maxAllY; ++i)
                for (int j = 0; j < maxAllX; ++j)
                {
                    this.dataGridView1.Rows[i].Cells[j].Value = arr22[j, i];
                    this.dataGridView1[j, i].Style.BackColor = colors[arr22[j, i]];
                }



            //this.dataGridView1.DataSource = arr22;


            //for (int i = 0; i <= maxAllX; i++)
            //{
            //    dataGridView1.Columns.Add("column" + i.ToString(), i.ToString());
            //    dataGridView1.Columns[i].Width = 22;
            //}
            //DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            //for (int i = 0; i <= 40; i++)
            //{
            //    row.Cells[i].Value = arr22[0, i];                              // "scores" is an Int32[,] array filled with my data
            //}
            //dataGridView1.Rows.Add(row);
            //dataGridView1.Rows[0].HeaderCell.Value = "Score";
        }


        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            //using (var ms = new MemoryStream())
            //{
            //    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            //    return ms.ToArray();
            //}

            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(imageIn, typeof(byte[]));
        }


    }
}