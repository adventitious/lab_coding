using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace s20_project
{
    /// <summary>
    /// Interaction logic for Save.xaml
    /// </summary>
    public partial class Save : Window
    {
        public Contest Contest;
        public Save( Contest contest)
        {
            InitializeComponent();
            Contest = contest;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_SaveJson_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject( Contest );

            // https://stackoverflow.com/questions/29163755/dump-object-to-json-pretty-print-string
            JToken jt = JToken.Parse(json);
            string formattedJson = jt.ToString();

            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, formattedJson);

                // MessageBox.Show("You said: " + " Btn_Save3: " + formattedJson + "  " + saveFileDialog.FileName);

                Contest = JsonConvert.DeserializeObject<Contest>(formattedJson);
            }
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            // IsCancel="true" 
            this.Close();
        }
    }
}
