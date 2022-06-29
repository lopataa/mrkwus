using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MrkView
{
    public partial class CreditsForm : Form
    {
        public CreditsForm()
        {
            InitializeComponent();
            DarkTitleBarClass.UseImmersiveDarkMode(this.Handle, true);
        }

        private void ColorTimer_Tick(object sender, EventArgs e)
        {
            var mycolor = HSVToRGB(new Vector3(Time.ElapsedTime, 0.25f, 1));
            LopataaText.ForeColor = Color.FromArgb((int)(mycolor.X * 255), (int)(mycolor.Y * 255), (int)(mycolor.Z * 255));
            mycolor = HSVToRGB(new Vector3(115f / 360f, ((MathF.Sin(Time.ElapsedTime) + 1) / 2) * 0.86f, 0.84f));
            ZexypLabel.ForeColor = Color.FromArgb((int)(mycolor.X * 255), (int)(mycolor.Y * 255), (int)(mycolor.Z * 255));
        }

        static Vector3 HSVToRGB(Vector3 hsvColor)
        {
            // a hue abs value might be needed
            hsvColor.X = (hsvColor.X % 1.0f);
            if (hsvColor.X < 0)
                hsvColor.X += 1;
            hsvColor.X *= 6;
            Vector3 rgbColor = new Vector3();
            if (hsvColor.Z <= 0)
            {
                rgbColor.X = rgbColor.Y = rgbColor.Z = 0;
            }
            else if (hsvColor.Y <= 0)
            {
                rgbColor.X = rgbColor.Y = rgbColor.Z = hsvColor.Z;
            }
            else
            {
                float hf = hsvColor.X;
                int i = (int)Math.Floor(hf);
                float f = hf - i;
                float pv = hsvColor.Z * (1 - hsvColor.Y);
                float qv = hsvColor.Z * (1 - hsvColor.Y * f);
                float tv = hsvColor.Z * (1 - hsvColor.Y * (1 - f));
                switch (i)
                {
                    case 0:
                        rgbColor.X = hsvColor.Z;
                        rgbColor.Y = tv;
                        rgbColor.Z = pv;
                        break;
                    case 1:
                        rgbColor.X = qv;
                        rgbColor.Y = hsvColor.Z;
                        rgbColor.Z = pv;
                        break;
                    case 2:
                        rgbColor.X = pv;
                        rgbColor.Y = hsvColor.Z;
                        rgbColor.Z = tv;
                        break;
                    case 3:
                        rgbColor.X = pv;
                        rgbColor.Y = qv;
                        rgbColor.Z = hsvColor.Z;
                        break;
                    case 4:
                        rgbColor.X = tv;
                        rgbColor.Y = pv;
                        rgbColor.Z = hsvColor.Z;
                        break;
                    case 5:
                        rgbColor.X = hsvColor.Z;
                        rgbColor.Y = pv;
                        rgbColor.Z = qv;
                        break;
                    case 6:
                        rgbColor.X = hsvColor.Z;
                        rgbColor.Y = tv;
                        rgbColor.Z = pv;
                        break;
                    case -1:
                        rgbColor.X = hsvColor.Z;
                        rgbColor.Y = pv;
                        rgbColor.Z = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        Console.WriteLine("color conversion messed up!");
                        rgbColor.X = rgbColor.Y = rgbColor.Z = hsvColor.Z;
                        break;
                }
            }
            return rgbColor;
        }

        private void LopataaText_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = "http://github.com/lopataaa",
                UseShellExecute = true
            });
        }

        private void ZexypLabel_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = "http://github.com/Zexyp",
                UseShellExecute = true
            });
        }

        class DarkTitleBarClass
        {
            [DllImport("dwmapi.dll")]
            private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr,
            ref int attrValue, int attrSize);

            private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
            private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

            internal static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
            {
                if (IsWindows10OrGreater(17763))
                {
                    var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                    if (IsWindows10OrGreater(18985))
                    {
                        attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                    }

                    int useImmersiveDarkMode = enabled ? 1 : 0;
                    return DwmSetWindowAttribute(handle, attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
                }

                return false;
            }

            private static bool IsWindows10OrGreater(int build = -1)
            {
                return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
            }
        }
    }
}
