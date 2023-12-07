using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using TeliKep.subforms;

namespace TeliKep
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        private List<Point> snowflakes = new List<Point>();
        bool snowing = true;
        
        
       

        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            StartSnowfall();
           
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var snowflake in snowflakes)
            {
                e.Graphics.DrawString("*", new Font("Arial", 22), Brushes.White, snowflake);
            }
        }

        async void StartSnowfall()
        {
            while (snowing)
            {
                snowflakes.Add(new Point(rnd.Next(0, this.Width), 0));


                for (int i = 0; i < snowflakes.Count; i++)
                {
                    var snowflake = snowflakes[i];
                    snowflakes[i] = new Point(snowflake.X, snowflake.Y + 1);

                    if (snowflakes[i].Y > this.Height)
                    {
                        snowflakes.RemoveAt(i);
                        i--;
                    }
                }

                this.Invalidate();
                await Task.Delay(100);
            }
        }

        private void houseBtn_Click(object sender, EventArgs e)
        {
            snowing = false;
            Inside inside = new Inside(this.Size);
            inside.ShowDialog();
            inside.player.Stop();
            snowing = true;
            StartSnowfall();
        }

       
    }
}
