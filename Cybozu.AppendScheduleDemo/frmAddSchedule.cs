using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cybozu.AppendScheduleDemo.Model;
using CBLabs.CybozuConnect;

namespace Cybozu.AppendScheduleDemo
{
    public partial class frmAddSchedule : Form
    {

        List<ComboBoxCustomItem> startHours;
        List<ComboBoxCustomItem> startMins;
        List<ComboBoxCustomItem> endHours;
        List<ComboBoxCustomItem> endMins;
        List<ComboBoxCustomItem> plans;
        List<ComboBoxCustomItem> selectedMembers;
        List<ComboBoxCustomItem> members;


        public frmAddSchedule()
        {
            InitializeComponent();
        }

        private void btnAppend_Click(object sender, EventArgs e)
        {
            try
            {
                if (InputCheck())
                {
                    Schedule s = new Schedule(ApplicationCache.CybozuApp);
                    ScheduleEvent se = CreateScheduleEvent();
                    if (PlanTimeCheckAfterCreateScheduleEvent(se))
                    {
                        ScheduleEvent result = s.AddEvent(se);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void cbStartHour_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var startHourSelectedItem = (ComboBoxCustomItem)cbStartHour.SelectedItem;
            var startMinSelectedItem = (ComboBoxCustomItem)cbStartMin.SelectedItem;

            if (startHourSelectedItem.Value != string.Empty && startMinSelectedItem.Value == string.Empty)
            {
                cbStartMin.SelectedIndex = 1;
            }

            if (startHourSelectedItem.Value == string.Empty && startMinSelectedItem.Value != string.Empty)
            {
                cbStartMin.SelectedIndex = 0;
            }
        }

        private void cbEndHour_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var endHourSelectedItem = (ComboBoxCustomItem)cbEndHour.SelectedItem;
            var endMinSelectedItem = (ComboBoxCustomItem)cbEndMin.SelectedItem;

            if (endHourSelectedItem.Value != string.Empty && endMinSelectedItem.Value == string.Empty)
            {
                cbEndMin.SelectedIndex = 1;
            }

            if (endHourSelectedItem.Value == string.Empty && endMinSelectedItem.Value != string.Empty)
            {
                cbEndMin.SelectedIndex = 0;
            }
        }

        private void btnSelectMember_Click(object sender, EventArgs e)
        {
            if (lbConditionsMembers.SelectedItem != null)
            {
                ComboBoxCustomItem selectedItem = (ComboBoxCustomItem)lbConditionsMembers.SelectedItem;
                if (!selectedMembers.Contains(selectedItem))
                {
                    selectedMembers.Add(selectedItem);
                    selectedMembersBS.ResetBindings(true);


                }
            }
        }

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            if (lbMembers.SelectedItem != null)
            {
                var selectedItem = (ComboBoxCustomItem)lbMembers.SelectedItem;
                selectedMembers.Remove(selectedItem);
                selectedMembersBS.ResetBindings(true);
            }
        }

        private void frmAddSchedule_Load(object sender, EventArgs e)
        {
            #region 時刻
            //時刻リスト設定
            startHours = new List<ComboBoxCustomItem>();
            startHours.Add(new ComboBoxCustomItem("", "--時"));
            startHours.Add(new ComboBoxCustomItem("0", "0時"));
            startHours.Add(new ComboBoxCustomItem("1", "1時"));
            startHours.Add(new ComboBoxCustomItem("2", "2時"));
            startHours.Add(new ComboBoxCustomItem("3", "3時"));
            startHours.Add(new ComboBoxCustomItem("4", "4時"));
            startHours.Add(new ComboBoxCustomItem("5", "5時"));
            startHours.Add(new ComboBoxCustomItem("6", "6時"));
            startHours.Add(new ComboBoxCustomItem("7", "7時"));
            startHours.Add(new ComboBoxCustomItem("8", "8時"));
            startHours.Add(new ComboBoxCustomItem("9", "9時"));
            startHours.Add(new ComboBoxCustomItem("10", "10時"));
            startHours.Add(new ComboBoxCustomItem("11", "11時"));
            startHours.Add(new ComboBoxCustomItem("12", "12時"));
            startHours.Add(new ComboBoxCustomItem("13", "13時"));
            startHours.Add(new ComboBoxCustomItem("14", "14時"));
            startHours.Add(new ComboBoxCustomItem("15", "15時"));
            startHours.Add(new ComboBoxCustomItem("16", "16時"));
            startHours.Add(new ComboBoxCustomItem("17", "17時"));
            startHours.Add(new ComboBoxCustomItem("18", "18時"));
            startHours.Add(new ComboBoxCustomItem("19", "19時"));
            startHours.Add(new ComboBoxCustomItem("20", "20時"));
            startHours.Add(new ComboBoxCustomItem("21", "21時"));
            startHours.Add(new ComboBoxCustomItem("22", "22時"));
            startHours.Add(new ComboBoxCustomItem("23", "23時"));
            startHours.Add(new ComboBoxCustomItem("24", "24時"));

            endHours = new List<ComboBoxCustomItem>(startHours);

            startMins = new List<ComboBoxCustomItem>();
            startMins.Add(new ComboBoxCustomItem("", "--分"));
            startMins.Add(new ComboBoxCustomItem("0", "00分"));
            startMins.Add(new ComboBoxCustomItem("10", "10分"));
            startMins.Add(new ComboBoxCustomItem("20", "20分"));
            startMins.Add(new ComboBoxCustomItem("30", "30分"));
            startMins.Add(new ComboBoxCustomItem("40", "40分"));
            startMins.Add(new ComboBoxCustomItem("50", "50分"));

            endMins = new List<ComboBoxCustomItem>(startMins);

            cbStartHour.DataSource = startHours;
            cbStartMin.DataSource = startMins;

            cbEndHour.DataSource = endHours;
            cbEndMin.DataSource = endMins;
            #endregion

            #region 予定
            plans = new List<ComboBoxCustomItem>();
            plans.Add(new ComboBoxCustomItem("", "--"));
            plans.Add(new ComboBoxCustomItem("出張", "出張"));
            plans.Add(new ComboBoxCustomItem("往訪", "往訪"));
            plans.Add(new ComboBoxCustomItem("来訪", "来訪"));
            plans.Add(new ComboBoxCustomItem("会議", "会議"));
            plans.Add(new ComboBoxCustomItem("休み", "休み"));
            plans.Add(new ComboBoxCustomItem("本社", "本社"));
            plans.Add(new ComboBoxCustomItem("潮来第一", "潮来第一"));
            plans.Add(new ComboBoxCustomItem("潮来第二", "潮来第二"));
            plans.Add(new ComboBoxCustomItem("潮来第三", "潮来第三"));
            plans.Add(new ComboBoxCustomItem("稲敷", "稲敷"));
            plans.Add(new ComboBoxCustomItem("草加", "草加"));
            plans.Add(new ComboBoxCustomItem("大阪", "大阪"));
            plans.Add(new ComboBoxCustomItem("名古屋", "名古屋"));
            plans.Add(new ComboBoxCustomItem("静岡", "静岡"));

            cbPlan.DataSource = plans;

            #endregion

            #region 参加者
            selectedMembers = new List<ComboBoxCustomItem>();
            selectedMembers.Add(new ComboBoxCustomItem(ApplicationCache.CybozuApp.User.ID, ApplicationCache.CybozuApp.User.Name));

            selectedMembersBS.DataSource = selectedMembers;

            lbMembers.DataSource = selectedMembersBS;

            members = new List<ComboBoxCustomItem>();
            members.Add(new ComboBoxCustomItem("5356", "永吉　研二"));
            members.Add(new ComboBoxCustomItem("6552", "山田　雄大"));
            members.Add(new ComboBoxCustomItem("10928", "林　聖洋"));
            members.Add(new ComboBoxCustomItem("11147", "早乙女　祥之"));
            members.Add(new ComboBoxCustomItem("10435", "王　天義"));

            lbConditionsMembers.DataSource = members;

            #endregion

        }
        private ScheduleEvent CreateScheduleEvent()
        {
            ScheduleEvent se = new ScheduleEvent();

            se.EventType = ScheduleEventType.Normal;
            se.PublicType = SchedulePublicType.Public;

            #region ScheduleEvent.Start, ScheduleEvent.End, ScheduleEvent.AllDay, ScheduleEvent.StartOnly
            var startHourSelectedItem = (ComboBoxCustomItem)cbStartHour.SelectedItem;
            var startMinSelectedItem = (ComboBoxCustomItem)cbStartMin.SelectedItem;
            var endHourSelectedItem = (ComboBoxCustomItem)cbEndHour.SelectedItem;
            var endMinSelectedItem = (ComboBoxCustomItem)cbEndMin.SelectedItem;

            if (startHourSelectedItem.Value == string.Empty)
            {
                if (endHourSelectedItem.Value == string.Empty)
                {
                    se.AllDay = true;
                }
            }
            else
            {
                if (endHourSelectedItem.Value == string.Empty)
                {
                    se.StartOnly = true;
                }

                string startMinSelected = startMinSelectedItem.Value;
                if (startMinSelected == string.Empty)
                {
                    startMinSelected = "0";
                }

                se.Start = new DateTime(dtScheduleDate.Value.Year,
                        dtScheduleDate.Value.Month,
                        dtScheduleDate.Value.Day,
                        int.Parse(startHourSelectedItem.Value),
                        int.Parse(startMinSelected), 0);
            }


            if (endHourSelectedItem.Value != string.Empty)
            {
                string endMinSelected = endMinSelectedItem.Value;
                if (endMinSelected == string.Empty)
                {
                    endMinSelected = "0";
                }

                se.End = new DateTime(dtScheduleDate.Value.Year,
                        dtScheduleDate.Value.Month,
                        dtScheduleDate.Value.Day,
                        int.Parse(endHourSelectedItem.Value),
                        int.Parse(endMinSelected), 0);
            }

            if (se.AllDay) {
                se.Start = new DateTime(dtScheduleDate.Value.Year,
                        dtScheduleDate.Value.Month,
                        dtScheduleDate.Value.Day);

                se.End = se.Start;
            }
            #endregion

            #region ScheduleEvent.Plan
            var planSelectedItem = (ComboBoxCustomItem)cbPlan.SelectedItem;
            se.Plan = planSelectedItem.Value;
            #endregion

            #region ScheduleEvent.Detail
            se.Detail = txtDetail.Text;
            #endregion

            #region ScheduleEvent.Description
            se.Description = txtDescription.Text;
            #endregion

            #region ScheduleEvent.Members
            foreach (ComboBoxCustomItem user in lbMembers.Items)
                se.UserIds.Add(user.Value);
            #endregion

            return se;
        }

        private bool InputCheck()
        {

            var startHourSelectedItem = (ComboBoxCustomItem)cbStartHour.SelectedItem;
            var endHourSelectedItem = (ComboBoxCustomItem)cbEndHour.SelectedItem;

            if (startHourSelectedItem.Value == string.Empty && endHourSelectedItem.Value != string.Empty)
            {
                MessageBox.Show("開始時刻が入力されていません。");
                return false;

            }


            if (lbMembers.Items.Count == 0)
            {
                MessageBox.Show("参加者が選択されていません。");
                return false;
            }


            return true;
        }

        private bool PlanTimeCheckAfterCreateScheduleEvent(ScheduleEvent se)
        {
            if (!se.StartOnly&&se.Start > se.End) {
                MessageBox.Show("開始時刻が不正です。");
                return false;
            }
            return true;
        }

 
    }
}
