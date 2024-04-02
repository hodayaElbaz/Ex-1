using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientTestServer.QueryServer1;
using System.Windows.Forms;

namespace ClientTestServer
{
    public partial class FormAllMembers : Form
    {

        GetMemberExaminationResponse _res;
        public FormAllMembers()
        {
            InitializeComponent();
        }

        //הבאת כל החברים
        private void bttnGetAllMembers_Click(object sender, EventArgs e)
        {
            WebService _proxy = new QueryServer1.WebService();
            GetMemberParameter _param = new GetMemberParameter();
            //List<ClassMember> _list = _proxy.ReadMembers(_param).listMembers.ToList();
            GetMembersResponse _res = _proxy.ReadMembers(_param);
            if (_res.systemErrors != null && _res.systemErrors.Count() > 0)
            {
                MessageBox.Show(_res.systemErrors[0]);
            }
            else
            {
                classMemberBindingSource.DataSource = _res.listMembers;
                radGridView1_CellClick(this, null);
            }
        }

        private void btnGetExamination_Click(object sender, EventArgs e)
        {
           int _memberID =  ((ClassMember)classMemberBindingSource.DataSource).memberID;
            if (_memberID != 0)
            {
                WebService _proxy = new QueryServer1.WebService();
                GetMemberExaminationParameter _param = new GetMemberExaminationParameter();
                _param.memberID = _memberID;

                GetMemberExaminationResponse _res = _proxy.ReadAllMemberExaminations(_param);
                if (_res.systemErrors != null && _res.systemErrors.Count() > 0)
                {
                    MessageBox.Show(_res.systemErrors[0]);
                }
                else
                classMemberBindingSource.DataSource = _res.listMemberExaminations;
            }
        }

        private void radGridView1_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //אם נלחץ על ריק
            if (classMemberBindingSource.Current == null) return;

            //מזהה חבר, ע"פ מה שנלחץ ע"י המשתמש
            int _memberID = ((ClassMember)classMemberBindingSource.Current).memberID;
            //אם שונה מ-0,כלומר לא שורה ריקה
            if (_memberID != 0)
            {
                textBox1.Text = " תוצאות בדיקות לחבר " + _memberID.ToString();
                WebService _proxy = new QueryServer1.WebService();
                GetMemberExaminationParameter _param = new GetMemberExaminationParameter();
                _param.memberID = _memberID;

                //קריאת כל פרטי הבדיקות של אותו חבר
                 _res = _proxy.ReadAllMemberExaminations(_param);
                if (_res.systemErrors != null && _res.systemErrors.Count() > 0)
                {
                    MessageBox.Show(_res.systemErrors[0]);
                }
                else
                    //הצגה של פרטי הבדיקות של אות חבר
                    classExaminationBindingSource.DataSource = _res.listMemberExaminations;
            }
        }

        private void FormAllMembers_Load(object sender, EventArgs e)
        {
           
        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCreat_Click(object sender, EventArgs e)
        {
            if(_res.listMemberExaminations.Count()>=4)
            {
                MessageBox.Show("לא ניתן להוסיף מעבר ל-4 בדיקות");

            }
        }
    }
}
