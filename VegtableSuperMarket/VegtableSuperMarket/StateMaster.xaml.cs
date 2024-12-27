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

namespace VegtableSuperMarket
{
    /// <summary>
    /// Interaction logic for StateMaster.xaml
    /// </summary>
    public partial class StateMaster : Window
    {
        public StateMaster()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            // string path = Properties.Settings.Default.Rootpath;

            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
              //path = path + "//Vegsupermarketdetails" + "//RegistrationDetails" + "//userregistraion.txt";
             // path = path + "//Vegsupermarketdetails" + "//RegistrationDetails";

           string path_check = path + "//Vegsupermarketdetails";
            if (!Directory.Exists(path_check))
            {
                string pathstate = path + "//Vegsupermarketdetails" + "//MasterData" + "//masterstate.txt";

                //string pathcountry = Path.Join(Rootpath, "MasterData", "State", cmbcountry.SelectedItem + ".txt");
                string state = txtstate.Text;

                File.WriteAllText(pathstate, state);
            }
            else
            {
                Directory.CreateDirectory(path + "//Vegsupermarketdetails");
            }
        }

    }
        
    
}
