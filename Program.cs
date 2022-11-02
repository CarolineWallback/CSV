namespace SchoolDatas
{
    class Program
    {
        static void Main(string[]args)
        {
            var listToExport = ReadFiles.CreateNewDataList();
            WriteToFile.WriteToCSVFile(listToExport);
        }
    }
}








   

    

  




