$(document).ready(function () {
    LoadIndexSubDistrict();
    LoadRegencyCombo();
    hiddenSubDistrictAlert();
    $('#table').DataTable({
        "ajax": LoadIndexSubDistrict()
    });
});

function LoadIndexSubDistrict() {
    debugger;
    $.ajax({
        url: 'http://localhost:17940/api/SubDistricts',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (subdistrict) {
            var html = '';
            var i = 1;
            $.each(subdistrict, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Regencies.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function LoadRegencyCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/Regencies',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var regency = $('#Regencies');
            regency.empty();
            regency.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, Regency) {
                $("<option></option>").val(Regency.Id).text(Regency.Name).appendTo(regency);
            });
        }
    });
}

function Save() {
    var subdistrict = new Object();
    subdistrict.Name = $('#Name').val();
    subdistrict.Regencies_Id = $('#Regencies').val();
    $.ajax({
        url: 'http://localhost:17940/api/SubDistricts',
        type: 'POST',
        dataType: 'json',
        data: subdistrict,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/SubDistricts/Index/';
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
            url: "http://localhost:17940/api/SubDistricts/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/SubDistricts/Index/';
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
        url: 'http://localhost:17940/api/SubDistricts/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Regencies').val(result.Regencies_Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {
    var subdistrict = new Object();
    subdistrict.Id = $('#Id').val();
    subdistrict.Name = $('#Name').val();
    subdistrict.Regencies_Id = $('#Regencies').val();
    $.ajax({
        url: 'http://localhost:17940/api/SubDistricts/' + subdistrict.Id,
        type: 'PUT',
        data: subdistrict,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/SubDistricts/Index/';
                $('#Id').val('');
                $('#Name').val('');
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function validateInsertSubDistrict() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Regencies').val() == 0 || $('#Regencies').val() == "0") {
        allValid = false;
        $('#Regencies').siblings('span.error').css('visibility', 'visible');
    }

    if (allValid == true) {
        Save();
    }
}

function validateEditSubDistrict() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Regencies').val() == 0 || $('#Regencies').val() == "0") {
        allValid = false;
        $('#Regencies').siblings('span.error').css('visibility', 'visible');
    }

    if (allValid == true) {
        Edit();
    }
}

function hiddenSubDistrictAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Regencies').siblings('span.error').css('visibility', 'hidden');
}

function clearSubDistrictScreen() {
    $('#Id').val('');
    $('#Name').val('');
    $('#Regencies').val(0);
    hiddenSubDistrictAlert();
}