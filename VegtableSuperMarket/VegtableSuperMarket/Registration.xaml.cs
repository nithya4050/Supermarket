using Newtonsoft.Json;
using System.IO;
using System.Windows;
using VegtableSuperMarket.Common;
using VegtableSuperMarket.Vegregistration;
using System.Globalization;
using System.Windows.Controls;
using System.Xml.Linq;

namespace VegtableSuperMarket
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        string Rootpath;
        List<veg> List_registration;
        String userdata;

        public Registration()
        {
            InitializeComponent();
            Deserializsation();

            Save_RootPath();
        }

        public void Save_RootPath()
        {
            VegtableSuperMarket.Properties.Settings.Default.Rootpath = Rootpath;
            VegtableSuperMarket.Properties.Settings.Default.Save();
        }

        public void Deserializsation()
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            path = path + "//Vegsupermarketdetails" + "//RegistrationDetails" + "//userregistraion.txt";
            if (File.Exists(path))
            {
                string userdata = File.ReadAllText(path);
                List_registration = JsonConvert.DeserializeObject<List<veg>>(userdata);
            }
            lstRegistration.ItemsSource = List_registration;
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            this.Close();
            login.ShowDialog();
        }

        private void btnregistration_Click(object sender, RoutedEventArgs e)
        {

            ///<summary>
            /// RequiredField_validation for required field validation same function for all textbox
            /// 
            /// single parameter
            ///
            /// </summary>
            

            bool Validation_checking = true;


            Cvalidation cvalidation = new Cvalidation();

            if (Validation_checking == true)
            {
                if (cvalidation.RequiredField_validation(txtusername.Text) == true)
                {
                    Validation_checking = true;
                }
                else
                {
                    MessageBox.Show("Fill username");
                    Validation_checking = false;

                }
            }

            if (Validation_checking == true)
            {

                if (cvalidation.RequiredField_validation(txtpassword.Text) == true)
                {

                }
                else
                {
                    MessageBox.Show("Fill password");
                    Validation_checking = false;
                }
                if (Validation_checking == true)
                {
                    if (cvalidation.RequiredField_validation(txtconfirmpassword.Text) == true)
                    {
                        if (cvalidation.compare_password(txtpassword.Text, txtconfirmpassword.Text) == true)
                        {
                            Validation_checking = true;
                        }
                        else
                        {
                            MessageBox.Show("Password and confirmed password must match");
                            Validation_checking = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fill confirm password");
                        Validation_checking = false;
                    }
                }
            }

            if (Validation_checking == true)
            {
                if (cvalidation.RequiredField_validation(txtage.Text) == true)
                {
                    int age = Convert.ToInt32(txtage.Text);
                    if (cvalidation.age_validation(age) == true)
                    {
                        Validation_checking = true;
                    }
                    else
                    {
                        MessageBox.Show("Age must be greater than 18");
                        Validation_checking = false;
                    }
                }
                else
                {
                    MessageBox.Show("Fill Age");
                    Validation_checking = false;
                }
            }


            if (Validation_checking == true)
            {
                if (cvalidation.RequiredField_validation(txtphonenumber.Text) == true)
                {
                    bool valida = true;

                    string[] Phoneno_numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };


                    if (cvalidation.phoneno_numeric1(txtphonenumber.Text, Phoneno_numbers) == true)
                    {
                        Validation_checking = true;
                    }
                    else
                    {
                        MessageBox.Show("Numeric numbers only allowed");
                        valida = false;
                        Validation_checking = false;
                    }
                    if (valida == true)
                    {
                        if (cvalidation.phoneno_validation(txtphonenumber.Text) == true)
                        {
                            Validation_checking = true;
                        }
                        else
                        {
                            MessageBox.Show("Only 10 numbers are valid");
                            Validation_checking = false;

                        }
                    }

                }
                else
                {
                    MessageBox.Show("Fill Phoneno");
                    Validation_checking = false;
                }
            }
            if (Validation_checking == true)
            {
                if (cvalidation.RequiredField_validation(txtemail.Text) == true)
                {
                    if (cvalidation.Email_validation2(txtemail.Text) == true)
                    {
                        Validation_checking = true;

                    }
                    else
                    {
                        MessageBox.Show("Email must contain @ and dot");
                        Validation_checking = false;
                    }
                }
                else
                {
                    MessageBox.Show("Fill Email");
                    Validation_checking = false;
                }
            }
            //if (cvalidation.RequiredField_validation(txtcity.Text) == false)
            //{
            //    MessageBox.Show("Fill City");
            //}
            //if (cvalidation.RequiredField_validation(txtstate.Text) == false)
            //{
            //    MessageBox.Show("Fill State");
            //}

            if(Validation_checking == true)
            {
                if (List_registration == null)
                {
                    List_registration = new List<veg>();
                }

                Random random = new Random();
                int number = random.Next();

                // add data in list

                List_registration.Add(new veg { Userid = number, Username = txtusername.Text, Password = txtpassword.Text, Cpassword = txtpassword.Text, Age = txtage.Text, Phoneno = txtphonenumber.Text, Email = txtemail.Text });
                lstRegistration.ItemsSource = List_registration;

                //file stored using json format
                string userdata = JsonConvert.SerializeObject(List_registration);
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
              
                string path_check = path + "//Vegsupermarketdetails";
                if (!Directory.Exists(path_check))
                {
                    Directory.CreateDirectory(path + "//Vegsupermarketdetails" + "//RegistrationDetails");
                }
                path = path + "//Vegsupermarketdetails" + "//RegistrationDetails" + "//userregistraion.txt";
                File.WriteAllText(path, userdata);


                Deserializsation();
                Clear();
            }


        }

        private void btnstate_Click(object sender, RoutedEventArgs e)
        {
            StateMaster stateMaster = new StateMaster();
            stateMaster.ShowDialog();
        }

        private void lstRegistration_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            veg Regis = lstRegistration.SelectedItem as veg;

            if (Regis != null)
            {
                int userId = Regis.Userid;
                txtusername.Text = Regis.Username;
                txtpassword.Text = Regis.Password;
                txtconfirmpassword.Text = Regis.Cpassword;
                txtage.Text = Regis.Age;
                txtphonenumber.Text = Regis.Phoneno;
                txtemail.Text = Regis.Email;

            }
        }

        public void Clear()
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtconfirmpassword.Text = "";
            txtemail.Text = "";
            txtphonenumber.Text = "";
            txtage.Text = "";
           
        }

    }
}
