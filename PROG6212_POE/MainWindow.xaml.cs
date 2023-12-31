﻿using ModuleLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG6212_POE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string semesterWeeksValue;
        private DateTime semesterStartDateValue;

        public ObservableCollection<ModuleData> moduleDataList = new ObservableCollection<ModuleData>();
        private List<ModuleData> ModuleDataList = new List<ModuleData>(); // Initialize a list to store module data//for thr second save 


        List<MainWindow> semesterInfo = new List<MainWindow>();
        private object semesterWeeks;

        public MainWindow()
        {
            InitializeComponent();
        }

     

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

      


        //save button functionality
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ModuleData moduleInfo = new ModuleData();
            semesterData semesterInfo = new semesterData();

            int semesterWeeks = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Please enter your semester weeks","Semester Weeks Input"));
            string customDate = Microsoft.VisualBasic.Interaction.InputBox($"Please enter the semester start date (YYYY-MM-DD).","Semester start date input");

            DateTime semesterStartDate = Convert.ToDateTime(customDate);

            string ModuleCode = modulecode.Text;
            string ModuleName = modulename.Text;
            double ModuleCredit = Convert.ToDouble(modulecredits.Text);
            double classHours = Convert.ToDouble(modulehours.Text);

            //set the variable names
            moduleInfo.setModuleCode(ModuleCode);
            moduleInfo.setModuleName(ModuleName);
            moduleInfo.setModuleCredits(ModuleCredit);
            moduleInfo.setClassHours(classHours);

            
            moduleInfo.ModuleNames.Add(ModuleName);//adding the collected data to the array list of the custom class library
            moduleInfo.ModuleCredits.Add(ModuleCredit);
            moduleInfo.ClassHours.Add(classHours);
            moduleInfo.ModuleCodes.Add(ModuleCode);
 

           
       
            semesterInfo.setSemesterStartDate(semesterStartDate);//setting the semester variables
            semesterInfo.setSemesterWeeks(semesterWeeks);

            semesterInfo.SemesterWeeks.Add(semesterWeeks);//adding the semester variables to the list
            semesterInfo.SemesterStartDates.Add(semesterStartDate);
           //



            double totalSelfStudyHours = ((moduleInfo.moduleCredits * 10) / semesterInfo.getSemesterWeeks()) - moduleInfo.classHours;//this variable will contain the total self study hours of a module
               
            
            //THIS WILL ALLOW USERS TO ADD NUMBERS OF HOURS WORKING ON A certain module on a SPECIFIC DATE
                string dateStr = Microsoft.VisualBasic.Interaction.InputBox("Please enter the date of study (DD-MM-YYYY) for this module:");
           
            if (string.IsNullOrEmpty(dateStr))
            {
                MessageBox.Show("Date cannot be empty.","Date Notification");
            }
            else
            {//if the date is not empty prompt the user for studyHours


                double studyHours;
                if (DateTime.TryParse(dateStr, out DateTime currentStudyDate))
                {
                    moduleInfo.setStudyDate(currentStudyDate);//this will set the current module study date
                     studyHours = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox($"Please enter the number of study hours for {ModuleName} on {currentStudyDate.ToShortDateString()}:","Study hours input"));
                        moduleInfo.setStudyHour(studyHours);
                    moduleInfo.studyHoursAdd(currentStudyDate, studyHours);//this will add the study date and hours to the studydate and hours dictionary

                    //this will calculate the remaining study hours in a week
                    double remainingHrs = moduleInfo.getClassHours() - moduleInfo.getStudyHour();

                    moduleInfo.studyDate = currentStudyDate;
                        moduleInfo.studyHour = studyHours;
                    //adding the module information to the list
                    moduleDataList.Add(new ModuleData
                    {
                        moduleCode = moduleInfo.getModuleCode(),
                        moduleName = moduleInfo.getModuleName(),
                        selfStudyHours = totalSelfStudyHours,//fix this calculation
                        studyHoursRemaining = remainingHrs
                    });


                }
                else
                {
                    Microsoft.VisualBasic.Interaction.MsgBox("Invalid date format. Please enter a valid date (YYYY-MM-DD).");
                }

            }
                MessageBox.Show("Module data was successfully saved.","Module data Notification");

            }
            catch(Exception ex) 
            { Console.WriteLine("An exception has occured while saving module data." + ex.Message); }


              }

              //this function will be checking it the user wants to add more modules or not
              private void checkModules(string option)
              {
                  if (option.ToLower().Equals("yes"))
                  {
                      MainWindow obj = new MainWindow();
                      obj.Show();
                      /*  
                        //ADD MORE MODULES
                        string ModuleCode = Microsoft.VisualBasic.Interaction.InputBox("Please enter the module code:");
                        string ModuleName = Microsoft.VisualBasic.Interaction.InputBox("Please enter the module name:");
                        double ModuleCredit = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Please enter the module credit:"));
                        double classHours = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Please enter the class hours:"));

                        // Create and populate the module info
                        ModuleData moduleInfo = new ModuleData
                        {
                            moduleCode = ModuleCode,
                            moduleName = ModuleName,
                            moduleCredits = ModuleCredit,
                            classHours = classHours
                        };

                        outputListview.ItemsSource = moduleDataList;

                        ModuleDataList.Add(moduleInfo);//this will add the collected data to the list 

                        //set the variable names
                        moduleInfo.setModuleCode(ModuleCode);
                        moduleInfo.setModuleName(ModuleName);
                        moduleInfo.setModuleCredits(ModuleCredit);
                        moduleInfo.setClassHours(classHours);

                        //add the collected data to the modules array lists
                        moduleInfo.ModuleNames.Add(ModuleName);
                        moduleInfo.ModuleCredits.Add(ModuleCredit);
                        moduleInfo.ClassHours.Add(classHours);
                        moduleInfo.ModuleCodes.Add(ModuleCode);
                        */


        }
            else
            {
                //collect the semester info if there are no more modules to be added
                int SemesterWeek = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Please enter your semester weeks"));
                string customDate = Microsoft.VisualBasic.Interaction.InputBox($"Please enter the semester start date.");
                DateTime SemesterStartDate = Convert.ToDateTime(customDate);

                semesterData semesterInfo = new semesterData
                {
                    semesterWeeks = SemesterWeek,
                    semesterStartDate = SemesterStartDate
                };


            }


        }
        //this is the display button method
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                outputListview.ItemsSource = moduleDataList;
            }catch(Exception ex)
                {
                MessageBox.Show($"An exception occured while displaying module data: {ex.Message}");
            }
        }
    }
}