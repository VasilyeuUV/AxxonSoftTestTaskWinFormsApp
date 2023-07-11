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

            var maxTriangle = triangles.FirstOrDefault(t => t.S == triangles.Max(t => t.S));


            var minX = maxTriangle?.Coordinates.Min(p => p.X);
            var maxX = maxTriangle?.Coordinates.Max(p => p.X);
            var minY = maxTriangle?.Coordinates.Min(p => p.Y);
            var maxY = maxTriangle?.Coordinates.Max(p => p.Y);


            var colors = new Color[]
            {
                Color.Blue, Color.Red, Color.AntiqueWhite, Color.Azure, Color.CadetBlue, Color.DarkSalmon, Color.Yellow, Color.Orange
            };



            var minAllX = (int)triangles?.Min(p => p.Coordinates.Min(c => c.X));
            var maxAllX = (int)triangles?.Max(p => p.Coordinates.Max(c => c.X));
            var minAllY = (int)triangles?.Min(p => p.Coordinates.Min(c => c.Y));
            var maxAllY = (int)triangles?.Max(p => p.Coordinates.Max(c => c.Y));

            bmp = new Bitmap(maxAllX, maxAllY);


            //int[] arr = { 0, 200, 100, 100, 200, 50 };
            //var triangle = new TriangleModel(arr);

            /// Здесь рисуем на битмап. А затем этот битмап назначаем свойству Image.
            /// Поскольку объекты Graphics нужно сразу уничтожать после использования,
            /// то всегда пользуемся конструкцией using. Она сама уничтожит объект при
            /// выходе.
            using (Graphics g = Graphics.FromImage(bmp))
            {
                /// Рисование на белом фоне. Делаем заливку белым цветом
                g.Clear(Color.Transparent);
                //g.DrawLine(Pens.Black, 10, 10, 40, 40);

                var i = -1;
                foreach (var triangle in triangles)
                {
                    var color = colors[++i];
                    //g.FillPolygon(new SolidBrush(color), triangle.Coordinates);
                    g.FillPolygon(new SolidBrush(color), maxTriangle.Coordinates);
                }


            }
            /// Назначаем наш Bitmap свойству Image
            this.pbMain.Image = bmp;


            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color pixel = bmp.GetPixel(i, j);
                }
            }


            var intRectangle = new int[maxAllX * maxAllY];


            var pixelFormat = bmp.PixelFormat.ToString();
            Rectangle rect = new Rectangle(minAllX, minAllY, maxAllX, maxAllY);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);
            for (int counter = 0, i = 0; counter < rgbValues.Length; counter += 4, i++)
            {
                if (
                    rgbValues[counter] != 0               // blue
                    || rgbValues[counter + 1] != 0        // green
                    || rgbValues[counter + 2] != 0        // red
                    )
                    ++intRectangle[i];
            }

            Marshal.Copy(rgbValues, 0, ptr, bytes);
            bmp.UnlockBits(bmpData);





            var arr =  BitConverter.ToInt32( ImageToByteArray(bmp));
            var arr2 =  ImageToByteArray(bmp);
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