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
    public partial class QueuingForm : Form
    {
        private Cashier cashier = new Cashier();
        private CashierWindowQueueForm cashierWindowQueueForm;

        public QueuingForm()
        {
            InitializeComponent();
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            lblQueue.Text = cashier.GenerateNumber("P - ");
            Cashier.CurrentNumber = lblQueue.Text;
            Cashier.CashierQueue.Enqueue(Cashier.CurrentNumber);


            if (cashierWindowQueueForm == null || cashierWindowQueueForm.IsDisposed)
            {
                cashierWindowQueueForm = new CashierWindowQueueForm();
                cashierWindowQueueForm.Show();
            }

            cashierWindowQueueForm.DisplayCashierQueue(Cashier.CashierQueue);
        }

        private void QueuingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
