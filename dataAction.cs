using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectSia_final
{
    internal class dataAction
    {
        public static DialogResult Show()
        {
            using (rowAction act = new rowAction())
            {
                return act.ShowDialog();
            }
        }
    }
}
