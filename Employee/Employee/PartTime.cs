using System;

namespace Employee {
    public class PartTime : Employee {
        private double rate;
        private double hours;
        
        public PartTime() {}
        
        public PartTime(string id,
            string name,
            string address,
            string phone,
            long sin,
            string dob,
            string dept,
            double rate,
            double hours) {
            base.Id = id;
            base.Name = name;
            base.Address = address;
            base.Phone = phone;
            base.Sin = sin;
            base.Dob = dob;
            base.Dept = dept;
            this.rate = rate;
            this.hours = hours;
        }
        
        public double Rate {
            get { return this.rate; }
            set { this.rate = value; }
        }
        
        public double Hours {
            get { return this.hours; }
            set { this.hours = value; }
        }
        
        public double GetPay() {
            return this.hours * this.rate;
        }

        public override string ToString() {
            return this.Id + ", " + this.Name + ", " + this.Address + ", " + this.Phone + ", " + this.Sin + ", " + this.Dob + ", " + this.Dept + ", " + this.Rate.ToString() + ", " + this.Hours.ToString();
        }
    }
}
