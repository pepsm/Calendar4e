$(document).ready(function () {
    $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        allDayDefault: false,
        timeZone: 'local',
        defaultDate: '2020-01-07',
        firstDay: 1,
        aspectRatio: 2.0,
        editable: true,
        slotMinutes: 15,
        events: '@Url.RouteUrl(new{ action="GetTasks", controller="Task"})',
        eventRender: function (event, element) {
            element.find('.fc-title').append(" " + event.subject);
        },
        timeFormat: 'h:mm',
        eventClick: function (event, jsEvent, view) {
            jQuery('.event-subject').html(event.subject);
            jQuery('.event-body').html(event.description);
            jQuery('#modal-view-event').modal();
            jQuery('.event-id').html(event.TaskID);
            jQuery('.event-del').attr("href", "/Task/Delete/" + event.TaskID);
            jQuery('.event-start').html(event.start);
        }
    });
});