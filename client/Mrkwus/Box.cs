using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MrkView
{
    class Box : GameObject
    {
        public Vector2 Position;

        public override void Render(Graphics graphics, Camera camera)
        {
            using (Pen smoothass = new Pen(Brushes.Black, 4 * camera.Zoom))
            {
                var pos = camera.ProjectCoords(Position);
                var radius = 16 * camera.Zoom;
                graphics.DrawRectangle(smoothass, pos.X - radius, pos.Y - radius, radius * 2, radius * 2);
            }
        }

        public override void Update()
        {
            
        }
    }
}
