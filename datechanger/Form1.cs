using System;
using System.Windows.Forms;
using tsm = Tekla.Structures.Model;

namespace datechanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Метод оставлен пустым, если в нем ничего не нужно.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tsm.Model _model = new tsm.Model();

            if (!_model.GetConnectionStatus())
            {
                MessageBox.Show("Не удалось подключиться к модели Tekla.");
                return;
            }

            var projectInfo = _model.GetProjectInfo();
            

            string drbydateStr = string.Empty;
            string chbydateStr = string.Empty;
            DateTime drbydate, chbydate;

            if (projectInfo.GetUserProperty("FFDATE_DR_BY", ref drbydateStr) &&
                DateTime.TryParse(drbydateStr, out drbydate))
            {
                MessageBox.Show($"FFDATE_DR_BY: {drbydate:dd.MM.yyyy}");
            }
            else
            {
                MessageBox.Show("Свойство FFDATE_DR_BY не найдено или имеет неверный формат.");
            }

            if (projectInfo.GetUserProperty("FFDATE_CH_BY", ref chbydateStr) &&
                DateTime.TryParse(chbydateStr, out chbydate))
            {
                MessageBox.Show($"FFDATE_CH_BY: {chbydate:dd.MM.yyyy}");
            }
            else
            {
                MessageBox.Show("Свойство FFDATE_CH_BY не найдено или имеет неверный формат.");
            }
        }
    }
}
