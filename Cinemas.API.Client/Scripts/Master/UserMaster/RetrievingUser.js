$(document).ready(function () {
    LoadIndexUser();
    LoadVillageCombo();
    LoadReligionCombo();
    hiddenUserAlert();
    $('#table').DataTable({
        "ajax": LoadIndexUser()
    });
});

function LoadIndexUser() {
    $.ajax({
        url: 'http://localhost:17940/api/Users',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (user) {
            var html = '';
            var i = 1;
            $.each(user, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.FirstName + '</td>';
                html += '<td>' + val.LastName + '</td>';
                html += '<td>' + val.Gender + '</td>';
                html += '<td>' + val.Phone + '</td>';
                html += '<td>' + val.Email + '</td>';
                html += '<td>' + val.Amount + '</td>';
                html += '<td>' + val.Username + '</td>';
                html += '<td>' + val.Password + '</td>';
                html += '<td>' + val.Address + '</td>';
                html += '<td>' + val.Religions.Name + '</td>';
                html += '<td>' + val.Villages.Name + '</td>';
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

function LoadReligionCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/Religions',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var religion = $('#Religions');
            religion.empty();
            religion.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, Religion) {
                $("<option></option>").val(Religion.Id).text(Religion.Name).appendTo(religion);
            });
        }
    });
}

function Save() {
    var user = new Object();
    user.FirstName = $('#FirstName').val();
    user.LastName = $('#LastName').val();
    user.Gender = $('#Gender').val();
    user.Phone = $('#Phone').val();
    user.Email = $('#Email').val();
    user.Amount = $('#Amount').val();
    user.Username = $('#Username').val();
    user.Password = $('#Password').val();
    user.Address = $('#Address').val();
    user.Religions_Id = $('#Religions').val();
    user.Villages_Id = $('#Villages').val();
    $.ajax({
        url: 'http://localhost:17940/api/Users',
        type: 'POST',
        dataType: 'json',
        data: user,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/Users/Index/';
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
            url: "http://localhost:17940/api/Users/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Users/Index/';
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
        url: 'http://localhost:17940/api/Users/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#FirstName').val(result.FirstName);
            $('#LastName').val(result.LastName);
            $('#Gender').val(result.Gender);
            $('#Phone').val(result.Phone);
            $('#Email').val(result.Email);
            $('#Amount').val(result.Amount);
            $('#Username').val(result.Username);
            $('#Password').val(result.Password);
            $('#Address').val(result.Address);
            $('#Religions').val(result.Religions_Id);
            $('#Villages').val(result.Villages_Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {
    var user = new Object();
    user.Id = $('#Id').val();
    user.FirstName = $('#FirstName').val();
    user.LastName = $('#LastName').val();
    user.Gender = $('#Gender').val();
    user.Phone = $('#Phone').val();
    user.Email = $('#Email').val();
    user.Amount = $('#Amount').val();
    user.Username = $('#Username').val();
    user.Password = $('#Password').val();
    user.Address = $('#Address').val();
    user.Religions_Id = $('#Religions').val();
    user.Villages_Id = $('#Villages').val();
    $.ajax({
        url: 'http://localhost:17940/api/Users/' + user.Id,
        type: 'PUT',
        data: user,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Users/Index/';
                $('#Id').val('');
                $('#FirstName').val('');
                $('#LastName').val('');
                $('#Gender').val('');
                $('#Email').val('');
                $('#Amount').val('');
                $('#Username').val('');
                $('#Password').val('');
                $('#Address').val('');
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function validateInsertUser() {
    var allValid = true;
    if ($('#FirstName').val() == "" || $('#FirstName').val() == " ") {
        allValid = false;
        $('#FirstName').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#FirstName').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#LastName').val() == "" || $('#LastName').val() == " ") {
        allValid = false;
        $('#LastName').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#LastName').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Gender').val() == "" || $('#Gender').val() == " ") {
        allValid = false;
        $('#Gender').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Gender').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Phone').val() == "" || $('#Phone').val() == " ") {
        allValid = false;
        $('#Phone').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Phone').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Email').val() == "" || $('#Email').val() == " ") {
        allValid = false;
        $('#Email').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Email').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Amount').val() == "" || $('#Amount').val() == " " || $('#Amount').val() < 0) {
        allValid = false;
        $('#Amount').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Amount').siblings('span.error').css('visibility', 'hidden');
    }
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
    if ($('#Address').val() == "" || $('#Address').val() == " ") {
        allValid = false;
        $('#Address').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Address').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Religions').val() == 0 || $('#Religions').val() == "0") {
        allValid = false;
        $('#Religions').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Religions').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Villages').val() == 0 || $('#Villages').val() == "0") {
        allValid = false;
        $('#Villages').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Villages').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Save();
    }
}

function validateEditUser() {
    var allValid = true;
    if ($('#FirstName').val() == "" || $('#FirstName').val() == " ") {
        allValid = false;
        $('#FirstName').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#FirstName').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#LastName').val() == "" || $('#LastName').val() == " ") {
        allValid = false;
        $('#LastName').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#LastName').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Gender').val() == "" || $('#Gender').val() == " ") {
        allValid = false;
        $('#Gender').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Gender').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Phone').val() == "" || $('#Phone').val() == " ") {
        allValid = false;
        $('#Phone').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Phone').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Email').val() == "" || $('#Email').val() == " ") {
        allValid = false;
        $('#Email').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Email').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Amount').val() == "" || $('#Amount').val() == " " || $('#Amount').val() < 0) {
        allValid = false;
        $('#Amount').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Amount').siblings('span.error').css('visibility', 'hidden');
    }
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
    if ($('#Address').val() == "" || $('#Address').val() == " ") {
        allValid = false;
        $('#Address').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Address').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Religions').val() == 0 || $('#Religions').val() == "0") {
        allValid = false;
        $('#Religions').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Religions').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Villages').val() == 0 || $('#Villages').val() == "0") {
        allValid = false;
        $('#Villages').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Villages').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Edit();
    }
}

function hiddenUserAlert() {
    $('#FirstName').siblings('span.error').css('visibility', 'hidden');
    $('#LastName').siblings('span.error').css('visibility', 'hidden');
    $('#Gender').siblings('span.error').css('visibility', 'hidden');
    $('#Phone').siblings('span.error').css('visibility', 'hidden');
    $('#Email').siblings('span.error').css('visibility', 'hidden');
    $('#Amount').siblings('span.error').css('visibility', 'hidden');
    $('#Username').siblings('span.error').css('visibility', 'hidden');
    $('#Password').siblings('span.error').css('visibility', 'hidden');
    $('#Address').siblings('span.error').css('visibility', 'hidden');
    $('#Religions').siblings('span.error').css('visibility', 'hidden');
    $('#Villages').siblings('span.error').css('visibility', 'hidden');
}

function clearUserScreen() {
    $('#Id').val('');
    $('#FirstName').val('');
    $('#LastName').val('');
    $('#Gender').val('');
    $('#Phone').val('');
    $('#Email').val('');
    $('#Amount').val('');
    $('#Username').val('');
    $('#Password').val('');
    $('#Address').val('');
    $('#Religions').val(0);
    $('#Villages').val(0);
    hiddenUserAlert();
}