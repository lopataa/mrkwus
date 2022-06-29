using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MrkView
{
    public partial class MainForm : Form
    {
        public static Camera camera = new Camera();
        Scene scene = new Scene();
        Communication commu = new Communication();
        Player player = new Player();
        Dictionary<string, Player> otherPlayers = new Dictionary<string, Player>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            commu.OnConnected += Commu_OnConnected;
            commu.OnDisconnected += Commu_OnDisconnected;
            commu.LoginPlayerData += (c, id, x, y, r) =>
            {
                player.Id = id;
                player.Position = new Vector2(x, y);
                player.Rotation = r;
            };
            commu.ServerError += (c, message) =>
            {
                this.Invoke(new Action(() => MessageBox.Show($"Server error: \n{message}", "Server says", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
            };
            commu.PlayerEnter += (c, id, name, x, y, r) =>
            {
                var p = new Player() { Dummy = true, Id = id, Name = name,
                    Position = new Vector2(x, y),
                    Rotation = r };
                otherPlayers.Add(id, p);
                scene.Add(p);
            };
            commu.PlayerLeave += (c, id) =>
            {
                scene.Remove(otherPlayers[id]);
                otherPlayers.Remove(id);
            };
            commu.PlayerMove += (c, id, x, y, r) =>
            {
                otherPlayers[id].Position = new Vector2(x, y);
                otherPlayers[id].Rotation = r;
            };

            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(RenderView, true, null);
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(ConnectPanel, true, null);

            RenderView_Resize(null, EventArgs.Empty);

            Time.Start(DateTime.Now);
            Timer.Interval = 12;
            Timer.Start();

            EnterMenu();
        }

        // render
        private void RenderView_Paint(object sender, PaintEventArgs e)
        {
            scene.Render(e.Graphics, camera);
        }

        // update
        private void Timer_Tick(object sender, EventArgs e)
        {
            Time.Update(DateTime.Now);

            var screenspaceviewportbounds = RectangleToScreen(RenderView.Bounds);
            Input.MouseMoved(new Vector2(MousePosition.X, MousePosition.Y) - (
                new Vector2(screenspaceviewportbounds.X, screenspaceviewportbounds.Y)));

            scene.Update();

            if (Input.GetKey(Keys.Escape))
                commu.Disconnect();

            if (commu.Connected)
                player.SendData(commu);

            RenderView.Invalidate();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            Input.Pressed(e.KeyCode);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            Input.Release(e.KeyCode);
        }

        private void RenderView_Resize(object sender, EventArgs e)
        {
            camera.Resize(this.ClientSize.Width, this.ClientSize.Height);
        }

        private void MainForm_Leave(object sender, EventArgs e)
        {
            Input.Reset();
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            player.Name = UsernameTextBox.Text;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                MessageBox.Show("Choose a valid username.", "Invalid username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                commu.Connect(UrlTextBox.Text, UsernameTextBox.Text);
            }
            catch (UriFormatException)
            {
                MessageBox.Show("The entered URL has wrong format.", "Incorrect URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnterMenu()
        {
            scene.Clear();
            scene.Add(player);

            player.Position = Vector2.Zero;

            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                scene.Add(new Box() { Position = ((new Vector2((float)random.NextDouble(), (float)random.NextDouble()) * 2) - Vector2.One) * 300 });
            }
        }

        private void EnterGame()
        {
            RenderView.Focus();

            scene.Clear();
            scene.Add(player);

            otherPlayers.Clear();
        }

        private void Commu_OnConnected(Communication obj)
        {
            ConnectPanel.Invoke(new Action(ConnectPanel.Hide));

            this.Invoke(new Action(this.EnterGame));
        }

        private void Commu_OnDisconnected(Communication obj)
        {
            ConnectPanel.Invoke(new Action(ConnectPanel.Show));

            this.Invoke(new Action(this.EnterMenu));
        }

        private void CreditsButton_Click(object sender, EventArgs e)
        {
            var x = new CreditsForm();
            x.ShowDialog();
            x.Dispose();
        }

        private void RenderView_Click(object sender, EventArgs e)
        {
            RenderView.Focus();
        }
    }

    /*
    Login
        c -> s username
    Game Enter
        s -> c players (uid, username, (loc))
        s -> c pos rot
    


    */
}
