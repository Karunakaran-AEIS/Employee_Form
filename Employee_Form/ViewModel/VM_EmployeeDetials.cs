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
using System.Data;
using Employee_Form.HelperClass;
using System.Text.RegularExpressions;

namespace Employee_Form.ViewModel
{
    public class VM_EmployeeDetials : INotifyPropertyChanged
    {
        ExcelHelp excelHelp;
        string filePath;
        bool nullvalue;
        string nullvaluename;
        Regex RegName , RegDob, RegEmail, RegPhoneNum, RegAddress, RegAge, RegBloodGroup;
        public VM_EmployeeDetials() {

            Binding_Buton_Command();
            RegexCreator();
            ReadOnly();

        
            
            
           
        
        }

        public void Binding_Buton_Command()
        {
            Reset = new RelayCommand(EmptyField);
            PrintCommand = new RelayCommand(Generate);
            EntPerPhone = new RelayCommand(EnterPerphone);
            EntAltPhone = new RelayCommand(EnterAltPhone);
            EntFatherName = new RelayCommand(EnterFatherName);
            EntBloodgrp = new RelayCommand(EnterBloodgroup);
            EntLocName = new RelayCommand(EnterLocName);
            EntLocNum = new RelayCommand(EnterLocNum);
            EntEmrPhoneNum = new RelayCommand(EnterEmrPhone);
            EntLocAddress = new RelayCommand(EnterLocAddress);
            EntNomName = new RelayCommand(EnterNomName);
            EntNomDob = new RelayCommand(EnterNomDob);
            EntNomRel = new RelayCommand(EnterNomRel);
            EntNomPhoneNum = new RelayCommand(EnterNomPhoneNum);
            EntAge = new RelayCommand(EnterAge);
            EntPerAddress = new RelayCommand(EnterPerAddress);
            EntEmailId = new RelayCommand(EnterEmailId);
            EntName = new RelayCommand(EnterName);
        }

        public void RegexCreator()
        {
         RegName = new Regex("^[a-zA-Z ]+$");
         RegDob = new Regex("^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/((19|20)\\d\\d)$");
         RegEmail = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
         RegPhoneNum = new Regex("^[6-9]\\d{9}$");
         RegAddress = new Regex("^[a-zA-Z0-9 ,.-/]+$");
         RegAge = new Regex("^(1[89]|[2-9][0-9])$");
         RegBloodGroup = new Regex("^(A|B|AB|O)[+-]$");
        }

        private void EnterName()
        {
            if (RegName.IsMatch(Name)) {
                FocAge = true;
                ReadDob = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Name", "Invalid Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                Focname = true;
            }
                
        }

        private void EnterEmailId()


        {
            if(RegEmail.IsMatch(EmailID))
            {
                FocPerAddress = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Email ID", "Invalid Email ID", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocEmailId = true;
            }
            FocPerAddress = true;
        }

        private void EnterPerAddress()
        {
            if(RegAddress.IsMatch(PerAddress))
            {
                FocEntPhone = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Address", "Invalid Address", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocPerAddress = true;
            }
           
        }

        private void EnterAge()
        {
            if (RegAge.IsMatch(Age))
            {
                FocDob = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Age (18-99)", "Invalid Age", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocAge = true;
            }
        }

        private void EnterNomPhoneNum()
        {
            if(RegPhoneNum.IsMatch(NomPhoneNum))
            {
                FocNomAddress = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Phone Number", "Invalid Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocNomPhoneNum = true;
            }
        }

        private void EnterNomRel()
        {
            if (NomRel == null)
            {
                MessageBox.Show("Please select a Relation", "Invalid Relation", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocNomRel = true;
            }
            else
            {
                FocNomPhoneNum = true;
            }
        }

        private void EnterNomDob()
        {
            if(RegDob.IsMatch(NomDob))
            {
                FocNomRel = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Date of Birth (DD/MM/YYYY)", "Invalid Date of Birth", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocNomDob = true;
            }
        }

        private void EnterNomName()
        {
            if (RegName.IsMatch(NomName))
            {
                FocNomDob = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Name", "Invalid Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocNomName = true;
            }
        }

        private void EnterLocAddress()
        {
            if (RegAddress.IsMatch(LocAddress))
            {
                FocEmrPhoneNum = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Address", "Invalid Address", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocLocAddress = true;
            }
            
        }

        private void EnterEmrPhone()
        {
                if(RegPhoneNum.IsMatch(EmrPhoneNum))
            {
                FocLocAddress = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Phone Number", "Invalid Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocEmrPhoneNum = true;
            }
        }

        private void EnterLocNum()
        {
            if(RegPhoneNum.IsMatch(LocNum))
            {
                FocLocName = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Phone Number", "Invalid Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocLocNum = true;
            }
            
        }

        private void EnterLocName()
        {
            if (RegName.IsMatch(LocName))
            {
                FocLocNum = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Name", "Invalid Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocLocName = true;
                
            }
        }

        private void EnterBloodgroup()
        {
            if (RegBloodGroup.IsMatch(Bloodgrp))
            {
                FocEmailId = true;
            }
            else
            {
                MessageBox.Show("Please Enter a valid Blood Group ( Eg:B+ )");
                FocBloodgrp = true;

            }
            
        }

        private void EnterFatherName()
        {
            if (RegName.IsMatch(Fathername))
            {
                FocBloodgrp = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Name", "Invalid Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocFatherName=true;
            }
            
        }

        private void EnterAltPhone()
        {
            if (RegPhoneNum.IsMatch(AltPhone))
            {
                FocLocName = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Phone Number", "Invalid Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocAltPhone = true;
            }
           
        }

        private void EnterPerphone()
        {
            if (RegPhoneNum.IsMatch(PerPhone))
            {
                FocAltPhone = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Phone Number", "Invalid Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocEntPhone = true;
            }
            
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
                EmptyField();
            }
            else
            {
                MessageBox.Show(nullvaluename,"Fill in the blanks",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            
        }

        

        public void EmptyField()
        {
            FocusRemover();
            Focname = true;
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
        private bool focDob;
        private bool focFatherName;
        private bool focBloodgrp;
        private bool focNomName;
        private bool focNomRel;
        private bool focNomPhoneNum;
        private bool focNomAddress;
        private bool focAge;
        private bool focPerAddress;
        private bool focname;
        private bool focEmailId;
        private bool focNomNDob;
        private bool focLocAddress;
        private bool focEmrPhoneNum;
        private bool focLocNum;
        private bool focLocName;
        private bool focAltPhone;
        private bool focEntPhone;
        private bool readDob;
        private bool readFatherName;
        private bool readBloodgrp;
        private bool readNomName;
        private bool readNomRel;
        private bool readNomPhoneNum;
        private bool readNomAddress;
        private bool readAge;
        private bool readPerAddress;
        private bool readname;
        private bool readEmailId;
        private bool readNomNDob;
        private bool readLocAddress;
        private bool readEmrPhoneNum;
        private bool readLocNum;
        private bool readLocName;
        private bool readAltPhone;
        private bool readEntPhone;

        // ---------------   Read Property ----------------- //

        public bool ReadDob
        {
            get { return readDob; }
            set
            {
                readDob = value;
                OnPropertyChanged();
            }
        }


        public bool ReadEntPhone
        {
            get { return readEntPhone; }
            set
            {
                readEntPhone = value;
                OnPropertyChanged();
            }
        }



        public bool ReadAltPhone
        {
            get { return readAltPhone; }
            set
            {
                readAltPhone = value;
                OnPropertyChanged();
            }
        }



        public bool ReadFatherName
        {
            get { return readFatherName; }
            set
            {
                readFatherName = value;
                OnPropertyChanged();
            }
        }



        public bool ReadBloodgrp
        {
            get { return readBloodgrp; }
            set
            {
                readBloodgrp = value;
                OnPropertyChanged();
            }
        }



        public bool ReadLocName
        {
            get { return readLocName; }
            set
            {
                readLocName = value;
                OnPropertyChanged();
            }
        }



        public bool ReadLocNum
        {
            get { return readLocNum; }
            set
            {
                readLocNum = value;
                OnPropertyChanged();
            }
        }



        public bool ReadEmrPhoneNum
        {
            get { return readEmrPhoneNum; }
            set
            {
                readEmrPhoneNum = value;
                OnPropertyChanged();
            }
        }


        public bool ReadLocAddress
        {
            get { return readLocAddress; }
            set
            {
                readLocAddress = value;
                OnPropertyChanged();
            }
        }



        public bool ReadNomName
        {
            get { return readNomName; }
            set
            {
                readNomName = value;
                OnPropertyChanged();
            }
        }

        public bool ReadNomDob
        {
            get { return readNomNDob; }
            set
            {
                readNomNDob = value;
                OnPropertyChanged();
            }
        }

        public bool ReadNomRel
        {
            get { return readNomRel; }
            set
            {
                readNomRel = value;
                OnPropertyChanged();
            }
        }



        public bool ReadNomPhoneNum
        {
            get { return readNomPhoneNum; }
            set
            {
                readNomPhoneNum = value;
                OnPropertyChanged();
            }
        }


        public bool ReadNomAddress
        {
            get { return readNomAddress; }
            set
            {
                readNomAddress = value;
                OnPropertyChanged();
            }
        }


        public bool ReadAge
        {
            get { return readAge; }
            set
            {
                readAge = value;
                OnPropertyChanged();
            }
        }


        public bool ReadPerAddress
        {
            get { return readPerAddress; }
            set
            {
                readPerAddress = value;
                OnPropertyChanged();
            }
        }



        public bool ReadEmailId
        {
            get { return readEmailId; }
            set
            {
                readEmailId = value;
                OnPropertyChanged();
            }
        }
        public bool Readname
        {
            get { return readname; }
            set
            {
                readname = value;
                OnPropertyChanged();
            }
        }

        // ----------- Focus Property----------- //


        public bool FocDob
        {
            get { return focDob; }
            set
            {
                focDob = value;
                OnPropertyChanged();
            }
        }


        public bool FocEntPhone
        {
            get { return focEntPhone; }
            set
            {
                focEntPhone = value;
                OnPropertyChanged();
            }
        }



        public bool FocAltPhone
        {
            get { return focAltPhone; }
            set
            {
                focAltPhone = value;
                OnPropertyChanged();
            }
        }



        public bool FocFatherName
        {
            get { return focFatherName; }
            set
            {
                focFatherName = value;
                OnPropertyChanged();
            }
        }



        public bool FocBloodgrp
        {
            get { return focBloodgrp; }
            set
            {
                focBloodgrp = value;
                OnPropertyChanged();
            }
        }



        public bool FocLocName
        {
            get { return focLocName; }
            set
            {
                focLocName = value;
                OnPropertyChanged();
            }
        }



        public bool FocLocNum
        {
            get { return focLocNum; }
            set
            {
                focLocNum = value;
                OnPropertyChanged();
            }
        }



        public bool FocEmrPhoneNum
        {
            get { return focEmrPhoneNum; }
            set
            {
                focEmrPhoneNum = value;
                OnPropertyChanged();
            }
        }


        public bool FocLocAddress
        {
            get { return focLocAddress; }
            set
            {
                focLocAddress = value;
                OnPropertyChanged();
            }
        }



        public bool FocNomName
        {
            get { return focNomName; }
            set
            {
                focNomName = value;
                OnPropertyChanged();
            }
        }

        public bool FocNomDob
        {
            get { return focNomNDob; }
            set
            {
                focNomNDob = value;
                OnPropertyChanged();
            }
        }

        public bool FocNomRel
        {
            get { return focNomRel; }
            set
            {
                focNomRel = value;
                OnPropertyChanged();
            }
        }



        public bool FocNomPhoneNum
        {
            get { return focNomPhoneNum; }
            set
            {
                focNomPhoneNum = value;
                OnPropertyChanged();
            }
        }


        public bool FocNomAddress
        {
            get { return focNomAddress; }
            set
            {
                focNomAddress = value;
                OnPropertyChanged();
            }
        }


        public bool FocAge
        {
            get { return focAge; }
            set
            {
                focAge = value;
                OnPropertyChanged();
            }
        }


        public bool FocPerAddress
        {
            get { return focPerAddress; }
            set
            {
                focPerAddress = value;
                OnPropertyChanged();
            }
        }



        public bool FocEmailId
        {
            get { return focEmailId; }
            set
            {
                focEmailId = value;
                OnPropertyChanged();
            }
        }
        public bool Focname
        {
            get { return focname; }
            set
            {
                focname = value;
                OnPropertyChanged();
            }
        }


        //-- Focus Finished ----------

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
            set {
                FocNomPhoneNum = false;
                if (value == null){
                    nomRel = value;
                    OnPropertyChanged();
                }
                else
                {
                    nomRel = value;
                    FocNomPhoneNum = true;
                    OnPropertyChanged();
                }
                    
            }
        }

        public string NomDob
        {
            get { return nomDob; }
            set
            {
                FocNomRel = false;
                if (value == null)
                {
                    nomDob = value;
                    OnPropertyChanged();
                }
                else
                {
                    nomDob = value;
                    FocNomRel = true;
                    OnPropertyChanged();
                }
                    
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
            set {
                FocFatherName = false;
                if(value == null)
                {
                    empdob = value;
                    OnPropertyChanged();
                }
                else
                {
                    empdob = value;
                    FocFatherName = true;
                    OnPropertyChanged();
                }

                    
            }
        }


        public string Name
        {
            get { return name; }
            set { name = value;
                OnPropertyChanged();
            }
        }


        public ICommand EntPerPhone { get; set; }
        public ICommand EntAltPhone { get; set; }
        public ICommand EntFatherName { get; set; }
        public ICommand EntBloodgrp { get; set; }
        public ICommand EntLocName { get; set; }
        public ICommand EntLocNum { get; set; }
        public ICommand EntEmrPhoneNum { get; set; }
        public ICommand EntLocAddress { get; set; }
        public ICommand EntNomName { get; set; }
        public ICommand EntNomDob { get; set; }
        public ICommand EntNomRel { get; set; }
        public ICommand EntNomPhoneNum { get; set; }
        public ICommand EntNomAddress { get; set; }
        public ICommand EntAge { get; set; }
        public ICommand EntPerAddress { get; set; }
        public ICommand EntEmailId { get; set; }
        public ICommand EntName { get; set; }
        public ICommand Reset { get; set; }
        public ICommand PrintCommand { get; set; }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void nullvaluevaluechecker(string val,string name)
        {
            
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

        public void FocusRemover()
        {
        FocDob=false;
        FocFatherName = false;
        FocBloodgrp = false;
        FocNomName = false;
        FocNomRel = false;
        FocNomPhoneNum = false;
        FocNomAddress = false;
        FocAge = false;
        FocPerAddress = false;
        Focname = false;
        FocEmailId = false;
        FocNomDob = false;
        FocLocAddress = false;
        FocEmrPhoneNum = false;
        FocLocNum = false;
        FocLocName = false;
        FocAltPhone = false;
        FocEntPhone = false;
        }

        public void ReadOnly()
        {
            ReadDob = false;
            ReadFatherName = true;
            ReadBloodgrp = true;
            ReadNomName = true;
            ReadNomRel = false;
            ReadNomPhoneNum = true;
            ReadNomAddress = true;
            ReadAge = true;
            ReadPerAddress = true;
            Readname = true;
            ReadEmailId = true;
            ReadNomDob = false;
            ReadLocAddress = true;
            ReadEmrPhoneNum = true;
            ReadLocNum = true;
            ReadLocName = true;
            ReadAltPhone = true;
            ReadEntPhone = true;
        }

        
    }
}
