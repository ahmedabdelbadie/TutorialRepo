using CsvHelper;
using CsvHelper.Configuration;
using SolvePayroll.APP_DATA;
using SolvePayroll.CSVModel;
using SolvePayroll.Models;
using SolvePayroll.Repo.Interfaces;
using System.Globalization;
using System.Reflection;

namespace SolvePayroll.Utility
{
    public class MigrationCSV
    {
        private UnitOfWork _unitOfWork;
        private APPDBContext aPPDBContext;
        public MigrationCSV()
        {
            aPPDBContext = new APPDBContext();
            _unitOfWork = new UnitOfWork(aPPDBContext);

        }
        public void ImportData()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null,
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };
            using (var reader = new StreamReader("C:\\Users\\AhmedElsyaed\\Desktop\\Payroll\\attendance-10-2022.csv"))
            using (var csv = new CsvReader(reader, config))

            {
                var records = csv.EnumerateRecords(new AttendanceModel());// csv.GetRecords<AttendanceModel>();
                foreach (var record in records)
                {
                    Employee? emp = _unitOfWork.Employee.GetById(record.EmpID);
;
                    if (emp == null)
                    
                    { 
                        emp = new Employee()
                        {
                            Name = "AhmedBadea",
                            FeeDay = 250,
                            FeeAllowance = 20,
                            FeeSite = 40,
                            FeeDifferentiate = 35,
                            JobType = "Digger",
                            EmployeeId = record.EmpID
                        };
                        _unitOfWork.Employee.Add(emp);
                        _unitOfWork.Save();


                    }
                    foreach (PropertyInfo prop in record.GetType().GetProperties())
                    {
                        int DayIndex = 0;
                        if (prop.Name.Contains("Day"))
                        {
                            DayIndex = Int16.Parse(prop.Name.Remove(0, 3));
                        }
                        else
                        {
                            continue;
                        }

                        var val = double.Parse(prop.GetValue(record, null).ToString());

                        DateOnly date = new DateOnly(2022, 10, DayIndex);
                        var day = $"{DayIndex:00}";
                        var id = Int32.Parse($"{date.Year}{date.Month}{day}");
                        #region Add To DataBase


                        Attendance? att = _unitOfWork.Attendance.GetById(id);
                        if (att == null)
                        {
                            att = new Attendance()
                            {
                                AttendanceId = id,
                                DateOnly = date,
                                Day = date.Day,
                                Month = date.Month,
                                Year = date.Year,
                                DayType = DayType.FullDay,
                            };
                            _unitOfWork.Attendance.Add(att);
                            _unitOfWork.Save();
                        }

                        _unitOfWork.EmployeeAttendance.Add(new EmployeeAttendance()
                        {
                            Employee = emp,
                            Attendance = att,
                            WorkingHourPerDay = val
                        });
                        _unitOfWork.Save();
                        #endregion
                    }


                }

            }
        }

    }
}
