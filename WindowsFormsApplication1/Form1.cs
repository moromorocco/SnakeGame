using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public static int SIZE = 16;
        private Timer timer;
        private Player player;
        private BodyList bodyList;
        private State state;
        private Esa esa;

        private enum State
        { 
            START,
            PLAYING,
            END,
        }

        //コンストラクタ
        public Form1()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Tick += new EventHandler(MyClock);
            timer.Interval = 200;
            timer.Start();

            player = new Player();
            bodyList = new BodyList();

            init();
        }

        //内部メソッド
        private void init() 
        {
            ScoreTxt.Text = "0";
            messageLabel.Text = "";

            player.init();
            bodyList.init();
            esa = new Esa();

            ChangeState(State.START);
        }
        
        private void update() {
            switch (state)
            {
                case State.START:
                    break;
                case State.PLAYING:
                    player.update();
                    bodyList.update();
                    bodyList.setHead(player.playerX, player.playerY);

                    if (esa.CheckHit(player.playerX, player.playerY)) 
                    {
                        bodyList.addBody();

                        int newScore = int.Parse(ScoreTxt.Text) + bodyList.GetSize() * 10;
                        ScoreTxt.Text = newScore + "";

                        if (int.Parse(HiScoreTxt.Text) < newScore)
                        {
                            HiScoreTxt.Text = newScore + "";
                        }
                    }

                    if (bodyList.checkHit(player.playerX, player.playerY) == true) {
                        ChangeState(State.END);
                    }

                    if (player.playerX < 0 || player.playerX > (20 -1) * SIZE
                            || player.playerY < 0 || player.playerY > (20 - 1) * SIZE)
                    {
                        ChangeState(State.END);
                    }

                    break;
                case State.END:
                    break;
            }
        }

        private void draw()
        {

            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(canvas);

            esa.draw(g);
            bodyList.draw(g);
            player.draw(g);

            g.Dispose();
            pictureBox1.Image = canvas;
        }

        private void ChangeState(State newState) {
            state = newState;

            switch (state) {
                case State.START:
                    messageLabel.Text = "Press Any Key";
                    break;
                case State.PLAYING:
                    messageLabel.Text = "";
                    break;
                case State.END:
                    messageLabel.Text = "GameOver";
                    break;
            }
        }

        //イベント
        private void MyClock(object sender, EventArgs e)
        {
            update();
            draw();
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

            switch (state)
            {
                case State.START:
                    ChangeState(State.PLAYING);
                    break;
                case State.PLAYING:
                    player.keyDown(e.KeyCode);
                    break;
                case State.END:
                    init();
                    ChangeState(State.START);
                    break;
            }
        }
    }
}
