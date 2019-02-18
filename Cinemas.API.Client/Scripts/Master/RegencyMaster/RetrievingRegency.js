$(document).ready(function () {
    LoadIndexRegency();
    LoadProvincyCombo();
    hiddenRegencyAlert();
    $('#table').DataTable({
        "ajax": LoadIndexRegency()
    });
});

function LoadIndexRegency() {
    debugger;
    $.ajax({
        url: 'http://localhost:17940/api/Regencies',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (regency) {
            var html = '';
            var i = 1;
            $.each(regency, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Provinces.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function LoadProvincyCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/Provinces',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var province = $('#Provinces');
            province.empty();
            province.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, Province) {
                $("<option></option>").val(Province.Id).text(Province.Name).appendTo(province);
            });
        }
    });
}

function Save() {
    var regency = new Object();
    regency.Name = $('#Name').val();
    regency.Provinces_Id = $('#Provinces').val();
    $.ajax({
        url: 'http://localhost:17940/api/Regencies',
        type: 'POST',
        dataType: 'json',
        data: regency,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/Regencies/Index/';
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
            url: "http://localhost:17940/api/Regencies/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Regencies/Index/';
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
        url: 'http://localhost:17940/api/Regencies/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Provinces').val(result.Provinces_Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {
    var regency = new Object();
    regency.Id = $('#Id').val();
    regency.Name = $('#Name').val();
    regency.Provinces_Id = $('#Provinces').val();
    $.ajax({
        url: 'http://localhost:17940/api/Regencies/' + regency.Id,
        type: 'PUT',
        data: regency,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Regencies/Index/';
                $('#Id').val('');
                $('#Name').val('');
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function validateInsertRegency() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Name').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Provinces').val() == 0 || $('#Provinces').val() == "0") {
        allValid = false;
        $('#Provinces').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Provinces').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Save();
    }
}

function validateEditRegency() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Name').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Provinces').val() == 0 || $('#Provinces').val() == "0") {
        allValid = false;
        $('#Provinces').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Provinces').siblings('span.error').css('visibility', 'visible');
    }

    if (allValid == true) {
        Edit();
    }
}

function hiddenRegencyAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Provinces').siblings('span.error').css('visibility', 'hidden');
}

function clearRegencyScreen() {
    $('#Id').val('');
    $('#Name').val('');
    $('#Provinces').val(0);
    hiddenRegencyAlert();
}