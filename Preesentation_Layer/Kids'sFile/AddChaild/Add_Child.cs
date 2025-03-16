using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using K_M_S_PROGRAM.GlobalClasses;
using K_M_S_PROGRAM.ImportantForms;
using MyBusinessLayer; 

namespace K_M_S_PROGRAM.Resources
{
    public partial class Add_Child : Form
    {
        //move this form
        bool move;
        int moveX, moveY;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            moveX = e.X;
            moveY = e.Y;
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - moveX, MousePosition.Y - moveY);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
        public delegate void OnFinshed();
        public event OnFinshed Finshed;
        public Add_Child()
        {
            InitializeComponent();
            FillCmKidsNameWithNames();

            _addChild = new clsChild();
        }
        public Add_Child(char add)
        {
            InitializeComponent();
            FillCmKidsNameWithNames();
            cmKidsNames.Visible = false;
            _addChild = new clsChild();
        }
        public Add_Child(int Code)
        {
            InitializeComponent();
            FillCmKidsNameWithNames();
            cmKidsNames.Visible = false;

            _addChild = clsChild.FindByCode(Code);
            btClose.Visible = true;
            FillChildPersonalData();
        }
        clsChild _addChild = null;
        string CurrentID;
        private bool AddUpdateChild()
        {
           
            
            _addChild.Code = Convert.ToInt16(txCode.Text);
            _addChild.name= txName.Text;
            _addChild.address = txAddress.Text;
            _addChild.city = txCity.Text;
            _addChild.dateOfBirth = txDataOfBirth.Value;
            _addChild.period = rdAM.Checked;
            _addChild.classID = clsClsases.GetClassID(cmClass.Text);
            _addChild.levelID = clsLevels.GetLevelID(cmLevel.Text);
            _addChild.dateOfJoin = txDateOfJoin.Value;
            _addChild.branch = "1";
            _addChild.bus = "1";
            _addChild.gendor = rdMale.Checked;
            _addChild.image = picPersonalImage.ImageLocation!=null? picPersonalImage.ImageLocation:"";
            _addChild.howYouKnowNurssry = Convert.ToByte(cmHowYouKnowAboutNursery.SelectedIndex + 1);
            _addChild.socialStatus = Convert.ToByte(cmFatherSocialStatus.SelectedIndex + 1);
            _addChild.messageNumber = txMessageNumber.Text;
            _addChild.mail = txEmail.Text;
            _addChild.infoAboutChild = txInfoAboutChild.Text;
            _addChild.SubAmount = Convert.ToSingle(txSubAmount.Text!=""? txSubAmount.Text : "0");

            if (_addChild.Save())
                return true;
            else
                return false;


        }
        string imagePath;
        private void picPersonalImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                imagePath = selectedFilePath;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                picPersonalImage.ImageLocation = selectedFilePath ;
                // ...
            }
        }

        private void btAddChail_Click(object sender, EventArgs e)
        {
             if (picPersonalImage.ImageLocation != null)
                if (!_HandlePersonImage())
                    return;


            if (AddUpdateChild())
            {
                clsUtil.Show("تم حفظ بيانات الطفل بنجاح");
                ResetAllTexBoxes();
                _addChild = new clsChild();
            }
            else
            {
                clsUtil.Show("لم تتم عملية الحفظ تأكد من أنك قمت بملئ المدخلات بصورة صحيحة أو انك لم تدخل كودا مضاف لطالب آخر", false);
            }
            txDataOfBirth.MinDate = DateTime.Now.AddYears(-4);
            txDateOfJoin.MinDate = DateTime.Now.AddYears(-4);
            
        }

        private void FillCmKidsNameWithNames()
        {
            DataTable Names = clsGeneric.FillComboBoxWithNames("Select cast(Code as nvarchar) + '-' +Name as Name from KidsPersonalInfo");
            cmKidsNames.Items.Clear();
            foreach (DataRow row in Names.Rows) 
            { cmKidsNames.Items.Add(row["Name"]); }
            Names.Rows.Clear();
            cmClass.Items.Clear();
            Names = clsGeneric.FillComboBoxWithNames("Select Class from Clases");
            foreach (DataRow row in Names.Rows)
            { cmClass.Items.Add(row["Class"]); }
            Names.Rows.Clear();
            cmLevel.Items.Clear();
           Names = clsGeneric.FillComboBoxWithNames("Select Level from Levels");
            foreach (DataRow row in Names.Rows)
            { cmLevel.Items.Add(row["Level"]); }
            Names.Rows.Clear();
        }

        void GetLastCode()
        {
            string st = clsGeneric.ReturnLastID("select top 1 Code+1 from KidsPersonalInfo order by code desc");
            if (st != null && txCode.Text=="")
                txCode.Text = st;

        }
        private void Add_Child_Load(object sender, EventArgs e)
        {
            GetLastCode();

            cmClass.SelectedIndex = 0;
            cmLevel.SelectedIndex = 0;
            txDataOfBirth.MaxDate = DateTime.Now.AddYears(-2);
            txDataOfBirth.MinDate = DateTime.Now.AddYears(-4);
            txDateOfJoin.MinDate = DateTime.Now.AddYears(-4);
            txDateOfJoin.MaxDate = DateTime.Now;

        }
        private void btAddBrothers_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txCode.Text, out int ID)||txCode.Text!="")
            {
                AddUpdate_brothers add_Brothers = new AddUpdate_brothers(ID);
                add_Brothers.ShowDialog();

            }
            else
                clsUtil.Show("ليس هناك طالب محدد",false);

        }
        private bool _HandlePersonImage()
        {

            if (_addChild.image != picPersonalImage.ImageLocation)
            {
                if (_addChild.image != "")
                {
                    
                    try
                    {
                        File.Delete(_addChild.image);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (picPersonalImage.ImageLocation != "")
                {
                    string SourceImageFile = picPersonalImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        picPersonalImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }
        private void ResetAllTexBoxes()
        {
            btAddBrothers.Enabled = false;
            picPersonalImage.Image = Properties.Resources.boy;
            FillCmKidsNameWithNames();
            imagePath = "";
            txCode.Text = "";
            txName.Text = "";
            txCity.Text = "";
            txAddress.Text = "";
            txDataOfBirth.Text = "";
            txDateOfJoin.Text = "";
            txSubAmount.Text= "";
            cmClass.Text = "";
            cmLevel.Text = "";

            cmBus.Text = "";
            cmBransh.Text = "";


            cmHowYouKnowAboutNursery.Text = "";
            cmFatherSocialStatus.Text = "";
            txMessageNumber.Text = "";
            txEmail.Text = "";

            txInfoAboutChild.Text = "";
            GetLastCode();

        }
        private void FillChildPersonalData()
        {
            btAddBrothers.Enabled = true;
            if(File.Exists(_addChild.image))
                picPersonalImage.ImageLocation = _addChild.image;
            else
                picPersonalImage.Image = Properties.Resources.boy;

            imagePath = _addChild.image;
            txCode.Text = _addChild.Code.ToString();
            txName.Text = _addChild.name;
            txCity.Text = _addChild.city;
            txAddress.Text = _addChild.address;
            txDataOfBirth.Value = _addChild.dateOfBirth;
            txDateOfJoin.Value = _addChild.dateOfJoin;
            txSubAmount.Text = _addChild.SubAmount.ToString();

            cmClass.SelectedIndex = cmClass.FindString(_addChild.className);
            rdAM.Checked = _addChild.period;
            cmLevel.SelectedIndex = cmLevel.FindString(_addChild.levelName);
           
            cmBus.Text = _addChild.bus;
            cmBransh.Text = _addChild.branch;

            if (_addChild.gendor)
                rdMale.Checked = true;
            else
                rdFemale.Checked = true;

            
            cmHowYouKnowAboutNursery.SelectedIndex = Convert.ToByte(_addChild.howYouKnowNurssry) - 1;
            cmFatherSocialStatus.SelectedIndex = Convert.ToByte(_addChild.socialStatus) - 1;
            txMessageNumber.Text= _addChild.messageNumber;
            txEmail.Text= _addChild.mail;

            txInfoAboutChild.Text = _addChild.infoAboutChild;

           
        }
        private void cmKidsNames_SelectedIndexChanged(object sender, EventArgs e)
        {
           //في مشكلة في التحديث علي بيانات الطفل انه بيضيف رقم علي المستوي والفصل والارشيف لسه لم يختبر بعد
            _addChild = clsChild.FindByName(cmKidsNames.Text);
            txDataOfBirth.MinDate = DateTime.Now.AddYears(-50);
            txDateOfJoin.MinDate = DateTime.Now.AddYears(-50);
            txDataOfBirth.MaxDate = DateTime.Now;
            txDateOfJoin.MaxDate = DateTime.Now;
            if (_addChild != null)
                FillChildPersonalData();
            else
                clsUtil.Show("Fail", false);

        }
      
        public void btRefreash_Click(object sender, EventArgs e)
        {
            btSave.Enabled = true;
            cmKidsNames.Items.Clear();
            ResetAllTexBoxes();
            cmKidsNames.Text = "";
            FillCmKidsNameWithNames();
        }

        private void btDalete_Click(object sender, EventArgs e)
        {
            picPersonalImage.ImageLocation = "";
            picPersonalImage.Image = Properties.Resources.boy;
        }

        private void btTestMessageNumber_Click(object sender, EventArgs e)
        {
            if(txMessageNumber.Text.Length==11)
            {
                clsSend.Send_Whats_App_Message_For_One(txMessageNumber.Text, $"السلام عليكم,\n يجدر الاشارة انه سيتم استخدام هذا الرقم لمتابعة حالة طفلكم من قبل {clsGlobal.Settings.OrgName} ");
            }
        }

        private void txSubAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            { e.Handled = true; errorProvider1.SetError((TextBox)sender, "لا يمكنك إدخال احرف في هذه الخانة"); }
            else
                errorProvider1.Clear();
        }

        private void txEmail_TextChanged(object sender, EventArgs e)
        {
            if (!clsValidatoin.ValidateEmail(txEmail.Text))
                errorProvider1.SetError((TextBox)sender, "برجاء إدخال الايميل بصورة صحيحة!");
            else
                errorProvider1.Clear();
        }

        private void txName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            { e.Handled = true; errorProvider1.SetError((TextBox)sender, "لا يمكنك إدخال ارقام في هذه الخانة"); }
            else
                errorProvider1.Clear();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Finshed?.Invoke();
            this.Close();
        }
    }
}
