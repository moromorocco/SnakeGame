using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Esa : IGame
    {
        private int size = Form1.SIZE;
        private int area = 20;
        private Random rnd;

        //プロパティ
        public int x { get; set; }
        public int y { get; set; }

        //コンストラクタ
        public Esa() 
        {
            int seed = Environment.TickCount;
            rnd = new Random(seed);

            SetPoint();
        }

        //継承メソッド
        public void update()
        {
        }

        public void draw(System.Drawing.Graphics g)
        {
            g.FillRectangle(Brushes.Green, x, y, size, size);
        }

        //ヒット
        public Boolean CheckHit(int playerX, int playerY) {
            if (playerX == x && playerY == y)
            {
                SetPoint();
                return true;
            }

            return false;
        }

        //ランダムな一に配置
        private void SetPoint() {
            x = rnd.Next(area) * size;
            y = rnd.Next(area) * size;
        }
    }
}
