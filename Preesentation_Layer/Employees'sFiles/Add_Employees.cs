using System;
using System.Data;
using MyBusinessLayer;
using System.Windows.Forms;
using K_M_S_PROGRAM.GlobalClasses;
using System.IO;
using K_M_S_PROGRAM.ImportantForms;

namespace K_M_S_PROGRAM.Resources
{
    public partial class Add_Employees : Form
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

        public Add_Employees(bool IsTeacher)
        {
            InitializeComponent();
            cmEmpNames.Visible = false;

            _employee = new clsEmployee();
            _worker = new clsWorker();
            if (IsTeacher)
                { btClose.Visible = true; rdTeacher.Checked = true; }
            else
            { btClose.Visible = true; rdWorker.Checked = true; }


        }

        public delegate void CallUpdateMethod();
        public event CallUpdateMethod CallUpdate;

        public Add_Employees()
        {
            InitializeComponent();

            _employee = new clsEmployee();
            _worker = new clsWorker();
           
        }
        public Add_Employees(int ID,bool teacher)
        {
            InitializeComponent();
          
            cmEmpNames.Visible = false;

            if (teacher)
            {
                _employee = clsEmployee.Find(ID);     
                if(_employee != null)
                { 
                    rdTeacher.Checked = true;
                    FillTeacherBoxesWithData();
                    OpenAndCloseforTeacherAndWorker(true);
                }
               
            }
            else
            {
                _worker = clsWorker.Find(ID);
                if(_worker != null)
                {   
                    rdWorker.Checked = true;
                    FillWorkerBoxesWithData();
                    OpenAndCloseforTeacherAndWorker(false);
                }
            }
            btClose.Visible = true;

        }
       
        clsEmployee _employee;
        clsWorker _worker;

        void OpenAndCloseforTeacherAndWorker(bool Status)
        {
            txQualification.Visible = Status;
            txSchool.Visible = Status;
            cmSocialStutas.Visible = Status;
            txAddress.Enabled = Status;
            txEmail.Visible = Status;
            cmClases.Visible = Status;
            cmLevels.Visible = Status;
            btTestMessageNumber.Visible = Status;
        }
        private void rdWhoAdded_Click(object sender, EventArgs e)
        {
            if(rdWorker.Checked)
            {
                RestAllTexBoxes();
                FillCmWorkersWithName();
                OpenAndCloseforTeacherAndWorker(false);
               
                string st = clsGeneric.ReturnLastID("select top 1 Code+1 from WorkerInfo order by code desc");
                if (st != null && txCode.Text == "")
                    txCode.Text = st;
            }
            else if(rdTeacher.Checked)
            {
                RestAllTexBoxes();
                FillCmEmployeesWithName();
                OpenAndCloseforTeacherAndWorker(true);
                string st = clsGeneric.ReturnLastID("select top 1 Code+1 from TeachersInfo order by code desc");
                if (st != null && txCode.Text == "")
                    txCode.Text = st;
            }
        }

        private void FillCmEmployeesWithName()
        {
            DataTable Names = null;
            cmEmpNames.Items.Clear();
            Names = clsGeneric.FillComboBoxWithNames("Select Code, Name from TeachersInfo");
            foreach (DataRow row in Names.Rows)
            { cmEmpNames.Items.Add(row["Code"].ToString() +"-"+row["Name"].ToString()); }
            Names.Rows.Clear();

        }
        private void FillCmWorkersWithName()
        {
            DataTable Names = null;

            cmEmpNames.Items.Clear();
            Names = clsGeneric.FillComboBoxWithNames("Select Code,Name from WorkerInfo");
            foreach (DataRow row in Names.Rows)
            { cmEmpNames.Items.Add(row["Code"].ToString() + "-" + row["Name"].ToString()); }
            Names.Rows.Clear();

        }


        private void FillCmClasesAndLevelsNameWithNames()
        {
            DataTable Names = null;
            cmLevels.Items.Clear();
            cmClases.Items.Clear();
            Names = clsGeneric.FillComboBoxWithNames("Select Class from Clases");
            foreach (DataRow row in Names.Rows)
            { cmClases.Items.Add(row["Class"]); }
            Names.Rows.Clear();
            Names = clsGeneric.FillComboBoxWithNames("Select Level from Levels");
            foreach (DataRow row in Names.Rows)
            { cmLevels.Items.Add(row["Level"]); }
            Names.Rows.Clear();

            
        }

        string imagePath;
        private void picEmpPhoto_Click(object sender, EventArgs e)
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

                picEmpPhoto.ImageLocation = selectedFilePath;
                // ...
            }
        }

        private bool _HandleTeacherImage()
        {

            if (_employee.Image != picEmpPhoto.ImageLocation)
            {
                if (_employee.Image != "")
                {
                   
                    try
                    {
                        File.Delete(_employee.Image);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (picEmpPhoto.ImageLocation != "")
                {
                    string SourceImageFile = picEmpPhoto.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        picEmpPhoto.ImageLocation = SourceImageFile;
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
        private bool _HandleWorkerImage()
        {

            if (_worker.Image != picEmpPhoto.ImageLocation)
            {
                if (_worker.Image != "")
                {
                   
                    try
                    {
                        File.Delete(_worker.Image);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (picEmpPhoto.ImageLocation != "")
                {
                    string SourceImageFile = picEmpPhoto.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        picEmpPhoto.ImageLocation = SourceImageFile;
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
        // يوجد مشكلة عند فتح الفورم + شوف موضوع الاضافة مع التحديث اللي حصل عند اليوزرز
        private bool AddAndUpdateTeacher()
        {
            if (picEmpPhoto.ImageLocation != null)
                if (!_HandleTeacherImage())
                    return false;

            _employee.ID = Convert.ToInt16(txCode.Text) ;
            _employee.Name = txName.Text;
            _employee.Qualification = txQualification.Text;
            _employee.School = txSchool.Text;
            _employee.CardNumber = txPersonalCardNumber.Text;
            _employee.Email = txEmail.Text;
            _employee.Phone = txPhone.Text;
            _employee.Address = txAddress.Text;
            _employee.SocialStatus = Convert.ToByte(cmSocialStutas.SelectedIndex);
            _employee.Image = picEmpPhoto.ImageLocation;
            _employee.Gendor = rdMail.Checked;
            _employee.Period = rdAM.Checked;
            _employee.ClassID = clsClsases.GetClassID(cmClases.Text);
            _employee.LevelID = clsLevels.GetLevelID(cmLevels.Text);
            _employee.Salary = Convert.ToSingle(txSalary.Text);

            if (_employee.Save())
                return true;
            else
                return false;
        }

        private bool AddAndUpdateWorker()
        {
            if (picEmpPhoto.ImageLocation != null)
                if (!_HandleWorkerImage())
                    return false;

            _worker.Code = Convert.ToInt16(txCode.Text);
            _worker.name = txName.Text;
            _worker.Phone = txPhone.Text;
            _worker.CardNumber = txPersonalCardNumber.Text;
            _worker.Gendor = rdMail.Checked;
            _worker.Image = picEmpPhoto.ImageLocation;
            _worker.Salary = Convert.ToSingle(txSalary.Text);
            _worker.Period = rdAM.Checked;
            if (_worker.Save())
                return true;
            else
                return false;
        }

        private void RestAllTexBoxes()
        {
            picEmpPhoto.Image = Properties.Resources.man;
            txCode.Text = "";
            imagePath = "";
            txName.Text = "";
            txQualification.Text = "";
            txSchool.Text = "";
            txPersonalCardNumber.Text = "";
            txEmail.Text = "";
            txPhone.Text = "";         
            txAddress.Text = "";
            rdMail.Checked = false;            
            rdFimail.Checked = false;           
            rdAM.Checked = false;
            rdPM.Checked = false;
            cmClases.Text = "";
            cmLevels.Text = "";
            txSalary.Text = "";
            cmSocialStutas.Items.Clear();
            cmSocialStutas.Items.Add("طبقة غنية");
            cmSocialStutas.Items.Add("طبقة متوسطة");
            cmSocialStutas.Items.Add("طبقة فقيرة");
            FillCmClasesAndLevelsNameWithNames();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if(rdTeacher.Checked)
            {
                if (AddAndUpdateTeacher())
                {
                    CallUpdate?.Invoke();
                   
                        clsUtil.Show("تم حفظ البيانات بنجاح", true);
                    
                    RestAllTexBoxes();
                    FillCmEmployeesWithName();
                    _employee = new clsEmployee();
                }
                else
                {
                    clsUtil.Show("لم يتم حفظ البيانات تأكد من أنك قمت بملئ المدخلات بصورة صحيحة", false);
                }
            }
            else if(rdWorker.Checked)
            {
                if(AddAndUpdateWorker())
                {
                    CallUpdate?.Invoke();
                    clsUtil.Show("تم حفظ البيانات بنجاح");
                    RestAllTexBoxes();
                    FillCmWorkersWithName();
                    _worker = new clsWorker();
                }
                else
                {
                    clsUtil.Show("لم يتم حفظ البيانات تأكد من أنك قمت بملئ المدخلات بصورة صحيحة", false);
                    if (btClose.Visible)
                        this.Close();
                }
            }

            if (btClose.Visible)
                this.Close();
        }

        private void Add_Employees_Load(object sender, EventArgs e)
        {
            string st = clsGeneric.ReturnLastID("select top 1 Code+1 from TeachersInfo order by code desc");
            if (st != null && txCode.Text == "")
                txCode.Text = st;

            txDataOfBirth.MaxDate = DateTime.Now.AddYears(-15);
            FillCmClasesAndLevelsNameWithNames();
            FillCmEmployeesWithName();
            if (_employee != null && _employee.ClassID != -1)
            {
                cmClases.SelectedIndex = cmClases.FindString(_employee.ClassName);
                cmLevels.SelectedIndex = cmLevels.FindString(_employee.LevelName);
            }
        }

       private void FillTeacherBoxesWithData()
       {

            if (File.Exists(_employee.Image))
                picEmpPhoto.ImageLocation = _employee.Image;
            else
                picEmpPhoto.Image = Properties.Resources.man;

            txCode.Text = _employee.ID.ToString();
            imagePath = _employee.Image;
            txName.Text = _employee.Name;
            txQualification.Text = _employee.Qualification;
            txSchool.Text = _employee.School;
            txPersonalCardNumber.Text = _employee.CardNumber;
            txEmail.Text = _employee.Email;
            txPhone.Text = _employee.Phone;
            txAddress.Text = _employee.Address;
            cmSocialStutas.SelectedIndex = _employee.SocialStatus;
          
            if (_employee.Gendor)
                rdMail.Checked = true;
            else
                rdFimail.Checked = true;
            if (_employee.Period)
                rdAM.Checked = true;
            else
                rdPM.Checked = true;
            txSalary.Text = _employee.Salary.ToString();


            cmClases.SelectedIndex = cmClases.FindString(_employee.ClassName);
            cmLevels.SelectedIndex = cmLevels.FindString(_employee.LevelName);
        }

        private void FillWorkerBoxesWithData()
        {
            txQualification.Text = "";
            txSchool.Text = "";
            txEmail.Text = "";
            txAddress.Text = "";
            cmSocialStutas.Text = "";
            cmClases.Text = "";
            cmLevels.Text = "";

            if (_worker.Image != "")
                if (File.Exists(_worker.Image))
                    picEmpPhoto.ImageLocation= _worker.Image;
                else
                    picEmpPhoto.Image = Properties.Resources.man;
            txCode.Text = _worker.Code.ToString();
            txName.Text = _worker.name;
            txPersonalCardNumber.Text = _worker.CardNumber;
            txPhone.Text = _worker.Phone;
            txSalary.Text = _worker.Salary.ToString();
            if (_worker.Gendor)
                rdMail.Checked = true;
            else
                rdFimail.Checked = true;
            if (_worker.Period)
                rdAM.Checked = true;
            else
                rdPM.Checked = true;

            
        }

        private void cmEmpNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (rdTeacher.Checked)
            {
                _employee=clsEmployee.FindByName(cmEmpNames.Text);
                FillTeacherBoxesWithData();

            }
            else
            {
               _worker = clsWorker.FindByName(cmEmpNames.Text);
                FillWorkerBoxesWithData();
            }
        }

        private void btDalete_Click(object sender, EventArgs e)
        {
            picEmpPhoto.ImageLocation = "";
            picEmpPhoto.Image = Properties.Resources.man;
        }

        private void txCode_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btTestMessageNumber_Click(object sender, EventArgs e)
        {
            if (txPhone.Text.Length == 11)
            {
                clsSend.Send_Whats_App_Message_For_One(txPhone.Text, $"السلام عليكم,\n يجدر الاشارة انه سيتم استخدام هذا الرقم للمتابعة من قبل {clsGlobal.Settings.OrgName} ");
            }
        }


        private void btClose_Click(object sender, EventArgs e)
        {
            CallUpdate?.Invoke();
            this.Close();
        }
    }
}
