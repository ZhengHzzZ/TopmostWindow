using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TopMost
{
    public class WindowsMethod
    {
        private const int WS_VISIBLE = 268435456;//窗体可见
        private const int WS_MINIMIZEBOX = 131072;//有最小化按钮
        private const int WS_MAXIMIZEBOX = 65536;//有最大化按钮
        private const int WS_BORDER = 8388608;//窗体有边框
        private const int GWL_STYLE = (-16);//窗体样式
        private const int GW_HWNDFIRST = 0;
        private const int GW_HWNDNEXT = 2;
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;
        private const int HWND_TOPMOST = -1;
        private const int HWND_NOTOPMOST = -2;
        private const uint SWP_NOSIZE = 0x0001;

        [DllImport("User32.dll")]
        private extern static int GetWindow(int hWnd, int wCmd);
        [DllImport("User32.dll")]
        private extern static int GetWindowLongA(int hWnd, int wIndx);
        [DllImport("user32.dll")]
        private static extern bool GetWindowText(int hWnd, StringBuilder title, int maxBufSize);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private extern static int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int ShowWindow(int hwnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern int SetWindowPos(int hwnd, int hwndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
        //获得包含窗体可见、有边框、有最大化按钮的窗体的句柄和标题(窗体的属性出这几种外还有很多种)
        public static List<FormInfo> GetHandleList(int Handle)
        {
            List<FormInfo> fromInfo = new List<FormInfo>();
            int handle = GetWindow(Handle, GW_HWNDFIRST);
            while (handle > 0)
            {
                int IsTask = WS_VISIBLE | WS_BORDER | WS_MAXIMIZEBOX;//窗体可见、有边框、有最大化按钮
                int lngStyle = GetWindowLongA(handle, GWL_STYLE);
                bool TaskWindow = ((lngStyle & IsTask) == IsTask);
                if (TaskWindow)
                {
                    int length = GetWindowTextLength(new IntPtr(handle));
                    StringBuilder stringBuilder = new StringBuilder(2 * length + 1);
                    GetWindowText(handle, stringBuilder, stringBuilder.Capacity);
                    string strTitle = stringBuilder.ToString();
                    if (!string.IsNullOrEmpty(strTitle))
                    {
                        fromInfo.Add(new FormInfo(strTitle, handle));
                    }
                    else
                    {
                        fromInfo.Add(new FormInfo("", handle));
                    }
                }
                handle = GetWindow(handle, GW_HWNDNEXT);
            }
            return fromInfo;
        }

        //获得所有窗体的句柄和标题
        public static List<FormInfo> GetAllHandleList(int Handle)
        {
            List<FormInfo> fromInfo = new List<FormInfo>();
            int handle = GetWindow(Handle, GW_HWNDFIRST);
            while (handle > 0)
            {
                int length = GetWindowTextLength(new IntPtr(handle));
                StringBuilder stringBuilder = new StringBuilder(2 * length + 1);
                GetWindowText(handle, stringBuilder, stringBuilder.Capacity);
                string strTitle = stringBuilder.ToString();
                if (!string.IsNullOrEmpty(strTitle))
                {
                    fromInfo.Add(new FormInfo(strTitle, handle));
                }
                else
                {
                    fromInfo.Add(new FormInfo("", handle));
                }
                handle = GetWindow(handle, GW_HWNDNEXT);
            }
            return fromInfo;
        }

        //将选中窗体设置为TopMost
        public static void SetTopMost(int targetHandle, bool isTopMost)
        {
            int topmost = isTopMost ? HWND_TOPMOST : HWND_NOTOPMOST;
            SetWindowPos(targetHandle, topmost, 0, 0, 0, 0, SWP_NOSIZE);
        }
    }
}
