using MyDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusinessLayer
{
    public class clsNotes
    {
        public static bool AddNotes(int ID, string Note, char Kind, string Date)
        {
            return clsNotesData.AddNotes(ID, Note, Kind, Date);
        }

        public static DataTable GetNotes(string ID, char Kind)
        {
            return clsNotesData.GetNotes(ID, Kind);
        }

        public static DataTable GetAllNotesForKids(string NameToSearsh)
        {
            return clsNotesData.GetAllNotesForKids(NameToSearsh);
        }

        public static DataTable GetAllNotesForTeachers(string NameToSearsh)
        {
            return clsNotesData.GetAllNotesForTeachers(NameToSearsh);
        }

        public static DataTable GetAllNotesForWorkers(string NameToSearsh)
        {
            return clsNotesData.GetAllNotesForWorkers(NameToSearsh);
        }

        public static bool DeleteAllRecordsInTableNotes()
        {
            return clsNotesData.DeleteAllRecordsInTableNotes();
        }
    }
}
