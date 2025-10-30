using System;
using System.Collections.Generic;
using System;
using System.Windows.Forms;

namespace BankAccountsApp
{
    public partial class Form1 : Form
    {
        List<BankAccount> BankAccounts = new List<BankAccount>();

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OwnerTxt.Text))
            {
                MessageBox.Show("Please enter an owner name.");
                return;
            }

            BankAccount bankAccount = new BankAccount(OwnerTxt.Text);
            BankAccounts.Add(bankAccount);
            RefreshGrid();
            OwnerTxt.Text = string.Empty;
        }

        private void RefreshGrid()
        {
            BankAccountsGrid.DataSource = null;
            BankAccountsGrid.DataSource = BankAccounts;
        }

        private void DepositBtn_Click(object sender, EventArgs e)
        {
            // التحقق من وجود صف محدد
            if (BankAccountsGrid.CurrentRow == null)
            {
                MessageBox.Show("Please select an account first.");
                return;
            }

            // قراءة رقم الحساب من الخلية
            object cell = BankAccountsGrid.CurrentRow.Cells["AccountNumber"].Value;
            string accountNumberStr = cell?.ToString();

            if (string.IsNullOrWhiteSpace(accountNumberStr))
            {
                MessageBox.Show("Invalid account number.");
                return;
            }

            // تحويل النص إلى نوع Guid
            if (!Guid.TryParse(accountNumberStr, out Guid accountGuid))
            {
                MessageBox.Show("Invalid account number format.");
                return;
            }

            // البحث عن الحساب
            BankAccount selectedAccount = BankAccounts.Find(x => x.AccountNumber == accountGuid);

            if (selectedAccount == null)
            {
                MessageBox.Show("Account not found.");
                return;
            }

            // إيداع المبلغ
            selectedAccount.Balance += Convert.ToDecimal(AmountNum.Value);

            // تحديث الواجهة
            RefreshGrid();
            MessageBox.Show($"Deposit successful!\nNew Balance: {selectedAccount.Balance:C}");
        }

        private void WithdrawBtn_Click(object sender, EventArgs e)
        {
            if (BankAccountsGrid.CurrentRow == null)
            {
                MessageBox.Show("Please select an account first.");
                return;
            }

            object cell = BankAccountsGrid.CurrentRow.Cells["AccountNumber"].Value;
            string accountNumberStr = cell?.ToString();

            if (string.IsNullOrWhiteSpace(accountNumberStr))
            {
                MessageBox.Show("Invalid account number.");
                return;
            }

            if (!Guid.TryParse(accountNumberStr, out Guid accountGuid))
            {
                MessageBox.Show("Invalid account number format.");
                return;
            }

            BankAccount selectedAccount = BankAccounts.Find(x => x.AccountNumber == accountGuid);

            if (selectedAccount == null)
            {
                MessageBox.Show("Account not found.");
                return;
            }

            decimal amount = Convert.ToDecimal(AmountNum.Value);

            if (selectedAccount.Balance < amount)
            {
                MessageBox.Show("Insufficient funds.");
                return;
            }

            selectedAccount.Balance -= amount;

            MessageBox.Show($"Withdrawal successful!\nNew Balance: {selectedAccount.Balance:C}");
            RefreshGrid();
        }
    }
}
