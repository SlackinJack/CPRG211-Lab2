using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Employee {
    class Program {
        static void Main(string[] args) {
            int i = 0;          

            // 4b
            double avgWeekly = 0;

            // 4d
            double lowestWeeklySalary = Int32.MaxValue;
            string lowestWeeklySalaryName = "";

            // 4c
            double highestWeeklyWage = Int32.MinValue;
            string highestWeeklyWageName = "";

            // 4e
            Dictionary<string, int> depts = new Dictionary<string, int>();


            // 4a
            string filePath = "res/employees.txt";
            string[] lines = File.ReadAllLines(filePath);
            List<Employee> l = new List<Employee>();
            while (i < lines.Length) {
                string[] f = lines[i].Split(':');
                string theDept = f[6];
                if (depts.ContainsKey(theDept)) {
                    depts[theDept] = depts[theDept] + 1;
                } else {
                    depts[theDept] = 1;
                }
                if (f.Length == 8) {
                    // Salary
                    string theName = f[1];
                    double theSalary = Double.Parse(f[7]);
                    Salaried s = new Salaried(
                        f[0],
                        theName,
                        f[2],
                        f[3],
                        Int32.Parse(f[4]),
                        f[5],
                        theDept,
                        theSalary
                    );
                    if (theSalary < lowestWeeklySalary) {
                        lowestWeeklySalaryName = theName;
                        lowestWeeklySalary = theSalary;
                    }
                    avgWeekly += theSalary;
                    l.Add(s);
                    } else {
                    // Wage / PartTime
                    if (f.Length == 9) {
                        int j = Int32.Parse(f[8]);
                        if (j >= 40) {
                            string theName = f[1];
                            double theWage = Double.Parse(f[7]) * Double.Parse(f[8]);
                            Wages w = new Wages(
                                f[0],
                                f[1],
                                f[2],
                                f[3],
                                Int32.Parse(f[4]),
                                f[5],
                                theDept,
                                Double.Parse(f[7]),
                                Double.Parse(f[8])
                            );
                            if (theWage > highestWeeklyWage) {
                                highestWeeklyWage = theWage;
                                highestWeeklyWageName = theName;
                            }
                            avgWeekly += theWage;
                            l.Add(w);
                        } else {
                            string theName = f[1];
                            double theWage = Double.Parse(f[7]) * Double.Parse(f[8]);
                            PartTime p = new PartTime(
                                f[0],
                                theName,
                                f[2],
                                f[3],
                                Int32.Parse(f[4]),
                                f[5],
                                theDept,
                                Double.Parse(f[7]),
                                Double.Parse(f[8])
                            );
                            avgWeekly += theWage;
                            l.Add(p);
                        }
                    }
                }
                i++;
            }

            // 4b
            Console.WriteLine("The average weekly pay is: $" + Math.Round(avgWeekly / l.Count(), 2));

            // 4c
            Console.WriteLine("Highest weekly wage: " + highestWeeklyWageName + ": $" + highestWeeklyWage);

            // 4d
            Console.WriteLine("Lowest weekly salary: " + lowestWeeklySalaryName + ": $" + lowestWeeklySalary);

            // 4e
            foreach (KeyValuePair<string, int> entry in depts) {
                Console.WriteLine("There is/are " + entry.Value + " person/people in the Department of " + entry.Key);
            }
        }
    }
}
