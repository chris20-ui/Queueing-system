using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QueueingSystem.QueueingSystem;

namespace QueueingSystem
{
    public partial class CashierWindowQueueForm : Form
    {
        private CustomerView customerView;
        public CashierWindowQueueForm()
        {
            InitializeComponent();
        }
        public void DisplayCashierQueue(Queue<string> queue)
        {
            ListQueue.Items.Clear(); 
            foreach (string number in queue)
            {
                ListViewItem item = new ListViewItem(number);
                ListQueue.Items.Add(item);
            }
            if (ListQueue.Columns.Count > 0)
            {
                ListQueue.Columns[0].TextAlign = HorizontalAlignment.Center;
            }
        }
        private void CashierWindowQueueForm_Load(object sender, EventArgs e)
        {
            if (ListQueue.Columns.Count == 0)
            {
                ListQueue.Columns.Add("", 200, HorizontalAlignment.Center);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

           DisplayCashierQueue(Cashier.CashierQueue);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Cashier.CashierQueue.Count > 0)
            {
                // Take the first number in queue
                string nowServing = Cashier.CashierQueue.Dequeue();

                // Refresh queue display
                DisplayCashierQueue(Cashier.CashierQueue);

                // If CustomerView is closed, create and show it
                if (customerView == null || customerView.IsDisposed)
                {
                    customerView = new CustomerView();
                    customerView.Show();
                }

                
                customerView.UpdateNowServing(nowServing);
            }
            else
            {
                MessageBox.Show("Queue is empty.");
            }
        }

        private void ListQueue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}