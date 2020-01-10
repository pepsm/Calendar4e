$(document).ready(function () {
    $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        allDayDefault: false,
        firstDay: 1,
        slotMinutes: 15,
        events: '@Url.RouteUrl(new{ action="GetEvents", controller="Events"})',
        eventRender: function (event, element) {
            element.find('.fc-content').append("<br/>" + event.description);
            element.find('.fc-title').append("<br/>" + event.subject);
        }

    });
});
