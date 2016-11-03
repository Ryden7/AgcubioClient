using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgCubio;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace CubioGUI
{
    public partial class Form1 : Form
    {
        private Socket socket;
        private World world;
        private long uid;
        private bool lose;
        private bool flag = false;

        private Stopwatch timer;
        Graphics g;

        public Form1()
        {
            world = new World();
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            timer = new Stopwatch();
            

            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void hide()
        {
            label1.Hide();
            label2.Hide();
            label3.Hide();

            textBox1.Hide();
            textBox2.Hide();

            button1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            string name = textBox1.Text;
            string ip = textBox2.Text;

            if (name == "" | ip == "")
            {
                MessageBox.Show("Name or IP can not be empty!");
                return;
            }

            hide();
            timer.Start();
            socket = Network.Connect_to_Server(firstSend, ip);


        }

        public void firstSend(PreservedState state)
        {
            /*
            Network.Send(state.socket, textBox1.Text + " \n");
            Console.WriteLine("sending back info from server");


            Network.i_want_more_data(state);
            socket = state.socket;

            string[] list = (string[])state.stringProcess();
            Console.WriteLine(list.Length+" cubes");

            foreach (string temp in list)
            {  
                if (temp == "")
                    continue;
                else
                {
                    if (temp.StartsWith("{") && temp.EndsWith("}"))
                    {
                        Cube cube = JsonConvert.DeserializeObject<Cube>(temp);

                        //Console.WriteLine(cube.Name);
                        world.addCube(cube);
                    }
                }
            }
            Console.WriteLine("sending done");

            paint();

            Network.Send(socket, "(move, " + x + ", " + y + ")\n");
            //Console.WriteLine("mouse moving");

            panel1.Invalidate();
            */

            //////////////////////////////////////////////////////////////////////////////////////////////

            /*
            base.Invoke(new MethodInvoker(delegate
            {
                this.hide_initial_gui();
            }));
            */
            state.callback = new Action<PreservedState>(firstReceive);
            Network.Send(socket, textBox1.Text + " \n");
            flag = true;
        }

        public void firstReceive(PreservedState state)
        {
            try
            {
                StringBuilder sb = state.sb;
                string[] array = sb.ToString().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string text = array[0];
                sb.Remove(0, text.Length);
                Cube cube = JsonConvert.DeserializeObject<Cube>(text);

                lock (this.world)
                {
                    world.addCube(cube);
                }

                this.uid = cube.uid;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            state.callback = new Action<PreservedState>(receiveData);
            receiveData(state);
        }

        private void receiveData(PreservedState state)
        {
            lock (this.world)
            {
                StringBuilder sb = state.sb;
                string[] array = sb.ToString().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                int count = 0;
                try
                {
                    foreach (string temp in array)
                    {
                        if (temp.StartsWith("{") && temp.EndsWith("}"))
                        {
                            Cube cube = JsonConvert.DeserializeObject<Cube>(temp);

                            if (cube == null)
                                continue;

                            world.addCube(cube);
                            count++;

                            if (cube.uid == this.uid && cube.Mass == 0)
                                lose = true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                sb.Clear();

                if (count > 0)
                {
                    // try delete base?????
                    base.Invalidate();
                }

                if (count != array.Length)
                    sb.Append(array[array.Length - 1]);

            }

            if (this.lose)
            {
                // A label shows lose;
                return;
            }


            Network.i_want_more_data(state);
        }

        private void mousePosition()
        {
            if (!lose && flag)
            {
                // delete base
                int x = PointToClient(Control.MousePosition).X;
                int y = PointToClient(Control.MousePosition).Y;
                Network.Send(socket, "(move, " + x + ", " + y + ")\n");
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                
                mousePosition();
                int count = 0;
                base.Update();
                TimeSpan elapsed = this.timer.Elapsed;

                if (elapsed.Seconds > 0)
                {
                    int num = count / elapsed.Seconds;
                    FPS.Text = "FPS " + num;
                    FPS.Invalidate();
                    FPS.Update();
                    FPS.Refresh();
                }

                if (elapsed.Seconds > 50)
                {
                    this.timer.Restart();
                    count = 0;
                }

                if (!this.lose)
                {
                    lock (this.world)
                    {
                        // draw the foods
                        foreach (Cube temp in this.world.foods.Values)
                        {
                            int num2 = Math.Max((int)temp.getWidth(), 5);
                            SolidBrush brush = new SolidBrush(Color.FromArgb(temp.argb_color));
                            e.Graphics.FillRectangle(brush, (float)temp.loc_x, (float)temp.loc_y, (float)num2, (float)num2);
                        }

                        foreach (Cube player in this.world.players.Values)
                        {
                            int num3 = (int)(player.getWidth() / 2);

                            

                            SolidBrush brush = new SolidBrush(Color.FromArgb(player.argb_color));

                         //   e.Graphics.FillRectangle(brush, (float)player.loc_x - (float)num3, (float)player.loc_y - (float)num3, (float)player.getWidth(), (float)player.getWidth());
                            
                            e.Graphics.FillRectangle(brush, (float)player.loc_x - (float)num3, (float)player.loc_y - (float)num3, (float)player.getWidth(), (float)player.getWidth());

                            brush = new SolidBrush(Color.Yellow);

                            StringFormat drawFormat = new StringFormat();
                            drawFormat.Alignment = StringAlignment.Center;
                            e.Graphics.DrawString(player.Name, DefaultFont, brush, (float)player.loc_x, (float)player.loc_y, drawFormat);
                            Console.WriteLine(player.Name);


                            // SizeF size = new SizeF((float)5, (float) 2);
                            // this.Region = 0;
                            // this.Scale(size);
                            // this.ScaleControl(size, 0);

                            // this.SetClientSizeCore((int)player.loc_x - 300 - (int)player.loc_x + 200, (int)player.loc_y + 200);

                            // this.SizeFromClientSize(ClientSize = new Size(200, 199));
                     //       this.AutoScaleDimensions = new System.Drawing.SizeF((float)player.loc_x, (float)player.loc_y);




                        }

                        Food.Text = "Food " + this.world.foods.Count;
                        Food.Invalidate();
                        Food.Update();

                        Mass.Text = "Mass " + this.world.players[this.uid].Mass;
                        Mass.Invalidate();
                        Mass.Update();

                        Width.Text = "Width " + this.world.players[this.uid].getWidth();

                    }
                }
                base.Invalidate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                int x = PointToClient(Control.MousePosition).X;
                int y = PointToClient(Control.MousePosition).Y;
                Network.Send(socket, "(split, " + x + ", " + y + ")\n");
            }
        }
    }
}