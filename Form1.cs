
namespace MultiTool
{
    public partial class Form1 : Form
    {
        private readonly Logic _logic;/////
        public Form1()
        {
            InitializeComponent();
            // Создаём ОДИН РАЗ при запуске формы
            _logic = new Logic(msg =>
            {
                txtLog1.AppendText(msg + Environment.NewLine);
                txtLog1.SelectionStart = txtLog1.Text.Length;
                txtLog1.ScrollToCaret();
            });
            this.Text = "MultiTool";
            button4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtLog1.Clear();
            if (_logic.devMode == false)
            {
                _logic.CreateMainFoldrs();
            }
            else if (_logic.devMode == true)
            {
                _logic.DevCreateMainFoldrs();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtLog1.Clear();
            if (_logic.devMode == false)
            {
                _logic.SortDownloads();
            }
            else if (_logic.devMode == true)
            {
                _logic.DevSortDownloads();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtLog1.Clear();
            _logic.DevMode();
            if (_logic.devMode == false)
            {
                this.Text = "MultiTool";
                button4.Visible = false;
            }
            else if (_logic.devMode == true)
            {
                this.Text = "DevMode.MultiTool";
                button4.Visible = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtLog1.Clear();
            _logic.DevDeltestFiles();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtLog1.ScrollBars = ScrollBars.Vertical;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            _logic.OpenJsonfile();
        }
    }
}
