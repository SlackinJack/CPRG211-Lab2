using System;

namespace Employee {
    public class Salaried : Employee {
        private double salary;
        
        public Salaried() {}
        
        public Salaried(string id,
            string name,
            string address,
            string phone,
            long sin,
            string dob,
            string dept,
            double salary) {
            base.Id = id;
            base.Name = name;
            base.Address = address;
            base.Phone = phone;
            base.Sin = sin;
            base.Dob = dob;
            base.Dept = dept;
            this.salary = salary;
        }
        
        public double Salary {
            get { return this.salary; }
            set { this.salary = value; }
        }
        
        public double GetPay() {
            return this.salary;
        }

        public override string ToString() {
            return this.Id + ", " + this.Name + ", " + this.Address + ", " + this.Phone + ", " + this.Sin + ", " + this.Dob + ", " + this.Dept + ", " + this.Salary.ToString();
        }
    }
}
