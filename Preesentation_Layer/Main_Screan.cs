using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;
using SixLabors.ImageSharp.ColorSpaces.Conversion;
using K_M_S_PROGRAM.UsersFiles;
using K_M_S_PROGRAM.TreasuryFiles;
using K_M_S_PROGRAM.Evaluations_sFiles;
namespace K_M_S_PROGRAM.Resources
{
    public partial class Main_Screan : Form
    {
      
        public Main_Screan(clsUser login)
        {
            InitializeComponent();
            Permission = Convert.ToInt32(login.Pirrimsion);
            UserName = login.Name;
            ImagePath = login.ImagePath;
            clsGlobal.main_Screan = this;
            clsGlobal.CurrentUser = login;


        }


        sbyte seconds = 10, minutes = 0, hours = 0;
        bool _Hide = true;
        bool IsDarkMode = true;
        int Permission = -1;
        string UserName = "";
        string ImagePath = "";
        AccesesDeined acceses = new AccesesDeined();
        private void ShowUserNameAndUserImage()
        {
            if(clsGlobal.CurrentUser.Code==1)
            {
                picUserImage.Image = Properties.Resources.My_logo;
                lbUserName.Text = UserName;

                return;
            }
            lbUserName.Text = UserName;
            if (ImagePath != "")
                picUserImage.ImageLocation = ImagePath;
            else
                picUserImage.Image = Properties.Resources.Logo__7_;

            
        }

        public Main_Screan()
        {
            InitializeComponent();
        }
        byte ListHeight = 35;

        void CloseAllLists()
        {
            pnMainMenue.Height = ListHeight;
            pnKidsInfo.Height = ListHeight;
            pnEmploInfo.Height = ListHeight;
            pnSubscripList.Height = ListHeight;
            pnAccountsList.Height = ListHeight;
            pnEvaluation.Height = ListHeight;
            pnEvaluationList.Height = ListHeight;
            pnAbsenceList.Height = ListHeight;
            pnMessageList.Height = ListHeight;
            pnNotesList.Height = ListHeight;
            pnLevelsList.Height = ListHeight;
            pnClassesList.Height = ListHeight;
            pnTreasury.Height = ListHeight;
            pnUsersList.Height = ListHeight;
            pnSettingsList.Height = ListHeight;
        }
        private void btKidsInfo_Click(object sender, EventArgs e)
        {
            if (pnKidsInfo.Size.Height == ListHeight)
            {
                CloseAllLists();
                //  btKidsInfo.Image = Properties.Resources.down;
                pnKidsInfo.Height = 186;
            }
            else
            {
                // btKidsInfo.Image = Properties.Resources.less_than;
                pnKidsInfo.Height = ListHeight;
            }
        }

        private void btMenueInfo_Click(object sender, EventArgs e)
        {
            if (pnMainMenue.Size.Height == ListHeight)
            {
                CloseAllLists();

                //btMenueInfo.Image = Properties.Resources.down;
                pnMainMenue.Height = 76;
            }
            else
            {
                //btMenueInfo.Image = Properties.Resources.less_than;
                pnMainMenue.Height = ListHeight;
            }
        }

        private void btEmploInfo_Click(object sender, EventArgs e)
        {
           
            if (pnEmploInfo.Size.Height == ListHeight)
            {
                CloseAllLists();
                // btEmploInfo.Image = Properties.Resources.down;
                pnEmploInfo.Height= 130;
            }
            else
            {
               // btEmploInfo.Image = Properties.Resources.less_than;
                pnEmploInfo.Height = ListHeight;
            }
        }

        private void btSubscripIList_Click(object sender, EventArgs e)
        {
            if (pnSubscripList.Size.Height == ListHeight)
            {
            CloseAllLists();
               // btSubscripIList.Image = Properties.Resources.down;
                pnSubscripList.Height = 141;
            }
            else
            {
                //btSubscripIList.Image = Properties.Resources.less_than;
                pnSubscripList.Height = ListHeight;
            }
        }

        private void btAccountsList_Click(object sender, EventArgs e)
        {
            if (pnAccountsList.Size.Height == ListHeight)
            {
            CloseAllLists();
                //btAccountsList.Image = Properties.Resources.down;
                pnAccountsList.Height = 103;
            }
            else
            {
               // btAccountsList.Image = Properties.Resources.less_than;
                pnAccountsList.Height = ListHeight;
            }
        }

        private void btUserList_Click(object sender, EventArgs e)
        {
            if (pnUsersList.Size.Height == ListHeight)
            {
            CloseAllLists();
                //btSettingsList.Image = Properties.Resources.down;
                pnUsersList.Height = 97;
            }
            else
            {
               // btSettingsList.Image = Properties.Resources.less_than;
                pnUsersList.Height = ListHeight;
            }
        }

        private void btBusList_Click(object sender, EventArgs e)
        {
            if (pnTreasury.Size.Height == ListHeight)
            {
            CloseAllLists();
               // btBusList.Image = Properties.Resources.down;
                pnTreasury.Height = 130;
            }
            else
            {
                //btBusList.Image = Properties.Resources.less_than;
                pnTreasury.Height = ListHeight;
            }
        }

        private void btMessageList_Click(object sender, EventArgs e)
        {
            if (pnMessageList.Size.Height == ListHeight)
            {
            CloseAllLists();
               // btMessageList.Image = Properties.Resources.down;
                pnMessageList.Height = 66;
            }
            else
            {
                //btMessageList.Image = Properties.Resources.less_than;
                pnMessageList.Height = ListHeight;
            }
        }

        private void btAbsenceList_Click(object sender, EventArgs e)
        {
            if (pnAbsenceList.Size.Height == ListHeight)
            {
            CloseAllLists();
               // btAbsenceList.Image = Properties.Resources.down;
                pnAbsenceList.Height = 135;
            }
            else
            {
                //btAbsenceList.Image = Properties.Resources.less_than;
                pnAbsenceList.Height = ListHeight;
            }
        }

        private void btEvaluationList_Click(object sender, EventArgs e)
        {
            if (pnEvaluationList.Size.Height == ListHeight)
            {
            CloseAllLists();
               // btEvaluationList.Image = Properties.Resources.down;
                pnEvaluationList.Height = 127;
            }
            else
            {
               // btEvaluationList.Image = Properties.Resources.less_than;
                pnEvaluationList.Height = ListHeight;
            }
        }

        private void btStoreList_Click(object sender, EventArgs e)
        {
            if (pnEvaluation.Size.Height == ListHeight)
            {
            CloseAllLists();
                //btStoreList.Image = Properties.Resources.down;
                pnEvaluation.Height = 80;
                btNoteyfay.Visible = false;
            }
            else
            {
                //btStoreList.Image = Properties.Resources.less_than;
                pnEvaluation.Height = ListHeight;
            }
        }

        private void btClassesList_Click(object sender, EventArgs e)
        {
            if (pnClassesList.Size.Height == ListHeight)
            {
            CloseAllLists();
                //btClassesList.Image = Properties.Resources.down;
                pnClassesList.Height = 75;
            }
            else
            {
               // btClassesList.Image = Properties.Resources.less_than;
                pnClassesList.Height = ListHeight;
            }
        }

        private void btNotesList_Click(object sender, EventArgs e)
        {
            if (pnNotesList.Size.Height == ListHeight)
            {
            CloseAllLists();
                //btNotesList.Image = Properties.Resources.down;
                pnNotesList.Height = 67;
            }
            else
            {
                //btNotesList.Image = Properties.Resources.less_than;
                pnNotesList.Height = ListHeight;
            }
        }

        private void btLevelsList_Click(object sender, EventArgs e)
        {
            if (pnLevelsList.Size.Height == ListHeight)
            {
            CloseAllLists();
                //btLevelsList.Image = Properties.Resources.down;
                pnLevelsList.Height = 75;
            }
            else
            {
                //btLevelsList.Image = Properties.Resources.less_than;
                pnLevelsList.Height = ListHeight;
            }
        }

        private void btSettingsList_Click(object sender, EventArgs e)
        {
            if (pnSettingsList.Size.Height == ListHeight)
            {
            CloseAllLists();
                //btSettingsList.Image = Properties.Resources.down;
                pnSettingsList.Height = 130;
            }
            else
            {
                // btSettingsList.Image = Properties.Resources.less_than;
                pnSettingsList.Height = ListHeight;
            }
        }
        private void BrownColorLabel(Label label)
        {
            label.ForeColor = Color.Brown;
        }

        private void WhiteColorLabel(Label label)
        {
            label.ForeColor = Color.White;
        }

        private void GoldColorButton(Button button)
        {
            button.ForeColor = Color.Gold;
        }

        private void WhiteColorButton(Button button)
        {
            button.ForeColor = Color.White;
        }

        private void SubButton_MouseEnter(object sender, EventArgs e)
        {
            GoldColorButton((Button)sender);
        }

        private void SubButton_MouseLeave(object sender, EventArgs e)
        {
            WhiteColorButton((Button)sender);
        }

        private void LabelTittle_MouseEnter(object sender, EventArgs e)
        {
            BrownColorLabel((Label)sender);
        }

        private void LabelTittle_MouseLeave(object sender, EventArgs e)
        {
            WhiteColorLabel((Label)sender);
        }
     
        //------Kids-------//

        Main_Menue mainMenu = new Main_Menue();
        Kids_Menue kids_Menue = new Kids_Menue();
        Kids_sData kids_SData = new Kids_sData();
        Add_Child add_Child = new Add_Child();
        Kids_s_Arshif kids_S_Arshif = new Kids_s_Arshif();
        Kids_s_Repports kids_S_Repports = new Kids_s_Repports();

        //------------//
        Form Sender = null;
        private void ShowAccessDenaid(Form form)
        {


            
            pnShow.Controls.Clear();
            form.TopLevel = false;
            pnShow.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            if (!IsDarkMode)
                form.BackColor = SystemColors.ControlDarkDark;
            form.Show();
           
            return;
        }
        private void ShowSubForm(Form form)
        {
            if ((Permission & Convert.ToInt32(form.Tag)) == Convert.ToInt32(form.Tag)|| Permission==-1)
            {
                //if (Sender != null)
                //    Sender.Close();
                //Sender = form;
                pnShow.Controls.Clear();
                form.TopLevel = false;
                pnShow.Controls.Add(form);
                form.Dock = DockStyle.Fill;
                if (!IsDarkMode)
                    form.BackColor = SystemColors.ControlDarkDark;

                form.Show();
               
                return;
            }
            else
            {
                ShowAccessDenaid(acceses);
                clsUtil.Show("للأسف ليس لديك وصول لهذه الشاشة من فضلك تواصل مع مدير المؤسسة!", false);
                return;
            }
        }
        private void btSubMainMenue_Click(object sender, EventArgs e)
        {
            if (mainMenu.Visible)
                mainMenu.Reafrsh1();
            ShowSubForm(mainMenu);
        }

        private void btSubKidsMenue_Click(object sender, EventArgs e)
        {
            
            if (kids_Menue.Visible)
                kids_Menue.Refrish1();
            ShowSubForm(kids_Menue);
        }

        //Move this form//
         bool move;
         int moveX,moveY;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            moveX=e.X;
            moveY=e.Y;
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(move)
            {
                this.SetDesktopLocation(MousePosition.X-moveX,MousePosition.Y-moveY);
            }
        }
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
        //------------------------/-/
        //Max&minimize
        bool isMamimize = true;
        private void btMaxMize_Click(object sender, EventArgs e)
        {
            if (isMamimize)
            {
                this.WindowState = FormWindowState.Normal;
                isMamimize = false;
            }
            else
            {
                
                this.WindowState = FormWindowState.Maximized;
                isMamimize = true;
                mainMenu.Refresh();
                kids_S_Repports.Refresh();
                employees_SList.Refresh();
                employees_S_Data.Refresh();
                add_Users.Refresh();
                win_Kids.Refresh();
                kids_SData.Refresh();
            }
        }

        private void btHide_Click(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            
        }
        //--------//
        private void btSubKidsInfo_Click(object sender, EventArgs e)
        {
            if (kids_SData.Visible)
                kids_SData.Kids_Menue_Load(null,null);
            ShowSubForm(kids_SData);
        }

        private void btAddNewChild_Click(object sender, EventArgs e)
        {
            if(add_Child.Visible)
                add_Child.btRefreash_Click(null,null);
            ShowSubForm(add_Child);
        }

        private void btArshef_Click(object sender, EventArgs e)
        {
            if (kids_S_Arshif.Visible)
                kids_S_Arshif.Kids_s_Arshif_Load(null, null);
            ShowSubForm(kids_S_Arshif);
        }

        private void btKids_Reports_Click(object sender, EventArgs e)
        {
            ShowSubForm(kids_S_Repports);
        }
        //--------Empl-----------//
        Employees_sList employees_SList = new Employees_sList();
        Employees_s_Data employees_S_Data = new Employees_s_Data();
        Add_Employees Add_Employees = new Add_Employees();
        //-----------------//
        private void btEmpList_Click(object sender, EventArgs e)
        {
            if (employees_SList.Visible)
                employees_SList.btRefreash_Click();
            ShowSubForm(employees_SList);
        }

        private void btEmpData_Click(object sender, EventArgs e)
        {
            ShowSubForm(employees_S_Data);
        }

        private void btAddEmp_Click(object sender, EventArgs e)
        {
            ShowSubForm(Add_Employees);
        }

       
        //--------Subscription----------//
        Kids_s_Subscriptions kids_S_Subscriptions = new Kids_s_Subscriptions();
        Subscription_History subscription_History = new Subscription_History();
        Payment_Subsciptions payment_Subsciptions = new Payment_Subsciptions();
        private void btSubscription_Click(object sender, EventArgs e)
        {
            if (kids_S_Subscriptions.Visible)
                kids_S_Subscriptions.btRefreash_Click();
            ShowSubForm(kids_S_Subscriptions);
        }

        private void btPayment_System_Click(object sender, EventArgs e)
        {
            if (payment_Subsciptions.Visible)
                payment_Subsciptions.btRefreash_Click();
            ShowSubForm(payment_Subsciptions);
        }

        private void bSubscription_Details_Click(object sender, EventArgs e)
        {
            if (subscription_History.Visible)
                subscription_History.RefreashInfo();
            ShowSubForm(subscription_History);
        }
        //----------Treasury-----------//
        EmploeesAccounts accounts = new EmploeesAccounts();
        EmploeesAccountsHistory accountsHistory =new EmploeesAccountsHistory();
        private void btAccounts_Click(object sender, EventArgs e)
        {
            if (accounts.Visible)
                accounts.Refreash1();
            ShowSubForm(accounts);
        }
        
        private void btAccountsHistory_Click(object sender, EventArgs e)
        {
            if (accountsHistory.Visible)
                accountsHistory.btRefreash_Click();
            ShowSubForm(accountsHistory);
        }
        //----------Evaluation-----------//
        Activity_Evaluation activity_Evaluation = new Activity_Evaluation();
        Win_Kids win_Kids = new Win_Kids();
        private void btActivity_Evaluation_Click(object sender, EventArgs e)
        {
            if (activity_Evaluation.Visible)
                activity_Evaluation.btSave_Click(null,null);
            ShowSubForm(activity_Evaluation);

        }
        WinnerArchive archive = new WinnerArchive();
        private void button2_Click(object sender, EventArgs e)
        {
            if (archive.Visible)
                archive.WinnerArchive_Load(null,null);
            ShowSubForm(archive);
        }
        private void btWinKids_Click(object sender, EventArgs e)
        {
            if (win_Kids.Visible)
                win_Kids.btRefreash_Click();
            ShowSubForm(win_Kids);

        }

        //----------Absence------//
        Add_Absence add_Absence = new Add_Absence();
        ShowEnterAndLeaveHistory showEnterAndLeaveHistory = new ShowEnterAndLeaveHistory();
        private void btAdd_Absence_Click(object sender, EventArgs e)
        {
            if (add_Absence.Visible)
                add_Absence.Add_Absence_Load(null, null);
            
            ShowSubForm(add_Absence);

        }
        private void btShow_Absence_Click(object sender, EventArgs e)
        {
            if (showEnterAndLeaveHistory.Visible)
                showEnterAndLeaveHistory.ShowEnterAndLeaveHistoryData();

            ShowSubForm(showEnterAndLeaveHistory);

        }

        //-------Message------//
        Message_Archive message_Arshif = new Message_Archive();
        private void btMessage_Arshif_Click(object sender, EventArgs e)
        {
            if (message_Arshif.Visible)
                message_Arshif.FillInfo();
            ShowSubForm(message_Arshif);

        }

        //-----Notes--------//

        NotesArchive  notesArchive = new NotesArchive();
        private void btKids_Notes_Click(object sender, EventArgs e)
        {
            if (notesArchive.Visible)
                notesArchive.FillMenueWithResult();
            
             ShowSubForm(notesArchive);

        }


        //--Classes-----//
        Classes classes = new Classes();
        private void btClasses_Level_Click(object sender, EventArgs e)
        {
            if (classes.Visible)
                classes.btRefreash();
            ShowSubForm(classes);
        }
        //-----Setting-----//
        Program_Setting program_Setting = new Program_Setting();
        User_Data user_Data = new User_Data();
        Add_Users add_Users = new Add_Users();
        AbsenceHistory absenceHistory = new AbsenceHistory();
        About_this_Program about_This_Program = new About_this_Program();
        RegistersList RegistersList = new RegistersList();
        private void btUser_Data_Click(object sender, EventArgs e)
        {
            if (user_Data.Visible)
                user_Data.Refreash();
            ShowSubForm(user_Data);

        }

        private void btProgram_Setting_Click(object sender, EventArgs e)
        {
            if (program_Setting.Visible)
                program_Setting.FillSettingWithData();
            ShowSubForm(program_Setting);

        }

        private void btAbout_this_Program_Click(object sender, EventArgs e)
        {
            ShowSubForm(about_This_Program);

        }
        private void btRegister_Click(object sender, EventArgs e)
        {
            ShowSubForm(RegistersList);
        }
        private void btAbsenceHistory_Click(object sender, EventArgs e)
        {
            if (absenceHistory.Visible)
                absenceHistory.ShowAbsenceDataWithOrder();
            ShowSubForm(absenceHistory);
        }
       
        public delegate void Call();
        public void ComputeTheCammingDate()
        {
            TimeSpan CurrentTime = DateTime.Now.TimeOfDay;
            TimeSpan TargetTime = Convert.ToDateTime(clsGlobal.Settings.TimeEnter).TimeOfDay;

            if ((byte)DateTime.Now.DayOfWeek == clsGlobal.Settings.Vication1
                ||
              (byte)DateTime.Now.DayOfWeek == clsGlobal.Settings.Vication2)
            {
                lbTimeTittle.Text = "يوم عطلة.😇🤗";
                lbSeconds.Text = "00";
                lbMunites.Text = "00";
                lbHours.Text = "00";
                timRemander.Stop();
            }
            else
            {
                bool notDateFound = true;
                var timesAndMessages = new List<(string query, string message, Call call)>
                {
               ("select top 1 timeEnter from ProgramSetting", "وقت متبقي لبداية اليوم",null),
               ("select top 1 LasttimeEnter from ProgramSetting", "وقت متبقي لأخذ غياب لمن لم يحضر",null),
               ("select top 1 timeLeave from ProgramSetting", "وقت متبقي لتسجيل الإنصراف",clsUtil.btAbsenceRemander_Click),
               ("select top 1 LasttimeLeave from ProgramSetting", "وقت متبقي لإغلاق اليوم",null)
                };

                foreach (var (query, message, call) in timesAndMessages)
                {
                    TargetTime = DateTime.ParseExact(clsGeneric.ReturnLastValueIWant(query), "HH:mm:ss", null).TimeOfDay;
                    if (TargetTime > DateTime.Now.TimeOfDay)
                    {
                        lbTimeTittle.Text = message;
                        notDateFound = false;
                        lbTimeTittle.Visible = true;
                        call?.Invoke();
                        break;
                    }
                }
                CurrentTime = DateTime.Now.TimeOfDay;
                if (TargetTime > CurrentTime)
                {
                    TimeSpan differentTime = TargetTime - CurrentTime;
                    hours = (sbyte)differentTime.Hours;
                    minutes = (sbyte)differentTime.Minutes;
                    seconds = (sbyte)differentTime.Seconds;
                    progTimeTrack2.Maximum = (int)differentTime.TotalSeconds;
                    progTimeTrack2.Value = 0;
                    progTimeTrack.Maximum = (int)differentTime.TotalSeconds;
                    progTimeTrack.Value = 0;
                    timRemander.Start();
                }
                else
                {
                    timRemander.Stop();
                    lbTimeTittle.Text = "تم الإنتهاء من الدراسة اليوم...😇🤗";
                    lbSeconds.Text = "00";
                    lbMunites.Text = "00";
                    lbHours.Text = "00";
                    progTimeTrack2.Value = 0;
                    progTimeTrack.Value = 0;
                }
            }

        }
        private void Main_Screan_Load(object sender, EventArgs e)
        {
            lbDayDate.Text = DateTime.Now.ToLongDateString();
            clsGlobal.Settings = clsSettings.GetSetting();
            ComputeTheCammingDate();

            ShowUserNameAndUserImage();
            timChek.Start();
            
        }
        Sendmessagefrm not = new Sendmessagefrm();
        Levels levels = new Levels();
        private void btLevels_Click(object sender, EventArgs e)
        {
            if (levels.Visible)
                levels.btRefreash_Click();
            ShowSubForm(levels);

        }
        
        private void btAdd_Users_Click(object sender, EventArgs e)
        {
            if (add_Users.Visible)
                add_Users.Refreash();

            ShowSubForm(add_Users);

        }

        Notifications notifications = new Notifications();
        TreasuryData treasury = new TreasuryData();
        TreasuryHistory treasuryHistory = new TreasuryHistory();
        TreasuryYearly treasuryYearly = new TreasuryYearly();
        private void btTreasuryData_Click_1(object sender, EventArgs e)
        {
            if(treasury.Visible)
                treasury.FillData();
            ShowSubForm(treasury);
        }
        private void btTreasuryYearly_Click(object sender, EventArgs e)
        {
            if (treasuryYearly.Visible)
                treasuryYearly.FillData();
            ShowSubForm(treasuryYearly);

        }
        private void btTreasuryHistory_Click(object sender, EventArgs e)
        {
            if (treasuryHistory.Visible)
                treasuryHistory.FillData();
            ShowSubForm(treasuryHistory);

        }

        private void btNotifications_Click_1(object sender, EventArgs e)
        {
            if (notifications.Visible)
                notifications.Notifications_Load(null, null);
            ShowSubForm(notifications);
        }


        //-------------------//

        private bool FillBrothers()
        {           
            DataTable dateOfBirthForBro = clsGeneric.ReturnGroupOfDataIWant("select BrotherInfo.DateOfBirth From BrotherInfo inner join KidsPersonalInfo on KidsPersonalInfo.Code=BrotherInfo.ChildID ");

            foreach (DataRow row in dateOfBirthForBro.Rows)
            {
                if ((DateTime.Now - Convert.ToDateTime(row["DateOfBirth"])).TotalDays >= clsGlobal.Settings.KidsBratherAge)
                {
                    return true;
                }
            }
            return false;
        }

        private bool FillSubLate()
        {
           
            if (Convert.ToByte(DateTime.Now.Day) >= clsGlobal.Settings.DaysLateToPay)
            {
                DataTable SubLate = clsGeneric.ReturnGroupOfDataIWant("select top 1 1 from SubscraitionPayment");
                if (SubLate.Rows.Count > 0)
                    return true;
            }
            return false;
        }

        private bool FillKidsAbsence()
        {
           
            DataTable KidsAbsence = clsGeneric.ReturnGroupOfDataIWant($"select top 1 K.Name,count(A.ID) as times  from AbsenceHistory A inner join KidsPersonalInfo K on A.ID = K.Code where A.DateMonthForAbsnce = {DateTime.Now.ToString("MM-yyyy")} group by K.Name  having COUNT(A.id)>={clsGlobal.Settings.DaysKindsAbsence}");

            if (KidsAbsence.Rows.Count > 0)
                return true;
        
            return false;
        }

        private bool FillBirthDay()
        {

            DataTable Birth = clsGeneric.ReturnGroupOfDataIWant($"select top 1 Code from KidsPersonalInfo where DateOfBirth like '{DateTime.Now.AddDays(-1).ToString("dd-MM")}%' or DateOfBirth like  '{DateTime.Now.ToString("dd-MM")}%' ");

            foreach (DataRow row in Birth.Rows)
            {
                return true;
            }

            return false;
        }

        private void timChek_Tick(object sender, EventArgs e)
        {
            
            TestNotifications();
            timChek.Stop();
            clsUtil.GetSubscaition();
            clsUtil.GetEmpSalary();
            clsUtil.RestMonthly();
            if (clsTreasury.ResetTreasury())
                 clsUtil.Show("تم ننقل بيانات الخزينة الي الارشيف ");

            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/AliElsaied");


        }
        
        private void Main_Screan_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (clsGlobal.Settings.PackupPath != "")
                clsSettings.BackUPDataBase(clsGlobal.Settings.PackupPath);
                   

            clsRegistersAndOperation.AddRegister(clsGlobal.CurrentUser.Code, false);


        }

        private void TestNotifications()
        {
            bool Birth = FillBirthDay();
            bool Brothers = FillBrothers();
            bool SubLate = FillSubLate();
            bool KidsAbsence = FillKidsAbsence();

            if (Birth||Brothers||SubLate||KidsAbsence)
                btNoteyfay.Visible= true;

        }

       

        private void timStopHideAndShow_Tick(object sender, EventArgs e)
        {
            timHideAndShow.Stop();
            timStopHideAndShow.Stop();
            pnHeader2.BackColor = Color.DarkTurquoise;
            lbHours.ForeColor = Color.White;
            lbMunites.ForeColor = Color.White;
            lbSeconds.ForeColor = Color.White;
            lbSeparate1.ForeColor = Color.White;
            lbSeparate2.ForeColor = Color.White;
            pnHeader2.BackColor = Color.DarkTurquoise;
            lbTimeTittle.ForeColor = Color.Black;

            
            ComputeTheCammingDate();


        }

        private void timHideAndShow_Tick(object sender, EventArgs e)
        {
            if(_Hide)
            {
                lbHours.ForeColor = Color.DarkTurquoise;
                lbMunites.ForeColor = Color.DarkTurquoise;
                lbSeconds.ForeColor = Color.DarkTurquoise;
                lbSeparate1.ForeColor = Color.DarkTurquoise;
                lbSeparate2.ForeColor = Color.DarkTurquoise;
                pnHeader2.BackColor = Color.DarkRed;
                lbTimeTittle.ForeColor = Color.DarkRed;
                _Hide = false;
            }
            else
            {
                lbHours.ForeColor = Color.White;
                lbMunites.ForeColor = Color.White;
                lbSeconds.ForeColor = Color.White;
                lbSeparate1.ForeColor = Color.White;
                lbSeparate2.ForeColor = Color.White;
                pnHeader2.BackColor = Color.DarkTurquoise;
                lbTimeTittle.ForeColor = Color.Black;

                _Hide = true;
            }
        }

        private void timRemander_Tick(object sender, EventArgs e)
        {
            progTimeTrack2.Value++;
            progTimeTrack.Value++;

            if (!(seconds == 0))
                seconds--;

            if(seconds == 0)
            {
                
                if (minutes > 0)
                   { minutes--; seconds = 59; }

            }
            if (minutes == 0)
            {
                if (hours != 0)
                    hours--;

                if (hours > 0)
                { 
                    minutes = 59; 
                    seconds = 59;
                }


            }
            if (minutes < 5 && hours == 0) 
            {
                lbHours.ForeColor = Color.DarkRed;
                lbMunites.ForeColor = Color.DarkRed;
                lbSeconds.ForeColor = Color.DarkRed;
                lbSeparate1.ForeColor = Color.DarkRed;
                lbSeparate2.ForeColor = Color.DarkRed;
            }
            lbSeconds.Text = seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();
            lbMunites.Text = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();
            lbHours.Text  = hours < 10 ? "0" + hours.ToString() : hours.ToString();
            if (hours == 0 && minutes == 0 && seconds == 0)
            {
                timRemander.Stop();               
                timHideAndShow.Start();
                timStopHideAndShow.Start();
            }
        }

    }


}
    