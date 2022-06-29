using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace MrkView
{
    class Player : GameObject
    {
        public string Id;
        public string Name;

        public Vector2 Position
        {
            get => _position;
            set
            {
                if (_position == value) return;

                _position = value;
                _dataDirty = true;
            }
        }
        public float Rotation
        {
            get => _rotation;
            set
            {
                if (_rotation == value) return;

                // TODO: fix - precision needed - this is now dead zoning
                _dataDirty = Math.Floor(_rotation) != Math.Floor(value);
                _rotation = value;
            }
        }

        private Vector2 _position;
        private float _rotation;
        bool _dataDirty = true;

        public bool Dummy = false;

        public override void Update()
        {
            if (Dummy) return;

            var move = new Vector2();
            if (Input.GetKey(Keys.A) || Input.GetKey(Keys.Left))
                move.X -= 1;
            if (Input.GetKey(Keys.D) || Input.GetKey(Keys.Right))
                move.X += 1;
            if (Input.GetKey(Keys.W) || Input.GetKey(Keys.Up))
                move.Y -= 1;
            if (Input.GetKey(Keys.S) || Input.GetKey(Keys.Down))
                move.Y += 1;

            if (move != Vector2.Zero)
            {
                move = Vector2.Normalize(move);
                this.Position += move * Time.DeltaTime * 200;
            }
            var dirvec = MainForm.camera.ScreenToWorld(Input.GetMousePos()) - this.Position;
            this.Rotation = MathF.Atan2(dirvec.Y, dirvec.X) * 180 / MathF.PI;

            MainForm.camera.Position += (this.Position - MainForm.camera.Position) * Time.DeltaTime * 2;
        }

        public override void Render(Graphics graphics, Camera camera)
        {
            var zoom = camera.Zoom;
            var pos = camera.ProjectCoords(this.Position);
            var visiboi = 60;
            using (Pen smoothass = new Pen(Brushes.Black, 4 * zoom))
            {
                smoothass.StartCap = LineCap.Round;
                smoothass.EndCap = LineCap.Round;
                var radius = 16 * zoom;
                var bigradius = 24 * zoom;
                var angle = this.Rotation;
                graphics.DrawArc(smoothass,
                    new Rectangle((int)(pos.X - bigradius),
                                  (int)(pos.Y - bigradius),
                                  Math.Max((int)(bigradius * 2), 1),
                                  Math.Max((int)(bigradius * 2), 1)),
                    angle - visiboi / 2, visiboi);
                graphics.DrawEllipse(smoothass, new RectangleF(pos.X - radius, pos.Y - radius, radius * 2, radius * 2));
            }

            var fontsize = 12 * camera.Zoom;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            using (Font font = new Font("Consolas", fontsize))
            {
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    graphics.DrawString(Name, font, Brushes.DimGray, new PointF(pos.X, pos.Y), format);
                }
            }
        }

        public void SendData(Communication commu)
        {
            if (_dataDirty)
            {
                _dataDirty = false;
                commu.SendLocation(Position.X, Position.Y, Rotation);
            }
        }
    }
}
