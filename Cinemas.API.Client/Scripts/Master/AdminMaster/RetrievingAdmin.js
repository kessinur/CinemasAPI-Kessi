$(document).ready(function () {
    LoadIndexAdmin();
    hiddenAdminAlert();
    $('#table').DataTable({
        "ajax": LoadIndexAdmin()
    });
});

function LoadIndexAdmin() {
    $.ajax({
        url: 'http://localhost:17940/api/Admins',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (admin) {
            var html = '';
            var i = 1;
            $.each(admin, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Username + '</td>';
                html += '<td>' + val.Password + '</td>';
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
    var admin = new Object();
    admin.Username = $('#Username').val();
    admin.Password = $('#Password').val();
    $.ajax({
        url: 'http://localhost:17940/api/Admins',
        type: 'POST',
        dataType: 'json',
        data: admin,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/Admins/Index/';
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
            url: "http://localhost:17940/api/Admins/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Admins/Index/';
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
        url: 'http://localhost:17940/api/Admins/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Username').val(result.Username);
            $('#Password').val(result.Password);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {
    var admin = new Object();
    admin.Id = $('#Id').val();
    admin.Username = $('#Username').val();
    admin.Password = $('#Password').val();
    $.ajax({
        url: 'http://localhost:17940/api/Admins/' + admin.Id,
        type: 'PUT',
        data: admin,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Admins/Index/';
                $('#Id').val('');
                $('#Username').val('');
                $('#Password').val('');
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function validateInsertAdmin() {
    var allValid = true;
    if ($('#Username').val() == "" || $('#Username').val() == " ") {
        allValid = false;
        $('#Username').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Username').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Password').val() == "" || $('#Password').val() == " ") {
        allValid = false;
        $('#Password').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Password').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Save();
    }
}

function validateEditAdmin() {
    var allValid = true;
    if ($('#Username').val() == "" || $('#Username').val() == " ") {
        allValid = false;
        $('#Username').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Username').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Password').val() == "" || $('#Password').val() == " ") {
        allValid = false;
        $('#Password').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Password').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Edit();
    }
}

function hiddenAdminAlert() {
    $('#Username').siblings('span.error').css('visibility', 'hidden');
    $('#Password').siblings('span.error').css('visibility', 'hidden');
}

function clearAdminScreen() {
    $('#Id').val('');
    $('#Username').val('');
    $('#Password').val('');
    hiddenAdminAlert();
}