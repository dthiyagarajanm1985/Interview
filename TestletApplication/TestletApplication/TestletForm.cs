using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestletLibrary;
namespace TestletApplication
{
    public partial class TestletForm : Form
    {
        public TestletForm()
        {
            InitializeComponent();
        }
        int Item = 0;
        List<ItemsItem> Items = null;
        private void TestletForm_Load(object sender, EventArgs e)
        {
            try
            {
                Testlet testlet = new Testlet();
                Items=testlet.Randomize();
                LoadData();
                btnPrev.Enabled = false;
                btnSubmit.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void LoadData()
        {
            int ItemID = Item + 1;
            label1.Text = ItemID.ToString();
           label2.Text= Items[Item].ItemDesc;
           radioButton1.Text = Items[Item].Answers[0].AnswerDesc;
           radioButton2.Text = Items[Item].Answers[1].AnswerDesc;
           radioButton3.Text = Items[Item].Answers[2].AnswerDesc;
           radioButton4.Text = Items[Item].Answers[3].AnswerDesc;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
            Item--;
            LoadData();
            if (Item == 0)
            {
                btnPrev.Enabled = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Item++;
            btnPrev.Enabled = true;
            LoadData();
            if (Item == Items.Count-1)
            {
                btnNext.Enabled = false;
                btnSubmit.Show();
            }
        }
    }
}
