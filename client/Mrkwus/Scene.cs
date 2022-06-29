using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MrkView
{
    class Scene
    {
        List<GameObject> _objects = new List<GameObject>();

        public void Update()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                _objects[i].Update();
            }
        }

        public void Render(Graphics g, Camera c)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            for (int i = 0; i < _objects.Count; i++)
            {
                _objects[i].Render(g, c);
            }
        }

        public void Add(GameObject obj)
        {
            _objects.Add(obj);
            _objects.Sort((a, b) => String.Compare(a.GetType().Name, b.GetType().Name));
        }

        public void Remove(GameObject obj)
        {
            _objects.Remove(obj);
        }

        public void Clear()
        {
            _objects.Clear();
        }
    }
}
