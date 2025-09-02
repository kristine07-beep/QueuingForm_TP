using System;
using System.Windows.Forms;

namespace QueuingForm
{
    public partial class QueuingForm : Form
    {
        public QueuingForm()
        {
            InitializeComponent();

   
            var cashierWin = new CashierWindowQueueForm();
            cashierWin.Show();
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            string ticket = CashierClass.GenerateNextTicket();
            lblQueue.Text = ticket;
        }
    }
}
