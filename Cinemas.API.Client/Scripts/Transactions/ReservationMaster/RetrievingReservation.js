$(document).ready(function () {
    LoadIndexReservation();
    LoadUserCombo();
    hiddenReservationAlert();
    $('#table').DataTable({
        "ajax": LoadIndexReservation()
    });
});

function LoadIndexReservation() {
    $.ajax({
        url: 'http://localhost:17940/api/Reservations',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (reservation) {
            var html = '';
            var i = 1;
            $.each(reservation, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.ReservationDate + '</td>';
                html += '<td>' + val.TotalPrice + '</td>';
                html += '<td>' + val.Users.FirstName + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function LoadUserCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/Users',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var user = $('#Users');
            user.empty();
            user.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, User) {
                $("<option></option>").val(User.Id).text(User.FirstName).appendTo(user);
            });
        }
    });
}

function Save() {
    var reservation = new Object();
    reservation.TotalPrice = $('#TotalPrice').val();
    reservation.Users_Id = $('#Users').val();
    $.ajax({
        url: 'http://localhost:17940/api/Reservations',
        type: 'POST',
        dataType: 'json',
        data: reservation,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/Reservations/Index/';
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
            url: "http://localhost:17940/api/Reservations/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Reservations/Index/';
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
        url: 'http://localhost:17940/api/Reservations/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#ReservationDates').val(result.Name);
            $('#TotalPrice').val(result.SubDistricts_Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function validateInsertReservation() {
    var allValid = true;
    if ($('#TotalPrice').val() == "" || $('#TotalPrice').val() == " ") {
        allValid = false;
        $('#TotalPrice').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#TotalPrice').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Users').val() == 0 || $('#Users').val() == "0") {
        allValid = false;
        $('#Users').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Users').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Save();
    }
}

function hiddenReservationAlert() {
    $('#TotalPrice').siblings('span.error').css('visibility', 'hidden');
    $('#Users').siblings('span.error').css('visibility', 'hidden');
}

function clearReservationScreen() {
    $('#Id').val('');
    $('#TotalPrice').val('');
    $('#Users').val(0);
    hiddenReservationAlert();
}