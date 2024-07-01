using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectSia_final
{
    internal class messageBox_cus
    {
        public static DialogResult Show(string title, string message, MessageBoxIcon icon)
        {
            using (custom_msgbpx mssg = new custom_msgbpx(title, message, icon))
            {
                return mssg.ShowDialog();
            }
        }
    }
}
