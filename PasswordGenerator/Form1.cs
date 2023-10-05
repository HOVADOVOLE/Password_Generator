namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        private readonly string[] checkboxLabels = { "Uppercase", "Numbers", "Symbols", "Save to File" };
        private readonly List<bool> checkedParams = new List<bool>();

        public Form1()
        {
            InitializeComponent();

            foreach (string item in checkboxLabels)
            {
                checkedListBox1.Items.Add(item);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            checkedParams.Clear();

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedParams.Add(checkedListBox1.GetItemChecked(i));
            }

            try
            {
                int length = int.Parse(txtLength.Text);
                if(length > 3)
                    new Generator(checkedParams[0], checkedParams[1], checkedParams[2], checkedParams[3], length, lblGeneratedPassword);

                else { MessageBox.Show("Password length must be greater than 3!"); }
                txtLength.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter only number U stupid baka!");
            }
        }
    }
}