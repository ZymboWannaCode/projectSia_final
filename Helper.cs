using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectSia_final
{
    internal class Helper
    {
        public static void showForm(Form parentForm, Form popupForm)
        {
            popupForm.Owner = parentForm;
            popupForm.StartPosition = FormStartPosition.Manual;
            Rectangle workingArea = Screen.GetWorkingArea(parentForm);

            int newX = workingArea.Right - popupForm.Width;
            int newY = parentForm.Top;

            popupForm.Location = new Point(newX, newY);
            popupForm.Height = 1080;

            popupForm.ShowDialog();
        }

        public static T GetElementByIndex<T>(LinkedList<T> linkedList, int index)
        {
            if (index < 0 || index >= linkedList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            LinkedListNode<T> currentNode = linkedList.First;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Value;
        }

        public static string generatePassword()
        {
            string CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int PASSWORD_LENGTH = 10;
            var random = new Random();
            var password = new StringBuilder(PASSWORD_LENGTH);

            for (int i = 0; i < PASSWORD_LENGTH; i++)
            {
                int index = random.Next(CHARACTERS.Length);
                password.Append(CHARACTERS[index]);
            }

            return password.ToString();
        }

    }
}
