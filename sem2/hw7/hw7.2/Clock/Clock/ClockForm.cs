using System;
using System.Windows.Forms;

namespace Clock
{
    public partial class Clock : Form
    {
        public Clock()
        {
            InitializeComponent();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            dataLabel.Text = DateTime.Now.ToString("dd MMMM");
            weekdayLabel.Text = DateTime.Now.ToString("dddd");
        }
    }
}
