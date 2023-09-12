

namespace ModuleLibrary
{
    public class semesterData
    {
        public int semesterWeeks { get; set; }
        public DateTime semesterStartDate { get; set; }
        public List<int> SemesterWeeks = new List<int>();
        public List<DateTime> SemesterStartDates = new List<DateTime>();

        //this function will be setting the semester weeks
        public int setSemesterWeeks(int weeks)
        {
            this.semesterWeeks = weeks;
            return semesterWeeks;
        }

        public int getSemesterWeeks()
        {
            return semesterWeeks;
        }


        //this function will set the semester start date 
        public DateTime setSemesterStartDate(DateTime date)
        {
            this.semesterStartDate = date;
            return semesterStartDate;
        }

        public DateTime getSemesterStartDate()
        {
            return semesterStartDate;
        }





    }
}
