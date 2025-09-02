using System;
using System.Windows.Forms;

namespace QueuingForm
{
    public partial class CustomerView : Form
    {
        public CustomerView()
        {
            InitializeComponent();
            lblTitle.Text = "*Now Serving ";  // default text
        }

      
        public void SetNowServing(string ticket)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetNowServing), ticket);
                return;
            }

            // Replace the label text to show both "Now Serving" and ticket number
            lblTitle.Text = string.IsNullOrWhiteSpace(ticket) ? "*Now Serving " : $"*Now Serving  \n{ticket}";
        }
    }
}
