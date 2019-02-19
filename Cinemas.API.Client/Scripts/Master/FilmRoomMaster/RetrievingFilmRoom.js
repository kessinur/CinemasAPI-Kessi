$(document).ready(function () {
    LoadIndexFilmRoom();
    LoadFilmCombo();
    LoadRoomCombo();
    hiddenFilmRoomAlert();
    $('#table').DataTable({
        "ajax": LoadIndexFilmRoom()
    });
});

function LoadIndexFilmRoom() {
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
                html += '<td>' + val.ShowDate + '</td>';
                html += '<td>' + val.Hour + '</td>';
                html += '<td>' + val.Price + '</td>';
                html += '<td>' + val.Films.Title + '</td>';
                html += '<td>' + val.Rooms.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function LoadFilmCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/Films',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var film = $('#Films');
            film.empty();
            film.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, Film) {
                $("<option></option>").val(Film.Id).text(Film.Title).appendTo(film);
            });
        }
    });
}

function LoadRoomCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/Rooms',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var room = $('#Rooms');
            room.empty();
            room.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, Room) {
                $("<option></option>").val(Room.Id).text(Room.Name).appendTo(room);
            });
        }
    });
}

function Save() {
    var filmroom = new Object();
    filmroom.ShowDate = $('#ShowDate').val();
    filmroom.Hour = $('#Hour').val();
    filmroom.Price = $('#Price').val();
    filmroom.Films_Id = $('#Films').val();
    filmroom.Rooms_Id = $('#Rooms').val();
    $.ajax({
        url: 'http://localhost:17940/api/FilmRooms',
        type: 'POST',
        dataType: 'json',
        data: filmroom,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/FilmRooms/Index/';
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function Delete(Id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: "http://localhost:17940/api/FilmRooms/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/FilmRooms/Index/';
                });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function GetById(Id) {
    $.ajax({
        url: 'http://localhost:17940/api/FilmRooms/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#ShowDate').val(result.ShowDate);
            $('#Hour').val(result.Hour);
            $('#Price').val(result.Price);
            $('#Films').val(result.Films_Id);
            $('#Rooms').val(result.Rooms_Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {
    var filmroom = new Object();
    filmroom.Id = $('#Id').val();
    filmroom.ShowDate = $('#ShowDate').val();
    filmroom.Hour = $('#Hour').val();
    filmroom.Price = $('#Price').val();
    filmroom.Films_Id = $('#Films').val();
    filmroom.Rooms_Id = $('#Rooms').val();
    $.ajax({
        url: 'http://localhost:17940/api/FilmRooms/' + filmroom.Id,
        type: 'PUT',
        data: filmroom,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/FilmRooms/Index/';
                $('#Id').val('');
                $('#Name').val('');
                $('#Address').val('');
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function validateInsertFilmRoom() {
    var allValid = true;
    if ($('#ShowDate').val() == "" || $('#ShowDate').val() == " ") {
        allValid = false;
        $('#ShowDate').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#ShowDate').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Hour').val() == "" || $('#Hour').val() == " ") {
        allValid = false;
        $('#Hour').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Hour').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Price').val() == "" || $('#Price').val() == " " || $('#Price').val() < 0) {
        allValid = false;
        $('#Price').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Price').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Films').val() == 0 || $('#Films').val() == "0") {
        allValid = false;
        $('#Films').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Films').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Rooms').val() == 0 || $('#Rooms').val() == "0") {
        allValid = false;
        $('#Rooms').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Rooms').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Save();
    }
}

function validateEditFilmRoom() {
    var allValid = true;
    if ($('#ShowDate').val() == "" || $('#ShowDate').val() == " ") {
        allValid = false;
        $('#ShowDate').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#ShowDate').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Hour').val() == "" || $('#Hour').val() == " ") {
        allValid = false;
        $('#Hour').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Hour').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Price').val() == "" || $('#Price').val() == " " || $('#Price').val() < 0) {
        allValid = false;
        $('#Price').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Price').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Films').val() == 0 || $('#Films').val() == "0") {
        allValid = false;
        $('#Films').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Films').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Rooms').val() == 0 || $('#Rooms').val() == "0") {
        allValid = false;
        $('#Rooms').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Rooms').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Edit();
    }
}

function hiddenFilmRoomAlert() {
    $('#ShowDate').siblings('span.error').css('visibility', 'hidden');
    $('#Hour').siblings('span.error').css('visibility', 'hidden');
    $('#Price').siblings('span.error').css('visibility', 'hidden');
    $('#Films').siblings('span.error').css('visibility', 'hidden');
    $('#Rooms').siblings('span.error').css('visibility', 'hidden');
}

function clearFilmRoomScreen() {
    $('#Id').val('');
    $('#ShowDate').val('');
    $('#Hour').val('');
    $('#Price').val('');
    $('#Films').val(0);
    $('#Rooms').val(0);
    hiddenFilmRoomAlert();
}