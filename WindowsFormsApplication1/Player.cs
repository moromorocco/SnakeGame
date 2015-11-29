using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Player : IGame
    {

        //変数
        private int size = Form1.SIZE;
        private Dir dir = Dir.RIGHT;
        //列挙型
        private enum Dir 
        { 
            UP,
            DOWN,
            LEFT,
            RIGHT,
        }

        //プロパティ
        public int playerX { get; set; }
        public int playerY { get; set; }

        //コンストラクタ
        public Player() 
        {
            init();
        }

        public void init() {
            playerX = 10 * size;
            playerY = 10 * size;
        }

        //継承メソッド
        public void update()
        {
            move();   
        }

        public void draw(System.Drawing.Graphics g)
        {
            g.FillRectangle(Brushes.Red, playerX, playerY, size, size);
        }

        //公開メソッド
        public void keyDown(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.Up:
                    dir = Dir.UP;
                    break;
                case Keys.Down:
                    dir = Dir.DOWN;
                    break;
                case Keys.Right:
                    dir = Dir.RIGHT;
                    break;
                case Keys.Left:
                    dir = Dir.LEFT;
                    break;
            }
        }

        //内部メソッド
        private void move() {
            switch (dir) { 
                case Dir.DOWN:
                    playerY += size;
                    break;
                case Dir.UP:
                    playerY -= size;
                    break;
                case Dir.RIGHT:
                    playerX += size;
                    break;
                case Dir.LEFT:
                    playerX -= size;
                    break;
            }
        }
    }
}
