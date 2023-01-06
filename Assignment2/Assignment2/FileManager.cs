using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Assignment2
{
    class FileManager
    {
        string fileName = "login.txt";
        string docPath = Application.StartupPath;
        public void addToFile(Account account)
        {
            if (!File.Exists(docPath + "\\" + fileName))
            {
                using (StreamWriter sw = File.CreateText(docPath  + "\\" + fileName)) {}

            }
            using (StreamWriter sw = File.AppendText(docPath + "\\" + fileName))
            {

                sw.WriteLine(account.getUsername() + "," + account.getPassword() + "," + account.getUserType() + "," + account.getFirstName() + "," + account.getLastName() + "," + account.getDob());

            }



        }
        public string checkLogin(string username, string password)
        {

            string[] fileLine = File.ReadAllLines(docPath + "\\" + fileName);
            //loop through each line of file until username/password is found
            foreach (var value in fileLine)
            {
                string[] newVal = value.Split(',');
                //check username
                if (newVal[0] == username)
                {
                    //check if password is matching
                    if (newVal[1] == password)
                    {
                        
                        return newVal[2];
                        
                    }
                }
            }
            return "";
        }

        public void saveFile(string fileContents, string fileName)
        {
            if (File.Exists(docPath + "\\" + fileName))
            {
               
                File.Delete(docPath + "\\" + fileName);
                
            }
            using (StreamWriter sw = File.CreateText(docPath + "\\" + fileName)) { }
            using (StreamWriter sw = File.AppendText(docPath + "\\" + fileName))
            {

                sw.WriteLine(fileContents);

            }

        }
        public bool checkFileExists(string fileName)
        {
            if (File.Exists(docPath + "\\" + fileName))
            {
                return true;
            }
            return false;
        }

        public string openFile(string fileName)
        {
            string fileContents = System.IO.File.ReadAllText(docPath + "\\" + fileName);
            return fileContents;
        }

    }
    
        
}
