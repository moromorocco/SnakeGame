using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Body : IGame
    {
        private int size = Form1.SIZE;

        //プロパティ
        public int bodyX { get; set; }
        public int bodyY { get; set; }

        public Body() {
            bodyX = -1 * size;
            bodyY = -1 * size;
        }

        //継承メソッド
        public void update()
        {
        }

        public void draw(System.Drawing.Graphics g)
        {
            g.FillRectangle(Brushes.Gray, bodyX, bodyY, size, size);
        }
    }
}
