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
using System.Net.Sockets;
using System.Windows.Media;
using Microsoft.Reporting.Map.WebForms.BingMaps;

namespace Employee_Form.ViewModel
{
    public class VM_EmployeeDetials : INotifyPropertyChanged
    {
        ExcelHelp excelHelp;
        string filePath;
        bool nullvalue;
        string nullvaluename;
        Regex RegName , RegDob, RegEmail, RegPhoneNum, RegAddress, RegAge, RegBloodGroup,RegRelation;
        public VM_EmployeeDetials() {


            Binding_Buton_Command();
            RegexCreator();
            ReadOnly();
            FocusRemover();
            FocNomPhoneNum = false;
            ReadNomPhoneNum = true;
            Focname = true;

            
        }
        public void GetValue()
        {
            excelHelp = new ExcelHelp();
            filePath = @"C:\Users\AEIS LAPTOP Abhay\Downloads\Employee_Form\Employee_Form\ExcelFiles\" + Name.Trim() + ".xlsx";
            excelHelp.OpenExcel(filePath);
            if (excelHelp.IsFileExist) {

                excelHelp.GetData();
                Name = excelHelp.Name;
                Age = excelHelp.Age;
                Empdob = excelHelp.DOB;
                PerAddress = excelHelp.PerAdd;
                PerPhone = excelHelp.PreNO;
                AltPhone = excelHelp.AltNo;
                Fathername = excelHelp.Fathername;
                Bloodgrp = excelHelp.Bloodgroup;
                EmailID = excelHelp.EmailID;
                LocName = excelHelp.LocName;
                LocNum = excelHelp.LocPhone;
                EmrPhoneNum = excelHelp.EmrPhone;
                LocAddress = excelHelp.LocAdd;
                NomName = excelHelp.NomName;
                NomDob = excelHelp.NomDob;
                NomRel = excelHelp.NomRel;

                if(NomRel == "Father")
                {
                    Cmbindex = 1;
                }
                if(NomRel == "Mother")
                {
                    Cmbindex = 2;
                }
                if(NomRel == "Husband")
                {
                    Cmbindex = 3;
                }
                if(NomRel == "Wife")
                {
                    Cmbindex = 4;
                }
                if(NomRel == "Brother")
                {
                    Cmbindex = 5;
                }
                if(NomRel == "Sister")
                {
                    Cmbindex = 6;
                }if(NomRel == "Son")
                {
                    Cmbindex = 7;
                }if(NomRel == "Daughter")
                {
                    Cmbindex = 8;
                }if(NomRel == "Gardian")
                {
                    Cmbindex = 9;
                }

                NomPhoneNum = excelHelp.NomPhone;
                NomAddress = excelHelp.NomAddress;

                MessageBoxResult rs =MessageBox.Show("Do You Want to edit","Update Or Not",MessageBoxButton.YesNo,MessageBoxImage.Information);

                if (rs == MessageBoxResult.Yes)
                {
                    ReadOnly();
                    ChangeReadOnly();
                }

                excelHelp.SaveAndClose(filePath);


            }
            else
            {
                MessageBox.Show("File does not exist");
                excelHelp.SaveAndClose(filePath);
            }
            

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
            EntNomAddress = new RelayCommand(EnterNomAddress);
            EntAge = new RelayCommand(EnterAge);
            EntPerAddress = new RelayCommand(EnterPerAddress);
            EntEmailId = new RelayCommand(EnterEmailId);
            EntName = new RelayCommand(EnterName);
            Fetch = new RelayCommand(GetValue);
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
            RegRelation = new Regex("^(Father|Mother|Husband|Wife|Son|Daughter|Guardian)$");
        }

        private void Generate()
        {
            nullvalue = false;
            nullvaluename = "Please enter the below values to continue";
            valuegetter();
            if (!nullvalue)
            {
                excelHelp = new ExcelHelp();
                filePath = @"C:\Users\AEIS LAPTOP Abhay\Downloads\Employee_Form\Employee_Form\ExcelFiles\" + Name.Trim() + ".xlsx";
                excelHelp.OpenExcel(filePath);
                excelHelp.WriteHeader();
                string agedob = Age + " & " + Empdob;
                string LCP = LocName + "\n" + LocNum;
                string NomDetails = NomName + "\n" + NomDob + "\n" + NomRel + "\n" + NomPhoneNum + "\n" + NomAddress;
                excelHelp.InsertData(Name, agedob, PerAddress, PerPhone, AltPhone, Fathername, Bloodgrp, EmailID, LCP, EmrPhoneNum, LocAddress, NomDetails);
                excelHelp.Footer();
                excelHelp.SaveAndClose(filePath);
                MessageBox.Show("File Created Successfully .....", "File Created", MessageBoxButton.OK, MessageBoxImage.Information);
                EmptyField();
                ReadOnly();
            }
            else
            {
                MessageBox.Show(nullvaluename, "Fill in the blanks", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            EmailID = "";
            EmrPhoneNum = "";
            LocAddress = "";
            NomName = "";
            NomDob = "";
            Cmbindex = 0;
            NomRel = null;
            NomPhoneNum = "";
            NomAddress = "";
            Age = "";
            PerAddress = "";
        }

        public void nullvaluevaluechecker(string val, string name)
        {

            if (string.IsNullOrEmpty(val))
            {
                nullvalue = true;
                nullvaluename += "\n" + name;
            }

        }



        public void valuegetter()
        {

            nullvaluevaluechecker(Name, "Name");
            nullvaluevaluechecker(Age, "Age");
            nullvaluevaluechecker(Empdob, "Date Of Birth");
            nullvaluevaluechecker(PerAddress, "Permenant Address");
            nullvaluevaluechecker(PerPhone, "Personal Phone Number");
            nullvaluevaluechecker(AltPhone, "Alternate Phone Number");
            nullvaluevaluechecker(Fathername, "Father Name");
            nullvaluevaluechecker(Bloodgrp, "Blood Group");
            nullvaluevaluechecker(Bloodgrp, "Email Id");
            nullvaluevaluechecker(LocName, "Local Contact Person Name");
            nullvaluevaluechecker(LocNum, "Local Contact Person Number");
            nullvaluevaluechecker(EmrPhoneNum, "Emergency Phone Number");
            nullvaluevaluechecker(LocAddress, "Local Address with Landmark");
            nullvaluevaluechecker(NomName, "Nominee Name");
            nullvaluevaluechecker(NomDob, "Nominee Dob");
            nullvaluevaluechecker(NomRel, "Nominee Relation");
            nullvaluevaluechecker(NomPhoneNum, "Nominee Phone Number");
            nullvaluevaluechecker(NomAddress, "Nominee Address");



        }

        // --------------- Method Used To Change The Focus of Every Property to true -----------------//
        public void FocusRemover()
        {
            Focname = true;
            FocDob = false;
            FocFatherName = false;
            FocBloodgrp = false;
            FocNomName = false;
            FocNomRel = false;
            FocNomPhoneNum = false;
            FocNomAddress = false;
            FocAge = false;
            FocPerAddress = false;
            FocEmailId = false;
            FocNomDob = false;
            FocLocAddress = false;
            FocEmrPhoneNum = false;
            FocLocNum = false;
            FocLocName = false;
            FocAltPhone = false;
            FocEntPhone = false;
        }

        // --------------- Method Used to Change Field To Read Only ------------------ //
        public void ReadOnly()
        {
            ReadDob = false;
            ReadFatherName = true;
            ReadBloodgrp = true;
            ReadNomName = true;
            ReadNomRel = true;
            ReadNomPhoneNum = true;
            ReadNomAddress = true;
            ReadAge = true;
            ReadPerAddress = true;
            Readname = false;
            ReadEmailId = true;
            ReadNomDob = false;
            ReadLocAddress = true;
            ReadEmrPhoneNum = true;
            ReadLocNum = true;
            ReadLocName = true;
            ReadAltPhone = true;
            ReadEntPhone = true;
        }

        public void ChangeReadOnly()
        {
            ReadDob = true;
            ReadFatherName = false;
            ReadBloodgrp = false;
            ReadNomName = false;
            ReadNomRel = false;
            ReadNomPhoneNum = false;
            ReadNomAddress = false;
            ReadAge = false;
            ReadPerAddress = false;
            Readname = true;
            ReadEmailId = false;
            ReadNomDob = true;
            ReadLocAddress = false;
            ReadEmrPhoneNum = false;
            ReadLocNum = false;
            ReadLocName = false;
            ReadAltPhone = false;
            ReadEntPhone = false;

        }

        private void EnterNomAddress()
        {
            if (RegAddress.IsMatch(NomAddress))
            {
            }
            else
            {
                MessageBox.Show("Please enter a valid Name", "Invalid Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocNomAddress = true;
            }
        }
        private void EnterName()
        {
            if (RegName.IsMatch(Name)) {

                FocusRemover();
                ReadAge = false;
                FocAge = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Name", "Invalid Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocusRemover();
                Focname = true;
            }
                
        }
        private void EnterEmailId()


        {
            if(RegEmail.IsMatch(EmailID))
            {
                FocusRemover();
                ReadPerAddress = false;
                FocPerAddress = true;
                
            }
            else
            {
                MessageBox.Show("Please enter a valid Email ID", "Invalid Email ID", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocusRemover();
                FocEmailId = true;
            }
            FocPerAddress = true;
        }
        private void EnterPerAddress()
        {
            if(RegAddress.IsMatch(PerAddress))
            {
                FocusRemover();
                ReadEntPhone = false;
                FocEntPhone = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Address", "Invalid Address", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocusRemover();
                FocPerAddress = true;
            }
           
        }
        private void EnterAge()
        {
            if (RegAge.IsMatch(Age))
            {
                FocusRemover();
                ReadDob = true;
                FocDob = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Age (18-99)", "Invalid Age", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocusRemover();
                FocAge = true;
            }
        }
        private void EnterNomPhoneNum()
        {
            if(RegPhoneNum.IsMatch(NomPhoneNum))
            {
                FocusRemover();
                ReadNomAddress = false;
                FocNomAddress = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Phone Number", "Invalid Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocusRemover();
                FocNomPhoneNum = true;
            }
        }
        private void EnterNomRel()
        {
            if (RegRelation.IsMatch(NomRel))
            {
                FocusRemover();
                ReadNomPhoneNum = false;
                FocNomPhoneNum = true;
            }
            else
            {
                MessageBox.Show("Please Enter a Relation in this Format Father | Mother | Husband | Wife | Son | Daughter | Guardian", "Invalid Relation", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocusRemover();
                FocNomPhoneNum = true;
            }
        }
        private void EnterNomDob()
        {
            if(RegDob.IsMatch(NomDob))
            {
                FocusRemover();
                ReadNomRel = true;
                FocNomRel = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Date of Birth (DD/MM/YYYY)", "Invalid Date of Birth", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocusRemover();
                FocNomDob = true;
            }
        }
        private void EnterNomName()
        {
            if (RegName.IsMatch(NomName))
            {
                FocusRemover();
                ReadNomDob = true;
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
                FocusRemover();
                ReadNomName = false;
                FocNomName = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Address", "Invalid Address", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocusRemover();
                FocLocAddress = true;
            }
            
        }
        private void EnterEmrPhone()
        {
                if(RegPhoneNum.IsMatch(EmrPhoneNum))
            {
                FocusRemover();
                ReadLocAddress = false;
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
                FocusRemover();
                ReadEmrPhoneNum = false;
                FocEmrPhoneNum = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Phone Number", "Invalid Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocusRemover();
                FocLocNum = true;
            }
            
        }
        private void EnterLocName()
        {
            if (RegName.IsMatch(LocName))
            {
                FocusRemover();
                ReadLocNum = false;
                FocLocNum = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Name", "Invalid Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocusRemover();
                FocLocName = true;
                
            }
        }
        private void EnterBloodgroup()
        {
            if (RegBloodGroup.IsMatch(Bloodgrp))
            {
                FocusRemover();
                ReadEmailId = false;
                FocEmailId = true;
            }
            else
            {
                MessageBox.Show("Please Enter a valid Blood Group ( Eg:B+ )");
                FocusRemover();
                FocBloodgrp = true;

            }
            
        }
        private void EnterFatherName()
        {
            if (RegName.IsMatch(Fathername))
            {
                FocusRemover();
                ReadBloodgrp = false;
                FocBloodgrp = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Name", "Invalid Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocusRemover();
                FocFatherName =true;
            }
            
        }
        private void EnterAltPhone()
        {
            if (RegPhoneNum.IsMatch(AltPhone))
            {
                FocusRemover();
                ReadLocName = false;
                FocLocName = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Phone Number", "Invalid Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocusRemover();
                FocAltPhone = true;
            }
           
        }
        private void EnterPerphone()
        {
            if (RegPhoneNum.IsMatch(PerPhone))
            {
                FocusRemover();
                ReadAltPhone = false;
                FocAltPhone = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid Phone Number", "Invalid Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning);
                FocusRemover();
                FocEntPhone = true;
            }
            
        }


        // ------------ Property Declaration -----------//
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

        private int cmbindex;

        public int Cmbindex
        {
            get { return cmbindex; }
            set { cmbindex = value;

                OnPropertyChanged();
                    }
        }


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


        //------------ Text Field's Content Property---------- //

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
                    nomRel = value;
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
                    FocusRemover();
                    if (DateTime.TryParse(value, out DateTime dt))
                    {
                        nomDob = dt.ToShortDateString();
                        ReadNomRel = false;
                        FocNomRel = true;
                        OnPropertyChanged();
                    }
                    else
                    {
                        nomDob = value;
                        ReadNomRel = false;
                        FocNomRel = true;
                        OnPropertyChanged();
                    }

                    
                }

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
                    FocusRemover();

                    if (DateTime.TryParse(value, out DateTime dt))
                    {
                        empdob = dt.ToShortDateString(); 
                    }
                    else
                    {
                        empdob = value; 
                    }                    
                    ReadFatherName = false;
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


        // --------------- Button ICommand Property ------------- //
        
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

        public ICommand Fetch { get; set; }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




        
    }
}
