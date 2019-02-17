$(document).ready(function () {
    LoadIndexVillage();
    LoadSubDistrictCombo();
    hiddenVillageAlert();
    $('#table').DataTable({
        "ajax": LoadIndexVillage()
    });
});

function LoadIndexVillage() {
    $.ajax({
        url: 'http://localhost:17940/api/Villages',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (village) {
            var html = '';
            var i = 1;
            $.each(village, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.SubDistricts.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function LoadSubDistrictCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/SubDistricts',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var subdistrict = $('#SubDistricts');
            subdistrict.empty();
            subdistrict.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, Subdistrict) {
                $("<option></option>").val(Subdistrict.Id).text(Subdistrict.Name).appendTo(subdistrict);
            });
        }
    });
}

function Save() {
    var village = new Object();
    village.Name = $('#Name').val();
    village.SubDistricts_Id = $('#SubDistricts').val();
    $.ajax({
        url: 'http://localhost:17940/api/Villages',
        type: 'POST',
        dataType: 'json',
        data: village,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/Villages/Index/';
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
            url: "http://localhost:17940/api/Villages/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Villages/Index/';
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
        url: 'http://localhost:17940/api/Villages/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#SubDistricts').val(result.SubDistricts_Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {
    var village = new Object();
    village.Id = $('#Id').val();
    village.Name = $('#Name').val();
    village.SubDistricts_Id = $('#SubDistricts').val();
    $.ajax({
        url: 'http://localhost:17940/api/Villages/' + village.Id,
        type: 'PUT',
        data: village,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Villages/Index/';
                $('#Id').val('');
                $('#Name').val('');
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function validateInsertVillage() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#SubDistricts').val() == 0 || $('#SubDistricts').val() == "0") {
        allValid = false;
        $('#SubDistricts').siblings('span.error').css('visibility', 'visible');
    }

    if (allValid == true) {
        Save();
    }
}

function validateEditVillage() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#SubDistricts').val() == 0 || $('#SubDistricts').val() == "0") {
        allValid = false;
        $('#SubDistricts').siblings('span.error').css('visibility', 'visible');
    }

    if (allValid == true) {
        Edit();
    }
}

function hiddenVillageAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#SubDistricts').siblings('span.error').css('visibility', 'hidden');
}

function clearVillageScreen() {
    $('#Id').val('');
    $('#Name').val('');
    $('#SubDistricts').val(0);
    hiddenVillageAlert();
}