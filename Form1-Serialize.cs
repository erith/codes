using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var member = new Member();
            member.Name = "erith";
            member.Gender = Gender.Male;
            var serialize = JsonConvert.SerializeObject(member);
            var oMember = JsonConvert.DeserializeObject(serialize, typeof(Member)) as Member;
        }
    }

    [Serializable]
    public class Member : ISerializable
    {
        public string Name;
        public object Gender;

        public Member() { }


        public Member(SerializationInfo info, StreamingContext context)
        {
            var typeListJSON = info.GetString("TYPE_LIST__");
            var typeList = JsonConvert.DeserializeObject<Dictionary<string, string>>(typeListJSON);

            var fields = this.GetType().GetFields();
            foreach(var f in fields)
            {
                if (f.Name == "TYPE_LIST__") continue;
                if (typeList.Keys.Contains(f.Name))
                {
                    var typeInfo = typeList[f.Name].Split(':');                    
                    var valueType = Type.GetType(typeInfo[0]);                    
                    f.SetValue(this, info.GetValue(f.Name, valueType));
                }                
                else
                {
                    f.SetValue(this, info.GetValue(f.Name, f.FieldType));
                }
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Dictionary<string, string> typeInfo = new Dictionary<string, string>();
            var fields = this.GetType().GetFields();
            foreach (var f in fields)
            {
                Type memberType = f.GetValue(this).GetType();
                info.AddValue(f.Name, f.GetValue(this), memberType);
                typeInfo.Add(f.Name, memberType.FullName+":"+memberType.Assembly.FullName);
            }
            info.AddValue("TYPE_LIST__", JsonConvert.SerializeObject(typeInfo));
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
