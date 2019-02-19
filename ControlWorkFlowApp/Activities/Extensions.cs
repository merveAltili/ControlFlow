﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlWorkFlowApp
{
    public static class Extensions
    {
        public static string Humanize(this string str)
        {
            return Regex.Replace(str.Split('.').Last(), "([a-z](?=[A-Z0-9])|[A-Z](?=[A-Z][a-z]))", "$1 ");
        }

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        public static void SetWindowTheme(this Control control, string pszSubAppName)
        {
            SetWindowTheme(control.Handle, pszSubAppName, null);
        }

    }
}
