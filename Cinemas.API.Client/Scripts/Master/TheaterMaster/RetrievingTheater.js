$(document).ready(function () {
    LoadIndexTheater();
    hiddenTheaterAlert();
    $('#table').DataTable({
        "ajax": LoadIndexTheater()
    });
});

function LoadIndexTheater() {
    $.ajax({
        url: 'http://localhost:17940/api/Theaters',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (theater) {
            var html = '';
            var i = 1;
            $.each(theater, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function Save() {
    var theater = new Object();
    theater.Name = $('#Name').val();
    $.ajax({
        url: 'http://localhost:17940/api/Theaters',
        type: 'POST',
        dataType: 'json',
        data: theater,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/Theaters/Index/';
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
            url: "http://localhost:17940/api/Theaters/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Theaters/Index/';
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
        url: 'http://localhost:17940/api/Theaters/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {
    var theater = new Object();
    theater.Id = $('#Id').val();
    theater.Name = $('#Name').val();
    $.ajax({
        url: 'http://localhost:17940/api/Theaters/' + theater.Id,
        type: 'PUT',
        data: theater,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Theaters/Index/';
                $('#Id').val('');
                $('#Name').val('');
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function validateInsertTheater() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Name').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Save();
    }
}

function validateEditTheater() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Name').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Edit();
    }
}

function hiddenTheaterAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
}

function clearTheaterScreen() {
    $('#Id').val('');
    $('#Name').val('');
    hiddenTheaterAlert();
}

