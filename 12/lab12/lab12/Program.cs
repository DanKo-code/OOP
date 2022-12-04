using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab12
{
     internal class Programm
    {
        static void Main()
        {

            

            try
            {
                KDALog KDALog_01 = new KDALog("C:\\2курс, 1 сем\\ООП\\12\\KDAlogfile.txt");
                KDADiskInfo.OnUpdate += KDALog_01.WriteActionInFile;
                KDAFileInfo.OnUpdate += KDALog_01.WriteActionInFile;
                KDADirInfo.OnUpdate += KDALog_01.WriteActionInFile;
                //KDAFileManager.OnUpdate += KDALog_01.WriteActionInFile;

                //test DiskInfo
                KDADiskInfo.ShowFreeSpace(@"C:\");
                KDADiskInfo.ShowFileSystemInformation(@"C:\");
                KDADiskInfo.ShowInformationAllDrivers();

                //test FileInfo
                KDAFileInfo.ShowFullPatch("C:\\2курс, 1 сем\\ООП\\12\\KDAlogfile.txt");
                KDAFileInfo.ShowFileInformation("C:\\2курс, 1 сем\\ООП\\12\\KDAlogfile.txt");
                KDAFileInfo.ShowFileDatesCreateAndUpdate("C:\\2курс, 1 сем\\ООП\\12\\KDAlogfile.txt");

                //test DirInfo
                KDADirInfo.ShowAmountOfFile("C:\\2курс, 1 сем\\ООП\\12");
                KDADirInfo.ShowCreationTime("C:\\2курс, 1 сем\\ООП\\12");
                KDADirInfo.ShowAmountOfSubdirectories("C:\\2курс, 1 сем\\ООП");
                KDADirInfo.ShowParentDirectory("C:\\2курс, 1 сем\\ООП\\12");

                //test FileManger         
                KDALog KDALog_02 = new KDALog("C:\\2курс, 1 сем\\ООП\\12\\KDAInspect\\KDAdirinfo.txt");
                KDAFileManager.OnUpdate += KDALog_02.WriteActionInFile;
                                            
                KDAFileManager.CreateDirectory("C:\\2курс, 1 сем\\ООП\\12\\KDAInspect");
                KDAFileManager.CreateFile("C:\\2курс, 1 сем\\ООП\\12\\KDAInspect\\KDAdirinfo.txt");

                KDAFileManager.ShowListDirectoryAndFileDisk(@"C:\");
                KDAFileManager.CopyFile("C:\\2курс, 1 сем\\ООП\\12\\KDAInspect\\KDAdirinfo.txt");
                KDAFileManager.DeleteFile("C:\\2курс, 1 сем\\ООП\\12\\KDAInspect\\KDAdirinfo.txt");
                KDAFileManager.CopyFileFromDirectory("C:\\2курс, 1 сем\\ООП\\12\\KDAInspect", ".txt");

                KDAFileManager.MoveDirectory("C:\\2курс, 1 сем\\ООП\\12\\KDAFiles\\", "C:\\2курс, 1 сем\\ООП\\12\\KDAInspect\\KDAFiles");

                KDAFileManager.CreateZipFromDirectory("C:\\2курс, 1 сем\\ООП\\12\\KDAInspect\\KDAFiles");

                KDAFileManager.ShowDirectoryFromZip(@"C:\2курс, 1 сем\ООП\12\KDAInspect\KDAFiles.zip", "C:\\2курс, 1 сем\\ООП\\12\\UnArhive");

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine("Enter day: ");
                int dayUser = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter hour: ");
                int hourUser = int.Parse(Console.ReadLine());

                KDAFileManager.FindInformationFromDay(dayUser, hourUser, 0);
                Console.WriteLine("=======================================================================");
                Console.WriteLine("Enter number of action: ");
                int actionUser = int.Parse(Console.ReadLine());
                KDAFileManager.FindInformationFromDay(dayUser, hourUser, actionUser);
                Console.WriteLine();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}