namespace Lab7_1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            file1.Filter = "(*.jpg)|*.jpg";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string fname;
            if (file1.ShowDialog() == DialogResult.OK)
            {
                fname = file1.FileName;
                pct.Image = Image.FromFile(fname);
                textBox1.Text = file1.SafeFileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pct.Image != null) //åñëè â pictureBox åñòü èçîáðàæåíèå
            {
                //ñîçäàíèå äèàëîãîâîãî îêíà "Ñîõðàíèòü êàê..", äëÿ ñîõðàíåíèÿ èçîáðàæåíèÿ
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Ñîõðàíèòü êàðòèíêó êàê...";
                //îòîáðàæàòü ëè ïðåäóïðåæäåíèå, åñëè ïîëüçîâàòåëü óêàçûâàåò èìÿ óæå ñóùåñòâóþùåãî ôàéëà
                savedialog.OverwritePrompt = true;
                //îòîáðàæàòü ëè ïðåäóïðåæäåíèå, åñëè ïîëüçîâàòåëü óêàçûâàåò íåñóùåñòâóþùèé ïóòü
                savedialog.CheckPathExists = true;
                //ñïèñîê ôîðìàòîâ ôàéëà, îòîáðàæàåìûé â ïîëå "Òèï ôàéëà"
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                //îòîáðàæàåòñÿ ëè êíîïêà "Ñïðàâêà" â äèàëîãîâîì îêíå
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) //åñëè â äèàëîãîâîì îêíå íàæàòà êíîïêà "ÎÊ"
                {
                    try
                    {
                        pct.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Íåâîçìîæíî ñîõðàíèòü èçîáðàæåíèå", "Îøèáêà",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }   }
    }
}