using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamKyanite.SchoolObjects
{
    public class Convocation
    {
        public int ConvocationId { get; set; }
        public DayOfWeek Day { get; set; }
        public StartHour StartHour { get; set; }
        public ClassRooms Room { get; set; }
        public virtual Subject Subject { get; set; }

        public Convocation(DayOfWeek day, StartHour startHour, ClassRooms room)
        {
            this.Day = day;
            this.StartHour = startHour;
            this.Room = room;
        }


        public Convocation()
        {

        }
    }
}
