using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MrkView
{
    abstract class GameObject
    {
        public abstract void Update();
        public abstract void Render(Graphics graphics, Camera camera);
    }
}
