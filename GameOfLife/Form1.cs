using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        private const int rows = 400;
        private const int columns = 800;
        int generation = 1;

        private readonly Life life = new(rows, columns);
        
        private CancellationTokenSource cancelSource = new();

        private Bitmap frontBuffer = new Bitmap(columns, rows);
        private Bitmap backBuffer = new Bitmap(columns, rows);

        public Form1()
        {
            InitializeComponent();
        }
            
        private async void cmdReinitialize_Click(object sender, EventArgs e)
        {
            cancelSource.Cancel();

            cancelSource = new CancellationTokenSource();

            var token = cancelSource.Token;

            // initializes the field to simulate with
            life.initField();

            await Task.Run(async () =>
            {
                UpdateDisplay();

                await Task.Delay(1);

                while (!token.IsCancellationRequested)
                {
                    life.Update();
                    UpdateDisplay();
                    await Task.Delay(1);
                }
            }, token);
        }

        private void UpdateDisplay()
        {
            var blackBrush = new SolidBrush(Color.Black);
            var whiteBrush = new SolidBrush(Color.White);
            var blueBrush = new SolidBrush(Color.Blue);
            var redBrush = new SolidBrush(Color.Red);

            var g = Graphics.FromImage(backBuffer);

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    var isAlive = life.cellState(row, column);
                    var brush = whiteBrush;

                    /*
                       * 0: dead
                       * 1: alive
                       * 2: dying
                       * 3: reviving
                       */

                    // Add multiple color stages for all states
                    switch (isAlive)
                    {
                        case 0:
                            brush = whiteBrush;
                            break;
                        case 1:
                            brush = blackBrush;
                            break;
                        case 2:
                            brush = blueBrush;
                            break;
                        case 3:
                            brush = redBrush;
                            break;
                    }
                    g.FillRectangle(brush, column, row, 10, 10);
                }
            }

            picLife.Image = backBuffer;

            var temp = frontBuffer;
            frontBuffer = backBuffer;
            backBuffer = temp;
            picLife.Image = backBuffer;

            g.Dispose();
            generation++;
        }

        private void picLife_Click(object sender, EventArgs e)
        {

        }

        //Zoom image file
        //Image Zoom(Image img, Size size)
        //{
        //    Bitmap bmp = new Bitmap(img, img.Width + (img.Width * size.Width / 100), img.Height + (img.Height * size.Height / 100));
        //    Graphics g = Graphics.FromImage(bmp);
        //    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //    return bmp;
        //}

        //private void track1_Scroll(object sender, EventArgs e)
        //{
        //    if (trackBar1.Value > 0)
        //    {
        //        picLife.Image = Zoom(imgOriginal, new Size(trackBar1.Value, trackBar1.Value));
        //    }
        //}
    }
}
