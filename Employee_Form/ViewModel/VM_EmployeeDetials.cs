using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Input;
using Collins_based_Application_Using_MVVM;
using Task5;
using System.Data;

namespace Employee_Form.ViewModel
{
    public class VM_EmployeeDetials : INotifyPropertyChanged
    {
        ExcelHelp excelHelp;
        string filePath;
        bool nullvalue;
        string nullvaluename;
        public VM_EmployeeDetials() {
            Reset = new RelayCommand(EmptyField);
            PrintCommand = new RelayCommand(Generate);
        }

        private void Generate()
        {
            nullvalue =false;
            nullvaluename = "Please enter the below values to continue";
            valuegetter();
            if (!nullvalue) {
                excelHelp = new ExcelHelp();
                filePath = @"D:\Karuna\Employee_Form\Employee_Form\ExcelFiles\"+Name.Trim()+".xlsx";
                excelHelp.OpenExcel(filePath);
                excelHelp.WriteHeader();
                string agedob = Age + " & " + Empdob;
                string LCP = LocName + "\n" + LocNum;
                string NomDetails = NomName + "\n" + NomDob + "\n" + NomRel + "\n" + NomPhoneNum + "\n" + NomAddress;
                excelHelp.InsertData(Name,agedob,PerAddress,PerPhone,AltPhone,Fathername,Bloodgrp,EmailID,LCP,EmrPhoneNum,LocAddress,NomDetails);
                excelHelp.Footer();
                excelHelp.SaveAndClose(filePath);
                MessageBox.Show("File Created Successfully .....","File Created",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(nullvaluename,"Fill in the blanks",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            
        }

        

        public void EmptyField()
        {
            Name = "";
            Empdob = "";
            PerPhone = "";
            AltPhone = "";
            Fathername = "";
            Bloodgrp = "";
            LocName = "";
            LocNum = "";
            EmrPhoneNum = "";
            LocAddress = "";
            NomName = "";
            NomDob = "";
            NomRel = null;
            NomPhoneNum = "";
            NomAddress = "";
            Age = "";
            PerAddress = "";
        }

        private string name;
        private string empdob;
        private string perPhone;
        private string altPhone;
        private string fathername;
        private string bloodgrp;
        private string locName;
        private string locNum;
        private string emrPhoneNum;
        private string locAddress;
        private string nomName;
        private string nomDob;
        private string nomRel;
        private string nomPhoneNum;
        private string nomAddress;
        private string age;
        private string perAddress;
        private string emailID;

        public string EmailID
        {
            get { return emailID; }
            set { emailID = value;
                OnPropertyChanged();
            }
        }


        public string PerAddress
        {
            get { return perAddress; }
            set { perAddress = value;
                OnPropertyChanged();
            }
        }


        public string Age
        {
            get { return age; }
            set { age = value;
                OnPropertyChanged();
            }
        }


        public string NomAddress
        {
            get { return nomAddress; }
            set { nomAddress = value;
                OnPropertyChanged();
            }
        }

        public string NomPhoneNum
        {
            get { return nomPhoneNum; }
            set { nomPhoneNum = value;
                OnPropertyChanged();
            }
        }


        public string NomRel
        {
            get { return nomRel; }
            set { nomRel = value;
                OnPropertyChanged();
            }
        }

        public string NomDob
        {
            get { return nomDob; }
            set { nomDob = value;
                OnPropertyChanged();
            }
        }

        public string NomName
        {
            get { return nomName; }
            set { nomName = value;
                OnPropertyChanged();
            }
        }


        public string LocAddress
        {
            get { return locAddress; }
            set { locAddress = value;
                OnPropertyChanged();
            }
        }

        public string EmrPhoneNum
        {
            get { return emrPhoneNum; }
            set { emrPhoneNum = value;
                OnPropertyChanged();
            }
        }

        public string LocNum
        {
            get { return locNum; }
            set { locNum = value;
                OnPropertyChanged();
            }
        }

        public string LocName
        {
            get { return locName; }
            set { locName = value;
                OnPropertyChanged();
            }
        }

        public string Bloodgrp
        {
            get { return bloodgrp; }
            set { bloodgrp = value;
                OnPropertyChanged();
            }
        }

        public string Fathername
        {
            get { return fathername; }
            set { fathername = value;
                OnPropertyChanged();
            }
        }

        public string AltPhone
        {
            get { return altPhone; }
            set { altPhone = value;
                OnPropertyChanged();
            }
        }

        public string PerPhone
        {
            get { return perPhone; }
            set { perPhone = value;
                OnPropertyChanged();
            }
        }

        public string Empdob
        {
            get { return empdob; }
            set { empdob = value;
                OnPropertyChanged();
            }
        }


        public string Name
        {
            get { return name; }
            set { name = value;
                OnPropertyChanged();
            }
        }


        public ICommand Reset { get; set; }
        public ICommand PrintCommand { get; set; }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void nullvaluevaluechecker(string val,string name)
        {
            //string Name, string AgeDob,string PerAdd,
            //string PreNO,string AltNo, string Fathername,
            //string Bloodgroup,string EmailID, string LocDet,
            //string LocAdd, string EmrPhone, string NomDetial
            if (string.IsNullOrEmpty(val))
            {
                nullvalue = true;
                nullvaluename += "\n"+name;
            }

        }

        public void valuegetter()
        {
            
            nullvaluevaluechecker(Name,"Name");
            nullvaluevaluechecker(Age, "Age");
            nullvaluevaluechecker(Empdob,"Date Of Birth");
            nullvaluevaluechecker(PerAddress, "Permenant Address");
            nullvaluevaluechecker(PerPhone,"Personal Phone Number");
            nullvaluevaluechecker(AltPhone,"Alternate Phone Number");
            nullvaluevaluechecker(Fathername,"Father Name");
            nullvaluevaluechecker(Bloodgrp,"Blood Group");
            nullvaluevaluechecker(Bloodgrp,"Email Id");
            nullvaluevaluechecker(LocName,"Local Contact Person Name");
            nullvaluevaluechecker(LocNum,"Local Contact Person Number");
            nullvaluevaluechecker(EmrPhoneNum,"Emergency Phone Number");
            nullvaluevaluechecker(LocAddress,"Local Address with Landmark");
            nullvaluevaluechecker(NomName,"Nominee Name");
            nullvaluevaluechecker(NomDob,"Nominee Dob");
            nullvaluevaluechecker(NomRel,"Nominee Relation");
            nullvaluevaluechecker(NomPhoneNum,"Nominee Phone Number");
            nullvaluevaluechecker(NomAddress,"Nominee Address");
            
            

        }
    }
}
