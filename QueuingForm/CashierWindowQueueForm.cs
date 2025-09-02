using System;
using System.Collections;
using System.Windows.Forms;

namespace QueuingForm
{
    public partial class CashierWindowQueueForm : Form
    {
        private readonly CustomerView _customerView = new CustomerView();
        private readonly Timer _timer = new Timer();

        public CashierWindowQueueForm()
        {
            InitializeComponent();

            _customerView.Show();                

            _timer.Interval = 1000;               
            _timer.Tick += Timer_Tick;
            _timer.Start();

            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        public void DisplayCashierQueue(IEnumerable cashierList)
        {
            listCashierQueue.BeginUpdate();
            listCashierQueue.Items.Clear();
            foreach (object obj in cashierList)
                listCashierQueue.Items.Add(obj?.ToString());
            listCashierQueue.EndUpdate();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!CashierClass.TryServeNext(out string served))
            {
                MessageBox.Show("No customers in queue.", "Next",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
            _customerView.SetNowServing(served);

         
            DisplayCashierQueue(CashierClass.CashierQueue);
        }
    }
}
