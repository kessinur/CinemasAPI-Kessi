$(document).ready(function () {
    LoadIndexBuyTicket();
    LoadFilmRoomCombo();
    LoadReservationCombo();
    hiddenBuyTicketAlert();
    $('#table').DataTable({
        "ajax": LoadIndexBuyTicket()
    });
});

function LoadIndexBuyTicket() {
    $.ajax({
        url: 'http://localhost:17940/api/BuyTickets',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (buyticket) {
            var html = '';
            var i = 1;
            $.each(buyticket, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.FilmRooms.Name + '</td>';
                html += '<td>' + val.FilmRooms.Films.Title + '</td>';
                html += '<td>' + val.Reservations.Id + '</td>';
                html += '<td>' + val.Reservations.Users.FirstName + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function LoadFilmRoomCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/FilmRooms',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var filmroom = $('#FilmRooms');
            filmroom.empty();
            filmroom.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, FilmRoom) {
                $("<option></option>").val(FilmRoom.Id).text(FilmRoom.Id).appendTo(filmroom);
            });
        }
    });
}

function LoadReservationCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/Reservations',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var reservation = $('#Reservations');
            reservation.empty();
            reservation.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, Reservation) {
                $("<option></option>").val(Reservation.Id).text(Reservation.Id).appendTo(reservation);
            });
        }
    });
}

function Save() {
    var buyticket = new Object();
    buyticket.FilmRooms_Id = $('#FilmRooms').val();
    buyticket.Reservations_Id = $('#Reservations').val();
    $.ajax({
        url: 'http://localhost:17940/api/BuyTickets',
        type: 'POST',
        dataType: 'json',
        data: buyticket,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/BuyTickets/Index/';
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
            url: "http://localhost:17940/api/BuyTickets/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/BuyTickets/Index/';
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
        url: 'http://localhost:17940/api/BuyTickets/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
           $('#FilmRooms').val(result.FilmRooms_Id);
            $('#Reservations').val(result.Reservations_Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function validateInsertBuyTicket() {
    var allValid = true;
    if ($('#FilmRooms').val() == 0 || $('#FilmRooms').val() == "0") {
        allValid = false;
        $('#FilmRooms').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#FilmRooms').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Reservations').val() == 0 || $('#Reservations').val() == "0") {
        allValid = false;
        $('#Reservations').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Reservations').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Save();
    }
}

function hiddenBuyTicketAlert() {
    $('#FilmRooms').siblings('span.error').css('visibility', 'hidden');
    $('#Reservations').siblings('span.error').css('visibility', 'hidden');
}

function clearBuyTicketScreen() {
    $('#Id').val('');
    $('#FilmRooms').val(0);
    $('#Reservations').val(0);
    hiddenBuyTicketAlert();
}