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

namespace ClientTestServer
{
    public partial class FormAllMembers : Form
    {
        public FormAllMembers()
        {
            InitializeComponent();
        }

        private void bttnGetAllMembers_Click(object sender, EventArgs e)
        {
            WebService _proxy = new QueryServer1.WebService();
            GetMemberParameter _param = new GetMemberParameter();
            List<ClassMember> _list = _proxy.ReadMembers(_param).listMembers.ToList();
            classMemberBindingSource.DataSource = _list;
        }
    }
}
