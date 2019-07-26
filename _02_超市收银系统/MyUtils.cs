using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace _02_超市收银系统
{
    public static class MyUtils
    {
        private static string usersInfoFile = "usersInfo.txt";

        /// <summary>
        /// 提供一个方法，获得指定文件中的所有用户信息
        /// </summary>
        /// <returns>用户信息列表</returns>
        public static List<Hashtable> GetUsersInfo()
        {
            List<Hashtable> userInfos = new List<Hashtable>();   // 用来存储用户信息

            if (!Directory.Exists(usersInfoFile))  // 文件不存在，直接返回空
            {
                return null;
            }
            using (FileStream fsRead = new FileStream(usersInfoFile, FileMode.OpenOrCreate, FileAccess.Read))
            {
                byte[] buffer = new byte[fsRead.Length];   // 所有用户信息字节码数组
                fsRead.Read(buffer, 0, buffer.Length);
                string usersinfo = Encoding.Default.GetString(buffer).Trim();   // 所有用户信息字符串

                // 用户信息字符数组，一条表示一个用户信息 如：name=张三&&pwd=123456&&phone=*******
                string[] userinfo = usersinfo.Split(new string[] { "**" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < userinfo.Length; i++)
                {
                    Hashtable user = new Hashtable();
                    // 循环个人信息
                    string[] info = userinfo[i].Split(new String[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < userinfo.Length; j++)
                    {
                        string[] infos = info[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                        user.Add(infos[0], infos[1]);
                    }
                    userInfos.Add(user);

                }
            }
            return userInfos;
        }

        /// <summary>
        /// 根据用户指定的用户名，获得用户信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Hashtable GetUserInfo(string name)
        {
            if (!Directory.Exists(usersInfoFile))
            {
                return null;
            }
            else
            {
                using (FileStream fsRead = new FileStream(usersInfoFile, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[fsRead.Length];
                    fsRead.Read(buffer, 0, buffer.Length);
                    string usersInfo = Encoding.Default.GetString(buffer).Trim();
                    if (usersInfo.Contains("name=" + name))
                    {
                        Hashtable user = new Hashtable();
                        string userInfo = usersInfo.Substring(usersInfo.IndexOf("name=" + name)).Split(new String[] { "**" }, StringSplitOptions.RemoveEmptyEntries)[0];
                        string[] info = usersInfo.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < info.Length; i++)
                        {
                            string[] infos = info[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                            user.Add(info[0], info[1]);
                        }
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public static void AddUserInfo(Hashtable user)
        {
            foreach (var item in user.Keys)
            {

            }
        }
    }


    public static class MyData
    {
        private static Hashtable allStudent = new Hashtable();
        private static Hashtable allTeacher = new Hashtable();
        private static Hashtable allAdmin = new Hashtable();
        private static Dictionary<string, string[]> courseInfo = new Dictionary<string, string[]>();

        private static Hashtable allClassesInfo = new Hashtable();

        /// <summary>
        /// 根据学生学号，获得学生对象
        /// </summary>
        /// <param name="stuID">学生ID，字符串类型</param>
        /// <returns>学生对象</returns>
        public static Student GetStudent(string stuID)
        {
            return allStudent.ContainsKey(stuID) ? (Student)allStudent[stuID] : null;
        }

        /// <summary>
        /// 根据学生学号、学生对象添加学生，判断是否已存在，若已存在则添加失败，返回false
        /// </summary>
        /// <param name="stuID">学生ID，字符串类型</param>
        /// <param name="stu">学生对象</param>
        /// <returns>添加信息 成功或失败</returns>
        public static bool AddStudent(string stuID, Student stu)
        {
            if (allStudent.ContainsKey(stuID))
            {
                return false;
            }
            else
            {
                allStudent.Add(stuID, stu);
                return true;
            }
        }

        /// <summary>
        /// 根据老师编号，获得老师对象
        /// </summary>
        /// <param name="TeaID">老师编号</param>
        /// <returns>老师对象</returns>
        public static Teacher GetTeacher(string teaID)
        {
            return allTeacher.ContainsKey(teaID) ? (Teacher)allTeacher[teaID] : null;
        }

        /// <summary>
        /// 根据老师编号、添加学生对象，判断是否已存在，若已存在则添加失败，返回false
        /// </summary>
        /// <param name="stuID">学生ID，字符串类型</param>
        /// <param name="stu">学生对象</param>
        /// <returns>添加信息 成功或失败</returns>
        public static bool AddTeacher(string teaID, Teacher tea)
        {
            if (allTeacher.ContainsKey(teaID))
            {
                return false;
            }
            else
            {
                allTeacher.Add(teaID, tea);
                return true;
            }
        }

        /// <summary>
        /// 根据管理员编号，添加管理员对象
        /// </summary>
        /// <param name="adminID"></param>
        /// <returns></returns>
        public static Admin GetAdmin(string adminID)
        {
            return allAdmin.ContainsKey(adminID) ? (Admin)allAdmin[adminID] : null;
        }

        /// <summary>
        /// 根据管理员编号、添加管理员对象，判断是否已存在，若已存在则添加失败，返回false
        /// </summary>
        /// <param name="adminID">管理员编号</param>
        /// <param name="admin">管理员对象</param>
        /// <returns>添加信息成功或失败</returns>
        public static bool AddAdmin(string adminID, Admin admin)
        {
            if (allAdmin.ContainsKey(adminID))
            {
                return false;
            }
            else
            {
                allAdmin.Add(adminID, admin);
                return true;
            }
        }

        /// <summary>
        /// 根据类别 学生1、老师2、管理员3，根据id找人
        /// </summary>
        /// <param name="category">类别：学生1、老师2、管理员3</param>
        /// <param name="id">要找的id</param>
        /// <returns>返回的结果</returns>
        public static Object GetManFormCate(int category, string id)
        {
            switch (category)
            {
                case 1:
                    return GetStudent(id);
                case 2:
                    return GetTeacher(id);
                case 3:
                    return GetAdmin(id);
                default:
                    return null;
            }
        }

        /// <summary>
        /// 根据类别 添加对象
        /// </summary>
        /// <param name="category">类别：学生1、老师2、管理员3</param>
        /// <param name="id">要添加对象的id</param>
        /// <param name="man">要添加的对象</param>
        /// <returns>添加的结果</returns>
        public static bool AddManOfCate(int category, string id, Object man)
        {
            switch (category)
            {
                case 1:
                    return AddStudent(id, (Student)man);
                case 2:
                    return AddTeacher(id, (Teacher)man);
                case 3:
                    return AddAdmin(id, (Admin)man);
                default:
                    return false;
            }
        }

        /// <summary>
        /// 根据学院名，获得所有班级信息
        /// </summary>
        /// <param name="collegeName">学院名</param>
        /// <returns>班级信息列表</returns>
        public static List<string> GetClasses(string collegeName)
        {
            return allClassesInfo.ContainsKey(collegeName) ? (List<string>)allClassesInfo[collegeName] : null;
        }

        /// <summary>
        /// 获得所有学院名
        /// </summary>
        /// <returns></returns>
        public static string[] GetAllCollegeName()
        {
            if (allClassesInfo.Count == 0)
            {
                return null;
            }
            else
            {
                string[] names = new string[allClassesInfo.Count];
                foreach (var item in allClassesInfo.Keys)
                {
                    int i = 0;
                    names[i] = item.ToString();
                    i++;
                }
                return names;
            }
        }

        /// <summary>
        /// 根据学院名，和班级列表，将信息添加
        /// </summary>
        /// <param name="collegeName">学院名</param>
        /// <param name="classes">班级列表</param>
        /// <returns>添加信息，成功与否</returns>
        public static bool AddClassesInfo(string collegeName, List<string> classes)
        {
            if (allClassesInfo.ContainsKey(collegeName))
            {
                return false;
            }
            else
            {
                allClassesInfo.Add(collegeName, classes);
                return true;
            }
        }

        /// <summary>
        /// 根据验证器类别，得到验证器
        /// </summary>
        /// <param name="keep"></param>
        /// <returns></returns>
        public static Verifier GetVerifier(_02_超市收银系统.VerifierKeep keep)
        {
            switch (keep.ToString())
            {
                case "Email":
                    return EmailVerifier.GetVerifier();
                case "Phone":
                    return PhoneVerifer.GetVerifer();
                case "Name":
                    return NameVerifer.GetVerifer();
                default:
                    return null;
            }
        }

        /// <summary>
        /// 判断手机号，是否已被注册
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool PhoneIsExist(string phone)
        {
            foreach (var item in allStudent.Values)
            {
                Person person = (Person)item;
                if (phone.Trim() == person.Telphone)
                {
                    return true;
                }
            }
            foreach (var item in allTeacher.Values)
            {
                Person person = (Person)item;
                if (phone.Trim() == person.Telphone)
                {
                    return true;
                }
            }
            foreach (var item in allAdmin.Values)
            {
                Person person = (Person)item;
                if (phone.Trim() == person.Telphone)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断邮箱是否已被注册
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool EmailIsExist(string phone)
        {
            foreach (var item in allStudent.Values)
            {
                Person person = (Person)item;
                if (phone.Trim() == person.Email)
                {
                    return true;
                }
            }
            foreach (var item in allTeacher.Values)
            {
                Person person = (Person)item;
                if (phone.Trim() == person.Email)
                {
                    return true;
                }
            }
            foreach (var item in allAdmin.Values)
            {
                Person person = (Person)item;
                if (phone.Trim() == person.Email)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 学院数据加载
        /// </summary>
        /// <returns>加载后的数据</returns>
        public static Dictionary<string, Dictionary<string, List<string>>> LoadData()
        {
            Dictionary<string, Dictionary<string, List<string>>> colleges = new Dictionary<string, Dictionary<string, List<string>>>();

            string path = @"C:\Users\sowhat\Desktop\学院统计.txt";
            string[] infos = File.ReadAllLines(path, Encoding.UTF8);
            for (int i = 0; i < infos.Length; i++)
            {
                if (infos[i].Length == 0)
                {
                    continue;
                }
                string collegeName = infos[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];
                string majorName = infos[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
                string courseName = infos[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2];

                if (colleges.ContainsKey(collegeName))  // 学院已经存在了
                {
                    if (colleges[collegeName].ContainsKey(majorName))   // 专业也存在了
                    {
                        if (colleges[collegeName][majorName].Contains(courseName))   // 课程也存在了
                        {
                            continue;
                        }
                        else    // 课程不存在，添加课程
                        {
                            colleges[collegeName][majorName].Add(courseName);
                        }
                    }
                    else    // 专业不存在  得新增 专业 和课程列表
                    {
                        List<string> courses = new List<string>();
                        courses.Add(courseName);
                        colleges[collegeName].Add(majorName, courses);
                    }
                }
                else    // 学院都不存在  先搞专业，在讲专业加到学院中
                {
                    List<string> courses = new List<string>();
                    Dictionary<string, List<string>> majors = new Dictionary<string, List<string>>();
                    courses.Add(courseName);
                    majors.Add(majorName, courses);
                    colleges.Add(collegeName, majors);

                }

            }
            return colleges;
        }

        /// <summary>
        /// 根据班级名，得到课表
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public static string[] GetCouseInfo(string className)
        {
            try
            {
                return courseInfo[className];
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// 根据班级名，设置课程名，已存在，则替换
        /// </summary>
        /// <param name="className"></param>
        /// <param name="couseInfo"></param>
        public static void SetCouseInfo(string className, string[] ToaddCouseInfo)
        {
            if (courseInfo.ContainsKey(className))   // 课表已存在，删除替换
            {
                courseInfo.Remove(className);
            }

            courseInfo.Add(className, ToaddCouseInfo);
        }
    }

    #region 一些POJO类
    /// <summary>
    /// 简单的个人信息类，包括姓名、年龄、性别、电话号码、电子邮箱
    /// </summary>
    public class Person
    {
        public string UID
        {
            set;
            get;
        }
        public string UPwd
        {
            set;
            get;
        }
        public string Name
        {
            set;
            get;
        }
        public String Birthday
        {
            set;
            get;
        }
        public char Gender
        {
            set;
            get;
        }
        public string Telphone
        {
            set;
            get;
        }
        public string Email
        {
            set;
            get;
        }

        public Person() { }
        public Person(string id, string pwd, string name, string birthday, char gender)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Gender = gender;
            this.UID = id;
            this.UPwd = pwd;
        }
        public Person(string id, string pwd, string name, string birthday, char gender, string phone, string email) : this(id, pwd, name, birthday, gender)
        {
            this.Telphone = phone;
            this.Email = email;
        }
    }

    /// <summary>
    /// 简单的学生类，包括姓名、性别、年龄、电话号码、电子邮箱、学院、班级、成绩
    /// </summary>
    public sealed class Student : Person
    {
        public string Class
        {
            set;
            get;
        }
        public string College
        {
            set;
            get;
        }

        public string Major
        {
            set;
            get;
        }

        public int Score
        {
            set;
            get;
        }

        public Student() { }
        public Student(string sid, string spwd, string name, string birthday, char gender) : base(sid, spwd, name, birthday, gender) { }
        public Student(string sid, string spwd, string name, string birthday, char gender, string phone, string email)
            : base(sid, spwd, name, birthday, gender, phone, email) { }

        public Student(string sid, string spwd, string name, string birthday, char gender, string phone, string email, string college, string major, string classes)
    : base(sid, spwd, name, birthday, gender, phone, email)
        {
            this.College = college;
            this.Class = classes;
            this.Major = major;
        }
    }

    /// <summary>
    /// 简单的老师类 包括姓名、性别、年龄、电话号码、电子邮箱、学院、班级
    /// </summary>
    public sealed class Teacher : Person
    {
        public string Class
        {
            set;
            get;
        }
        public string College
        {
            set;
            get;
        }
        public Teacher() { }
        public Teacher(string tid, string tpwd, string name, string birthday, char gender) : base(tid, tpwd, name, birthday, gender) { }
        public Teacher(string tid, string tpwd, string name, string birthday, char gender, string phone, string email)
            : base(tid, tpwd, name, birthday, gender, phone, email) { }
    }

    /// <summary>
    /// 简单的管理员类 包括姓名、年龄、性别、电话号码、电子邮箱
    /// </summary>
    public sealed class Admin : Person
    {
        public Admin() { }
        public Admin(string aid, string apwd, string name, string birthday, char gender)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Gender = gender;
            this.UPwd = aid;
            this.UPwd = apwd;
        }
        public Admin(string aid, string apwd, string name, string birthday, char gender, string phone, string email) : this(aid, apwd, name, birthday, gender)
        {
            this.Telphone = phone;
            this.Email = email;
        }
    }

    /// <summary>
    /// 学院类，用来存放学院相关信息
    /// </summary>
    public sealed class College
    {
        public string CoId
        {
            set;
            get;
        }
        public string CoName
        {
            set;
            get;
        }

        /// <summary>
        /// 存放专业ID
        /// </summary>
        public List<string> MajorId
        {
            set;
            get;
        }

    }

    /// <summary>
    /// 专业类
    /// </summary>
    public sealed class Major
    {
        public string MajorId
        {
            set;
            get;
        }

        public string MajorName
        {
            set;
            get;
        }

        public List<string> ClassesId
        {
            set;
            get;
        }

        public List<string> CourseId
        {
            set;
            get;
        }

    }

    /// <summary>
    /// 班级类
    /// </summary>
    public sealed class Class
    {
        public string ClassId
        {
            set;
            get;
        }

        public string ClassName
        {
            set;
            get;
        }

        public List<string> StuId
        {
            set;
            get;
        }

        public List<string> TeaId
        {
            set;
            get;
        }
    }

    /// <summary>
    /// 课程类
    /// </summary>
    public sealed class Course
    {
        public string CourseId
        {
            set;
            get;
        }
        public string CourseName
        {
            set;
            get;
        }
    }

    /// <summary>
    /// 课表类
    /// </summary>
    public sealed class Schedule
    {
        public string ScheduleId
        {
            set;
            get;
        }

        public List<string[]> Scourses
        {
            set;
            get;
        }

    }
    #endregion

    #region 验证器

    public enum VerifierKeep
    {
        Email,
        Phone,
        Name,
    }


    /// <summary>
    /// 验证器接口
    /// </summary>
    public interface Verifier
    {
        bool IsValidity(string str);
    }

    /// <summary>
    /// 邮箱验证器
    /// </summary>
    public sealed class EmailVerifier : Verifier
    {
        private static EmailVerifier verifier;
        private EmailVerifier() { }
        public static EmailVerifier GetVerifier()
        {
            if (verifier == null)
            {
                verifier = new EmailVerifier();
            }
            return verifier;
        }
        bool Verifier.IsValidity(string str)
        {
            if (string.IsNullOrEmpty(str.Trim()))   // 如果要验证的为空串
            {
                return false;
            }
            else
            {
                string exp = @"^[A-Za-z0-9\u4e00-\u9fa5]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$";
                return Regex.IsMatch(str, exp);
            }
        }
    }

    /// <summary>
    /// 手机号码验证器
    /// </summary>
    public sealed class PhoneVerifer : Verifier
    {
        private static PhoneVerifer verifer;
        private PhoneVerifer() { }
        public static PhoneVerifer GetVerifer()
        {
            if (verifer == null)
            {
                verifer = new PhoneVerifer();
            }
            return verifer;
        }

        bool Verifier.IsValidity(string str)
        {
            if (string.IsNullOrEmpty(str.Trim()))
            {
                return false;
            }
            // 号码匹配正则式
            string exp = @"^1([38][0-9]|4[579]|5[0-3,5-9]|6[6]|7[0135678]|9[89])\d{8}$";
            return Regex.IsMatch(str.Trim(), exp) && str.Length == 11;
        }
    }

    /// <summary>
    /// 用户姓名验证器
    /// </summary>
    public sealed class NameVerifer : Verifier
    {
        private static NameVerifer verifer;
        private NameVerifer() { }
        public static NameVerifer GetVerifer()
        {
            if (verifer == null)
            {
                verifer = new NameVerifer();
            }
            return verifer;
        }

        bool Verifier.IsValidity(string str)
        {
            if (string.IsNullOrEmpty(str.Trim()))
            {
                return false;
            }
            else if (Regex.IsMatch(str.Trim(), @"^[\u4e00-\u9fa5 ]{2,20}$"))
            {
                return true;
            }
            else if (Regex.IsMatch(str.Trim(), @"^[\u4e00-\u9fa5 ]{2,20}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    #endregion
}
