$(document).ready(function () {
    LoadIndexRoom();
    LoadCinemaCombo();
    hiddenRoomAlert();
    $('#table').DataTable({
        "ajax": LoadIndexRoom()
    });
});

function LoadIndexRoom() {
    $.ajax({
        url: 'http://localhost:17940/api/Rooms',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (room) {
            var html = '';
            var i = 1;
            $.each(room, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Seat + '</td>';
                html += '<td>' + val.Cinemas.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function LoadCinemaCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/Cinemas',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var cinema = $('#Cinemas');
            cinema.empty();
            cinema.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, Cinema) {
                $("<option></option>").val(Cinema.Id).text(Cinema.Name).appendTo(cinema);
            });
        }
    });
}

function Save() {
    var room = new Object();
    room.Name = $('#Name').val();
    room.Seat = $('#Seat').val();
    room.Cinemas_Id = $('#Cinemas').val();
    $.ajax({
        url: 'http://localhost:17940/api/Rooms',
        type: 'POST',
        dataType: 'json',
        data: room,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/Rooms/Index/';
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
            url: "http://localhost:17940/api/Rooms/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Rooms/Index/';
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
        url: 'http://localhost:17940/api/Rooms/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Seat').val(result.Seat);
            $('#Cinemas').val(result.Cinemas_Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {
    var room = new Object();
    room.Id = $('#Id').val();
    room.Name = $('#Name').val();
    room.Seat = $('#Seat').val();
    room.Cinemas_Id = $('#Cinemas').val();
    $.ajax({
        url: 'http://localhost:17940/api/Rooms/' + room.Id,
        type: 'PUT',
        data: room,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Rooms/Index/';
                $('#Id').val('');
                $('#Name').val('');
                $('#Seat').val('');
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function validateInsertRoom() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Name').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Seat').val() == "" || $('#Seat').val() == " ") {
        allValid = false;
        $('#Seat').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Seat').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Cinemas').val() == 0 || $('#Cinemas').val() == "0") {
        allValid = false;
        $('#Cinemas').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Cinemas').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Save();
    }
}

function validateEditRoom() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Name').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Seat').val() == "" || $('#Seat').val() == " ") {
        allValid = false;
        $('#Seat').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Seat').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Cinemas').val() == 0 || $('#Cinemas').val() == "0") {
        allValid = false;
        $('#Cinemas').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Cinemas').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Edit();
    }
}

function hiddenRoomAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Seat').siblings('span.error').css('visibility', 'hidden');
    $('#Cinemas').siblings('span.error').css('visibility', 'hidden');
}

function clearRoomScreen() {
    $('#Id').val('');
    $('#Name').val('');
    $('#Seat').val('');
    $('#Cinemas').val(0);
    hiddenRoomAlert();
}