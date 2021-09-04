using System.Windows.Forms;

namespace SignalR_WinForm.Extension
{
    internal static class ControlExtension
    {
        public static void InvokeIfNecessary(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}