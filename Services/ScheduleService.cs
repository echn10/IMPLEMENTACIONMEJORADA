using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManager.Services
{
    public class ScheduleService
    {
        private readonly DataTable _scheduleTable;
        private readonly List<TimeSlot> _timeSlots;

        public ScheduleService()
        {
            _scheduleTable = InitializeScheduleTable();
            _timeSlots = new List<TimeSlot>();
            LoadTimeSlots();
        }

        private DataTable InitializeScheduleTable()
        {
            var table = new DataTable();
            table.Columns.Add("Hora", typeof(string));
            table.Columns.Add("Lunes", typeof(string));
            table.Columns.Add("Martes", typeof(string));
            table.Columns.Add("Miércoles", typeof(string));
            table.Columns.Add("Jueves", typeof(string));
            table.Columns.Add("Viernes", typeof(string));
            return table;
        }

        private void LoadTimeSlots()
        {
            _timeSlots.Add(new TimeSlot("07:40-08:40 AM", 
                new Dictionary<string, string> {
                    {"Lunes", "Contabilidad de Costo"},
                    {"Martes", "Matemática II"},
                    {"Miércoles", "Contabilidad de Costos"},
                    {"Jueves", "Matemática II"},
                    {"Viernes", "Contabilidad de Costo"}
                }));

            // Add other time slots...
        }

        public DataTable GetSchedule()
        {
            foreach (var slot in _timeSlots)
            {
                var row = _scheduleTable.NewRow();
                row["Hora"] = slot.Time;
                
                foreach (var course in slot.Courses)
                {
                    row[course.Key] = course.Value;
                }
                
                _scheduleTable.Rows.Add(row);
            }

            return _scheduleTable;
        }
    }

    public class TimeSlot
    {
        public string Time { get; set; }
        public Dictionary<string, string> Courses { get; set; }

        public TimeSlot(string time, Dictionary<string, string> courses)
        {
            Time = time;
            Courses = courses;
        }
    }
}