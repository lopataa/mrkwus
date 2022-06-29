using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Numerics;

namespace MrkView
{
    static class Input
    {
        private static readonly Dictionary<Keys, bool> _keys = new Dictionary<Keys, bool>(
            Enum.GetValues<Keys>().Distinct().
            Select((v) => new KeyValuePair<Keys, bool>(v, false)));
        private static Vector2 _mousePos;

        public static void Pressed(Keys key) => _keys[key] = true;

        public static void Release(Keys key) => _keys[key] = false;

        public static void MouseMoved(Vector2 pos) => _mousePos = pos;

        public static bool GetKey(Keys key)
        {
            if (_keys.ContainsKey(key))
                return _keys[key];
            return false;
        }

        public static Vector2 GetMousePos() => _mousePos;

        public static void Reset()
        {
            foreach (var item in _keys.Keys)
                _keys[item] = false;
        }
    }

    public class Camera
    {
        public Vector2 ViewportSize;
        public Vector2 Position;
        public float Zoom = 1;

        public Vector2 ProjectCoords(Vector2 pos)
        {
            Matrix3x2 matrix = Matrix3x2.CreateTranslation(-Position) * Matrix3x2.CreateScale(Zoom) * Matrix3x2.CreateTranslation(ViewportSize / 2);
            return Vector2.Transform(pos, matrix);
        }

        public Vector2 ScreenToWorld(Vector2 pos)
        {
            Matrix3x2 matrix = Matrix3x2.CreateTranslation(-Position) * Matrix3x2.CreateScale(Zoom) * Matrix3x2.CreateTranslation(ViewportSize / 2);
            Matrix3x2.Invert(matrix, out matrix);
            return Vector2.Transform(pos, matrix);
        }

        public void Resize(float width, float height)
        {
            ViewportSize = new Vector2(width, height);
        }
    }
}
