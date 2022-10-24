using SolvePayroll.APP_DATA;
using SolvePayroll.Business;
using SolvePayroll.Models;
using SolvePayroll.Utility;
public static class Program
{
    static void Main(string[] args)
    {
        // Display the number of command line arguments.
        Console.WriteLine(args.Length);

        //new MigrationCSV().ImportData();
        new SalaryManager().EmployeeSalary(2, 3);


        /*
         Console.WriteLine("Hello, World!");

///  C:\Users\AhmedElsyaed\Desktop\Payroll\Normalized.xlsm
///  


//Supported spreadsheet formats for reading include: XLSX, XLS, CSV and TSV
WorkBook workbook = WorkBook.Load("C:\\Users\\AhmedElsyaed\\Desktop\\Payroll\\Normalized.xlsm");
// Convert the whole Excel WorkBook to a DataSet
// This allows us to work with DataGrids and System.Data.SQL nicely
var leaveDays = new string[] { "Day3", "Day9" };
var WorkingHour = 8;
var WorkingHourMoney = 250;
var extraTimeMoney = 20;
var dataSet = workbook.ToDataSet();
foreach (DataTable table in dataSet.Tables)
{
    Console.WriteLine(table.TableName);
    double sum = 0;
    double empId = 0;
    //Enumerate by rows or columns first at your preference
    //foreach (DataRow row in table.Rows)
    for (int j = 0; j < table.Rows.Count; j++)
    {
        if (j == 0)
        {

            continue;
        }
        for (int i = 0; i < table.Columns.Count; i++)
        {
            Console.Write($"the row {i} is {table.Rows[j][i]}");
            Console.Write(table.Rows[j][i]);
            
            var rowInt = table.Rows[j][i] == null ? 0 : (Double)table.Rows[j][i];
            if (i == 0)
            {
                empId = rowInt;
                continue;
            }
            if (rowInt >= 8)
            {
                sum += rowInt > 8 ? WorkingHourMoney : (WorkingHourMoney + ((rowInt - 8) * extraTimeMoney));
            }
            else
            {
                Console.Write("the number of hour is less than normal");
            }
            


        }
    }
}

         */
    }

    private static void seedData()
    {
        using(var context = new APPDBContext())
        {
            var att = new Attendance()
            {
                //AttendanceId = 1 ,
                DateOnly = new DateOnly(2022, 10, 22),
                Day = 22,
                Month = 10,
                Year = 2022,
                DayType = DayType.FullDay

            };
            var emp = new Employee()
            {
                Name = "AhmedBadea",
                FeeDay = 250,
                FeeAllowance = 20,
                FeeSite = 40,
                FeeDifferentiate = 35,
                JobType = "Digger"
                //EmployeeId = 501
            };
            context.Employees.Add(emp);
            context.Attendances.Add(att);
            
            context.EmployeeAttendance.Add(new EmployeeAttendance()
            {
                Employee= emp,
                Attendance= att
            });
            context.SaveChanges();
            //var emp = new Employee()
            //{
            //    Name = "AhmedBadea",
            //    FeeDay = 250,
            //    FeeAllowance = 20,
            //    FeeSite = 40,
            //    FeeDifferentiate = 35,


            //};
            //var attendance = new Attendance()
            //{

            //    DateOnly = new DateOnly(2022, 10, 22),
            //    AttendanceId = 20221022,
            //    Day = 22,
            //    DayType = DayType.FullDay,
            //    Month = 10,
            //    Year = 2022,
            //};
            //var empAtt = new EmployeeAttendance()
            //{
            //    Attendance = attendance,
            //    Employee = emp,
            //};
            //context.Attendances.Add(attendance);
            //context.Employees.Add(emp);
            //context.EmployeeAttendance.Add(empAtt);
            context.SaveChanges();
        }
    }
}

