using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MasterSignal
{
    public partial class frmLogin : Form
    {
        Utilities util = new Utilities();
        DataObject db = new DataObject();
        public frmLogin()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
            Reset();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string fileName = util.GetConfigValue("DBFilePath");
            if (File.Exists(fileName))
            {
                if (IsValidUser(txtUserName.Text, txtPassword.Text) == true)
                {
                    db.InsertEvents(new LoginEvents(DateTime.Now.ToString(), "Logged in User", txtUserName.Text));
                    db.SetupInitialDB(txtUserName.Text);
                    this.Hide();
                    frmDashBoard fpopup = new frmDashBoard();
                    fpopup.loginDetail = db.GetUserDetails(txtUserName.Text);
                    LoggedInUser.Role = fpopup.loginDetail.RoleType;
                    LoggedInUser.name = txtUserName.Text;

                    if (fpopup.loginDetail.RoleType == RoleType.User)
                        fpopup.loginDetail.RoleType = LoggedInUser.Role = (rdoCusRole.Checked == true) ? RoleType.Customer : RoleType.User;
                    fpopup.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                util.showMessage("Please Check, DB file not exists. " + fileName);
                txtUserName.Focus();
            }
        }

        private bool IsValidUser(string uname, string pwd)
        {
            if (db.IsValidUSer(uname, pwd) == true)
            {
                if (db.IsUserActive(uname) == true)
                {
                    return true;
                }
                else
                {
                    util.showMessage("Please contact app support, The login details are not active.", "info");
                    return false;
                }
            }
            else
            {
                util.showMessage("Please check the Username and Password");
                return false;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (checkLicence())
            {
                txtUserName.Text = util.GetConfigValue("UserName");
                txtPassword.Text = util.GetConfigValue("Password");
                if (util.GetConfigValue("Role").ToLower() == "usr")
                {
                    rdoCusRole.Visible = true;
                    rdoUserRole.Visible = true;
                }
            }
        }
        private bool checkLicence()
        {
            return true;
        }

        private void lnkNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grpLogin.Visible = false;
            grpNewUser.Visible = true;
            lnkBack.Visible = true;
            lnkNewUser.Visible = false;
            this.Height = 400;
        }

        private void lnkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reset();
        }

        protected void Reset()
        {
            grpLogin.Visible = true;
            grpNewUser.Visible = false;
            lnkBack.Visible = false;
            lnkNewUser.Visible = true;
            Height = 320;
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.Image = new Bitmap("images/SFA_Logo.png");

            MaximizeBox = false;
            MinimizeBox = false;
            Text = Utilities.AppName;
            rdoCusRole.Visible = false;
            rdoUserRole.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearNewuserForm();
        }

        private void clearNewuserForm()
        {
            txtNewUN.Text = "";
            txtNewPass.Text = "";
            txtNewConPass.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            if (validateNewUser() == true)
            {
                string line = txtNewUN.Text + "," + txtNewConPass.Text + "," + txtPhone.Text + "," + txtEmail.Text;
                StreamWriter sw = File.AppendText("FxData/Data/AppUsers.txt");
                sw.WriteLine(line);
                sw.Close();
                util.showMessage("User created sucessflly, go to login page the enter app.", "info");
            }
        }
        protected bool validateNewUser()
        {
            if (txtNewConPass.Text != txtNewPass.Text)
            {
                util.showMessage("Please check password and confirm password");
                return false;
            }
            if (txtNewUN.Text == "")
            {
                util.showMessage("Please enter valid user name");
                return false;
            }
            if (txtNewConPass.Text.Length <= 3)
            {
                util.showMessage("Please enter password must be more than 3 letter.");
                return false;
            }
            return true;
        }
    }
}
