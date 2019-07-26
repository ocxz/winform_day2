using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace TestReadCVS
{
    class Program
    {
        static void Main(string[] args)
        {


            Dictionary<string, Dictionary<string, List<string>>>  LoadData()
            {
                Dictionary<string, Dictionary<string, List<string>>> colleges = new Dictionary<string, Dictionary<string, List<string>>>();

                string path = @"C:\Users\sowhat\Desktop\学院统计.txt";
                string[] infos = File.ReadAllLines(path, Encoding.UTF8);
                for (int i = 0; i < infos.Length; i++)
                {
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


            foreach (var item in LoadData()["信息工程学院"]["计算机科学与技术"])
            {
                Console.WriteLine(item);
            }




            //Dictionary<string, Dictionary<string, List<string>>> colleges = new Dictionary<string, Dictionary<string, List<string>>>();

            //Dictionary<string, List<string>> majors = new Dictionary<string, List<string>>();


            //List<string> course1 = new List<string>();   // 所有的课程
            //List<string> course2 = new List<string>();   // 所有的课程

            //course1.Add("计算机1班");
            //course1.Add("计算机2班");
            //course1.Add("计算机3班");

            //course2.Add("信安1班");
            //course2.Add("信安2班");
            //course2.Add("信安3班");

            //majors.Add("计算机科学与技术", course1);
            //majors.Add("信息安全", course2);

            //colleges.Add("信息工程学院", majors);
            //colleges.Add("信息工程学院", majors);

            //foreach (var item in colleges["信息工程学院"]["计算机科学与技术"])
            //{
            //    Console.WriteLine(item);
            //}

            #region MyRegion
            //Hashtable colleges = new Hashtable();

            //string path = @"C:\Users\sowhat\Desktop\学院统计.txt";
            //string[] text = File.ReadAllLines(path,Encoding.UTF8);
            //// 0 学院 1专业 2班级
            //// 结果  {学院：{专业：[课1，课2，课3]}}
            //for (int i = 0; i < text.Length; i++)
            //{
            //    string[] infos = text[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            //    if (colleges.ContainsKey(infos[0]))    // 学院存在
            //    {
            //        #region MyRegion
            //        Hashtable major = (Hashtable)colleges[infos[1]];   // 取出专业
            //        if (major.ContainsKey(infos[1]))   // 判断专业是否存在,取出课程
            //        {
            //            ArrayList Courses = (ArrayList)major[infos[1]];
            //            if (Courses.Contains(infos[2]))   // 课程已存在
            //            {
            //                return;
            //            }
            //            else   // 课程不存在  专业存在
            //            {
            //                Courses.Add(infos[2]);
            //            }
            //        }
            //        else   // 专业不存在
            //        {
            //            ArrayList Courses = new ArrayList();
            //            Courses.Add(infos[2]);
            //            major.Add(infos[1], Courses);
            //        }
            //        #endregion
            //    }
            //    else   // 学院不存在
            //    {
            //        Hashtable major = new Hashtable();
            //        ArrayList Courses = new ArrayList();
            //        Courses.Add(infos[2]);
            //        major.Add(infos[1], Courses);
            //        colleges.Add(infos[0],major);
            //    }
            //} 
            #endregion
            Console.ReadKey();
        }
    }
}
