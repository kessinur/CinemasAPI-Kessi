$(document).ready(function () {
    LoadIndexCinema();
    LoadVillageCombo();
    LoadTheaterCombo();
    hiddenCinemaAlert();
    $('#table').DataTable({
        "ajax": LoadIndexCinema()
    });
});

function LoadIndexCinema() {
    $.ajax({
        url: 'http://localhost:17940/api/Cinemas',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (cinema) {
            var html = '';
            var i = 1;
            $.each(cinema, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Address + '</td>';
                html += '<td>' + val.Villages.Name + '</td>';
                html += '<td>' + val.Theaters.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function LoadVillageCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/Villages',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var village = $('#Villages');
            village.empty();
            village.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, Village) {
                $("<option></option>").val(Village.Id).text(Village.Name).appendTo(village);
            });
        }
    });
}

function LoadTheaterCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/Theaters',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var theater = $('#Theaters');
            theater.empty();
            theater.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, Theater) {
                $("<option></option>").val(Theater.Id).text(Theater.Name).appendTo(theater);
            });
        }
    });
}

function Save() {
    var cinema = new Object();
    cinema.Name = $('#Name').val();
    cinema.Address = $('#Address').val();
    cinema.Villages_Id = $('#Villages').val();
    cinema.Theaters_Id = $('#Theaters').val();
    $.ajax({
        url: 'http://localhost:17940/api/Cinemas',
        type: 'POST',
        dataType: 'json',
        data: cinema,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/Cinemas/Index/';
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
            url: "http://localhost:17940/api/Cinemas/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Cinemas/Index/';
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
        url: 'http://localhost:17940/api/Cinemas/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Address').val(result.Address);
            $('#Villages').val(result.Villages_Id);
            $('#Theaters').val(result.Theaters_Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {
    var cinema = new Object();
    cinema.Id = $('#Id').val();
    cinema.Name = $('#Name').val();
    cinema.Address = $('#Address').val();
    cinema.Villages_Id = $('#Villages').val();
    cinema.Theaters_Id = $('#Theaters').val();
    $.ajax({
        url: 'http://localhost:17940/api/Cinemas/' + cinema.Id,
        type: 'PUT',
        data: cinema,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Cinemas/Index/';
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

function validateInsertCinema() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Address').val() == "" || $('#Address').val() == " ") {
        allValid = false;
        $('#Address').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Villages').val() == 0 || $('#Villages').val() == "0") {
        allValid = false;
        $('#Villages').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Theaters').val() == 0 || $('#Theaters').val() == "0") {
        allValid = false;
        $('#Theaters').siblings('span.error').css('visibility', 'visible');
    }

    if (allValid == true) {
        Save();
    }
}

function validateEditCinema() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Address').val() == "" || $('#Address').val() == " ") {
        allValid = false;
        $('#Address').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Villages').val() == 0 || $('#Villages').val() == "0") {
        allValid = false;
        $('#Villages').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Theaters').val() == 0 || $('#Theaters').val() == "0") {
        allValid = false;
        $('#Theaters').siblings('span.error').css('visibility', 'visible');
    }

    if (allValid == true) {
        Edit();
    }
}

function hiddenCinemaAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Address').siblings('span.error').css('visibility', 'hidden');
    $('#Villages').siblings('span.error').css('visibility', 'hidden');
    $('#Theaters').siblings('span.error').css('visibility', 'hidden');
}

function clearCinemaScreen() {
    $('#Id').val('');
    $('#Name').val('');
    $('#Address').val('');
    $('#Villages').val(0);
    $('#Theaters').val(0);
    hiddenCinemaAlert();
}