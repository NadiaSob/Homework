using System;
using System.Windows.Forms;

namespace Clock
{
    /// <summary>
    /// Class that shows the current time, data and weekday. 
    /// </summary>
    public partial class Clock : Form
    {
        public Clock()
        {
            InitializeComponent();
            OnTimerTick(this, EventArgs.Empty);
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            dataLabel.Text = DateTime.Now.ToString("dd MMMM");
            weekdayLabel.Text = DateTime.Now.ToString("dddd");
        }
    }
}
