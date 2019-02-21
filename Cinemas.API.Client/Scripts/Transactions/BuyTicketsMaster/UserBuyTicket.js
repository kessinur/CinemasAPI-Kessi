$(document).ready(function () {
    LoadIndexBuyTicket();
    $('#table').DataTable({
        "ajax": LoadIndexBuyTicket()
    });
});

function LoadIndexBuyTicket() {
    $.ajax({
        url: 'http://localhost:17940/api/FilmRooms',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (filmroom) {
            var html = '';
            var i = 1;
            $.each(filmroom, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Films.Title + '</td>';
                html += '<td>' + val.ShowDate + '</td>';
                html += '<td>' + val.Hour + '</td>';
                html += '<td>' + val.Films.Duration + " Minutes" + '</td>';
                html += '<td>' + val.Rooms.Name + '</td>';
                html += '<td>' + val.Rooms.Cinemas.Name + '</td>';
                html += '<td>' + val.Rooms.Cinemas.Address + '</td>';
                html += '<td>' + val.Rooms.Seat + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Order</a> ';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}
