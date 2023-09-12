using System.Reflection.Metadata.Ecma335;

namespace ModuleLibrary{
        public class ModuleData
        {
            public string moduleCode { get; set; }
            public string moduleName { get; set; }
            public double moduleCredits { get; set; }
            public double studyHoursRemaining { get; set; }
            public double classHours { get; set; }
            public DateTime studyDate { get; set; }
            public double studyHour { get; set; }
            public double selfStudyHours { get; set; }


            public List<string> ModuleCodes = new List<string>();
            public List<string> ModuleNames = new List<string>();
            public List<double> ModuleCredits = new List<double>();
            public List<double> ClassHours = new List<double>();
            private Dictionary<DateTime, double> StoredStudyHours = new Dictionary<DateTime, double>();



            //function to store the module code, name, number of credits and class hours per week

            //this function will be used to set the module code
            public string setModuleCode(string code)
            {
                this.moduleCode = code;
                return moduleCode;
            }

            public string getModuleCode()
            {
                return moduleCode;
            }

            //this function will be used to set the module name
            public string setModuleName(string name)
            {
                this.moduleName = name;
                return moduleName;
            }

            public string getModuleName()
            {
                return moduleName;
            }

            public double setModuleCredits(double credits)
            {
                this.moduleCredits = credits;
                return moduleCredits;
            }


            public double getModuleCredits()
            {
                return moduleCredits;
            }

            //this function will be setting the class hours 
            public double setClassHours(double hours)
            {
                this.classHours = hours;
                return classHours;
            }


            public double getClassHours()
            {
                return classHours;
            }
            
        //this function will set the user's choosen study Date
            public DateTime setStudyDate(DateTime date) 
            {
                this.studyDate = date;
                return studyDate;
            }
            public DateTime getStudyDate()
            {
                return studyDate;
            }

        //this function will set the user's study hours 
            public Double setStudyHour(double hour) 
            {
                 this.studyHour = hour;
                return studyHour;
            }

            public double getStudyHour() 
            {
                return studyHour;
            }

            public void studyHoursAdd(DateTime myDate, double hours)//this METHOD WILL ALLOW USERS TO ADD STUDY HOURS ON A SPECIFIC DATE
            {

                if (StoredStudyHours.ContainsKey(myDate))//this if statement will check if the date is stored in the dictionary 
                {
                    StoredStudyHours[myDate] += hours;
                }
                else
                {
                    //adding the date and study hours to the dictionary
                    StoredStudyHours.Add(myDate, hours);
                }
            }



        }
    }