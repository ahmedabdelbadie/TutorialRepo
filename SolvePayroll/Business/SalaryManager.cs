using CsvHelper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SolvePayroll.APP_DATA;
using SolvePayroll.CSVModel;
using SolvePayroll.Models;
using SolvePayroll.Repo.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTutorial.Data;

namespace SolvePayroll.Business
{
    public class SalaryManager
    {
        EmployeePerMonthReport empR;
        private UnitOfWork _unitOfWork;
        private APPDBContext aPPDBContext;
        public SalaryManager()
        {
            aPPDBContext = new APPDBContext();
            _unitOfWork = new UnitOfWork(aPPDBContext);

        }
      
        public void EmployeeSalary(int emp,int month)
        {
            empR = new EmployeePerMonthReport();
            var dayList = new List<DayReport>();
            month = 10 ;
            emp = 502;
            empR.EmployeeID = emp;
            empR.Year = 2022;
            empR.Month = month;
           
            var em = _unitOfWork.Employee.GetById( emp );
            empR.EmployeeName = em.Name;
            empR.JobType = em.JobType;
            var att = _unitOfWork.Attendance.Find(x => x.Month == month).Select(s => new {s.AttendanceId, s.DayType,s.DateOnly} );
            Dictionary<int, DayReport>? DayReportdic = new Dictionary<int, DayReport> ();
            foreach(var d in att) {
                DayReport dayReport = new DayReport()
                {
                    DateOnly = d.DateOnly,
                   
                    DayType=d.DayType,
                    
                };
                DayReportdic.Add(d.AttendanceId, dayReport);
            }
            var arr = DayReportdic.Keys.ToArray();
            var empAtt = _unitOfWork.EmployeeAttendance.Find(x => x.EmployeeId == emp && arr.Contains(x.AttendanceId));

            foreach (var empAt in empAtt)
            {
                if (empAt.WorkingHourPerDay == 0) continue;
                var day = DayReportdic.GetValueOrDefault(empAt.AttendanceId);
                if (day.DayType == DayType.FullDay)
                {
                    if (empAt.WorkingHourPerDay - 8 > 0)
                    {
                        empR.ExtraDays += (empAt.WorkingHourPerDay - 8) / 8;
                        empR.FeeDay++;
                        empR.Salary += Math.Round(em.FeeDay, 2);
                        empR.NetSalary += Math.Round((em.FeeDay + em.FeeSite + (empR.ExtraDays * (em.FeeDay / 24))), 2);
                        day.Day = 1;
                        day.Extra = (empAt.WorkingHourPerDay - 8) / 8;
                        day.FeeDay = Math.Round(em.FeeDay, 2);
                        day.FeeExtra =Math.Round((empAt.WorkingHourPerDay - 8) / 8 * em.FeeAllowance);
                    }
                    else if (empAt.WorkingHourPerDay - 8 == 0)
                    {
                        empR.FeeDay++;
                        empR.Salary += Math.Round(em.FeeDay, 2);
                        empR.NetSalary += Math.Round((em.FeeDay + em.FeeSite), 2);
                        day.Day = 1;
                        day.Extra = 0;
                        day.FeeDay = Math.Round(em.FeeDay, 2);
                        day.FeeExtra =0;

                    }
                    else if (empAt.WorkingHourPerDay - 8 < 0)
                    {
                        empR.FeeDay += Math.Round((8 / empAt.WorkingHourPerDay), 2);
                        empR.Salary += Math.Round((8 / empAt.WorkingHourPerDay) * em.FeeDay, 2);
                        empR.NetSalary += Math.Round((8 / empAt.WorkingHourPerDay) * em.FeeDay, 2);
                        day.Day = Math.Round((empAt.WorkingHourPerDay / 8), 2);
                        day.Extra = 0;
                        day.FeeDay = Math.Round((empAt.WorkingHourPerDay / 8), 2) * em.FeeDay;
                        day.FeeExtra = 0;

                    }
                }
            }
            using (var writer = new StreamWriter($"C:\\Users\\AhmedElsyaed\\Desktop\\Payroll\\{em.Name}-{month}.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<EmployeePerMonthReport>();
                csv.NextRecord();
                csv.WriteRecord(empR);
                csv.NextRecord();
            }
            var dayReports = DayReportdic.Values.ToArray();
            using (var stream = File.Open($"C:\\Users\\AhmedElsyaed\\Desktop\\Payroll\\{em.Name}-{month}.csv", FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.NextRecord();
                csv.WriteHeader<DayReport>();
                csv.NextRecord();
                csv.WriteRecords(dayReports);
            }

        }

    }
}
