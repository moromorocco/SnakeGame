using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class BodyList : IGame
    {
        private List<Body> bodyList = new List<Body>();
        
        //コンストラクタ
        public BodyList() {
            init();
        }

        //継承メソッド
        public void update()
        {
            for(int i = 0; i < bodyList.Count() - 1; i++) {
                bodyList.ElementAt(i).bodyX = bodyList.ElementAt(i + 1).bodyX;
                bodyList.ElementAt(i).bodyY = bodyList.ElementAt(i + 1).bodyY;
            }
        }

        public void draw(System.Drawing.Graphics g)
        {
            IEnumerator body = bodyList.GetEnumerator();
            while(body.MoveNext()) 
            {
                IGame game = (IGame)body.Current;
                game.draw(g);
            }
        }

        //公開メソッド
        //初期化
        public void init()
        {
            bodyList.Clear();
            addBody();
            addBody();
        }

        public void setHead(int x, int y) 
        {
            int size = bodyList.Count() - 1;

            bodyList.ElementAt(size).bodyX = x;
            bodyList.ElementAt(size).bodyY = y;
        }

        public void addBody()
        {
            bodyList.Add(new Body());
        }

        public Boolean checkHit(int x, int y) {
            int size = bodyList.Count() - 2;

            for (int i = 0; i < size; i++) 
            {
                if (x == bodyList.ElementAt(i).bodyX && y == bodyList.ElementAt(i).bodyY) 
                {
                    return true;
                }
            }

            return false;
        }

        public int GetSize() 
        {
            return bodyList.Count();
        }
    }
}
