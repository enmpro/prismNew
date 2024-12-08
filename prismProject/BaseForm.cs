using System;
using System.Windows.Forms;

public class BaseForm : Form
{
    private bool formClosed = false;
    public static int count = 0;
    public BaseForm()
    {
        this.FormClosing += new FormClosingEventHandler(BaseForm_FormClosing);
    }

    private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Console.WriteLine(count.ToString());
        if (formClosed)
        {
            return;
        }

        if (count < 1)
        {
            DialogResult result = MessageBox.Show(
            "Are you sure you want to close the application?",
            "Confirm Exit",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {

                formClosed = true;
                Console.WriteLine("yes");
                count++;
                Application.Exit();
                
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
