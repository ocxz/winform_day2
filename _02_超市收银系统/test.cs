using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace _02_超市收银系统
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            //string str = "name=张三&&pwd=123**name=李四||pwd=456||phone=123456**";
            //string name = "李四";
            //Hashtable user = new Hashtable();
            //user.Add("pwd", "123");
            //user.Add("name", "张三");
            //StringBuilder sb = new StringBuilder("**");
            //foreach (var item in user.Keys)
            //{
            //    sb.Append(item);
            //    sb.Append("=");
            //    sb.Append(user[item]);
            //    sb.Append("||");
            //}
            
        }

        private void Test(_02_超市收银系统.Gender gender)
        {
            MessageBox.Show(gender.ToString());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Test(Gender.女);
        }
    }

    public enum Gender
    {
        男,
        女
    }
}
