using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperConsoleDEMO.ProjectionDEMO
{
    class Projection
    {
        public static void ProjectionTest()
        {
            // Model
            var calendarEvent = new CalendarEvent
            {
                Date = new DateTime(2008, 12, 15, 20, 30, 0),
                Title = "Company Holiday Party"
            };

            // Configure AutoMapper
            var config = new MapperConfiguration(cfg =>
              cfg.CreateMap<CalendarEvent, CalendarEventForm>()
                .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.Date.Date))
                .ForMember(dest => dest.EventHour, opt => opt.MapFrom(src => src.Date.Hour))
                .ForMember(dest => dest.EventMinute, opt => opt.MapFrom(src => src.Date.Minute)));

            // Perform mapping
            var mapper = config.CreateMapper();
            CalendarEventForm form = mapper.Map<CalendarEvent, CalendarEventForm>(calendarEvent);

        }
    }

    public class CalendarEvent
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
    }
    public class CalendarEventForm
    {
        public DateTime EventDate { get; set; }
        public int EventHour { get; set; }
        public int EventMinute { get; set; }
        public string Title { get; set; }
    }
}
